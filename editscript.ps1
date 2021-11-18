#YanSim Save data editor
$version = "1.4 BETA 1"
$idarray = @(1..100)
write-host "BTELNYY's Yandere Simulator Save Game Editor v$version" -ForegroundColor "blue"
write-host "Yandere Simulator by Alexander Stuart Mahan or YandereDev." -ForegroundColor "blue"
write-host "Only Works for the Osana Demo or later (Including 1980's mode)" -ForegroundColor "blue"
write-host "If I restricted an input to a certian set of values, please, Just follow those values unless you want your save file to be gone." -ForegroundColor "blue"
write-host "I have a discord btw: https://discord.gg/P22tFkjTm3" -ForegroundColor "blue"
write-warning "There is no update mechanism, you'll have to check manually."
write-host "------------------------------------------------------------------------------------------------------------------"
write-host "I agree and understand that any bugs and related issues in the game are not to be reported as bugs to YandereDev."
write-host "I understand that this tool may cuase game crashes, softlocks, and other bad situations."
write-host "I understand that this tool may cause me to lose my save file."
write-host "Watch for caps lock, all commands are lowercase."
while($true){
    $consent = read-host "Do you agree and understand to the above statements? [y/n]"
    if($consent -eq "y"){
        break
    }elseif($consent -eq "n"){
        write-host "Agreement declined. Exiting....."
        pause
        exit
    }else{

    }
}
$regpath = "HKCU:\Software\YandereDev\YandereSimulator\"
$regvalues = Get-Item -Path $regpath | Select-Object -ExpandProperty Property
write-host "Save Files are stored from the top being 1. and the bottom being 3 with 2 in the middle. Select the save file you are on, or going to be on."
write-warning "The program doesn't check if the save files are accurate, so do not lie unless you like erros."
write-host "What Porfile is the current player on? (1-3 Ayano, 11-13 Ryoba)"
[int32]$savegame = read-host "Value Between 1-3, 11-13"
$array = @(1,2,3,11,12,13)
$modern = @(1,2,3)
$old = @(11,12,13)
$1or0 = @(0,1)
while($true){
    if($savegame -notin $array){
        Write-host "ERROR: invalid save game specified." -ForegroundColor "red" 
    }
    if($savegame -in $modern){
       Write-host "Ok, Selected Ayano's time period." -ForegroundColor "green"
        $profiletype = 1
        break
    }elseif($savegame -in $old){
        write-host "Ok, Selected Ryoba's time period." -ForegroundColor "green"
        $profiletype = 0
        break
    }else{
        write-host "ERROR: I have no idea how you got here." -ForegroundColor "red"
    }
}      
#disabled until I can figure out how to edit JSON files.
#$gamepath = read-host "Enter the games directory (Where EXE is located)"
#write-host "Warning: Pointing to a invalid folder won't trigger any errors, just please don't" -ForegroundColor "yellow"
function cmdhelp{
    write-host "Help: `n Commands: `n  help: Displays this message. `n  npc: change npc stats and such. (no, not the json ones, maybe later) `n  config: change game wide configuration. `n  exit: stops the utility. `n  tinker: opens the tinker menu. `n  deletesave: deletes save data. `nKeep in mind that everything is CaSe SeNsItIvE"
}
function cmdconfig{
    while($true){
        write-host "Configuration: debug, exit, uniform, titlescreen (updates the title screen), item (force brings an item from home)"
        $promptconfig = read-host "COMMAND" 
        $arrayconfig = @('debug','exit','uniform','titlescreen','item')
        #I regret using else if
        if($promptconfig -notin $arrayconfig){
            write-host "ERROR: $promptconfig isn't a command." -ForegroundColor "red"
        }
        elseif($promptconfig -eq "debug"){
            write-warning "I am not sure if debug mode remains on between game restarts, if no, use this tool and exit and enter the save file."
            $savegame_Debug = "$savegame" + "_Debug"
            $debug = ($regvalues | Select-String -Pattern "Profile_$savegame_Debug")
            write-host "Enter 0 to disable debug mode, 1 to enable it."
            $debugvalue = read-host -Prompt "VALUE"
            $debugarray = @(0,1)
            if($debugvalue -notin $debugarray){
                write-host "Error: Value must be 0 or 1." -ForegroundColor "red"
            }else{
                Set-ItemProperty -Path "$regpath" -Name "$debug" -Value $debugvalue
                Get-ItemProperty -Path "$regpath" -Name $debug
                write-host "Done." -ForegroundColor "green"
                if($profiletype -eq 0){
                    write-warning "Debug mode within Ryoba's time period may cause problems."
                    write-warning "This command is technically not useful anymore as 1980's mode supports debug mode since the november 2021 builds, you can still use this command to continue if you don't want to beat the game."
                }
            }
        }
        elseif($promptconfig -eq "exit"){
            break
        }
        elseif($promptconfig -eq "uniform"){
            #oh boy, here we go again.
            while($true){
                $muni =  "Profile_" + "$savegame" + "_MaleUniform"
                $muniform = ($regvalues | Select-String -Pattern $muni)
                $funi =  "Profile_" + "$savegame" + "_FemaleUniform"
                $funiform = ($regvalues | Select-String -Pattern $funi)
                $uniidarry = @(1,2,3,4,5,6)
                $uniarray = @('female','male','exit','reset')
                write-host "Edit Uniform: female, male, reset or exit (keep all lower case)"
                $promptuni = read-host "COMMAND"
                if($promptuni -notin $uniarray){
                    write-host "ERROR: input must be female or male or exit." -ForegroundColor "red"
                }
                elseif($promptuni -eq "female"){
                    write-host "Enter the uniform value (1-6)"
                    $uniid = read-host -Prompt "UNIFORM"
                    if($uniid -notin $uniidarry){
                        write-host "ERROR: value must be between 1 and 6" -ForegroundColor "red"
                    }else{
                        Set-ItemProperty -Path "$regpath" -Name "$funiform" -Value "$uniid"
                        Get-ItemProperty -Path "$regpath" -Name "$funiform"
                        write-host "Done." -ForegroundColor "green"
                    }
                }
                elseif($promptuni -eq "male"){
                    write-host "Enter the uniform value (1-6)"
                    $uniid = read-host -Prompt "UNIFORM"
                    if($uniid -notin $uniidarry){
                        write-host "ERROR: value must be between 1 and 6" -ForegroundColor "red"
                    }else{
                        Set-ItemProperty -Path "$regpath" -Name "$muniform" -Value "$uniid"
                        Get-ItemProperty -Path "$regpath" -Name "$muniform"
                        write-host "Done." -ForegroundColor "green"
                    }
                }
                elseif($promptuni -eq "exit"){
                    break
                }
                elseif($promptuni -eq "reset"){
                    Set-ItemProperty -Path "$regpath" -Name "$funiform" -Value "1"
                    Set-ItemProperty -Path "$regpath" -Name "$muniform" -Value "1"
                    Get-ItemProperty -Path "$regpath" -Name "$funiform"
                    Get-ItemProperty -Path "$regpath" -Name "$muniform"
                    write-host "Done." -ForegroundColor "green"
                }
            }
        }
        elseif($promptconfig -eq "titlescreen"){
            while($true){
                write-host "Enter a Demo Save file (1-3)"
                $titlescreen = read-host -Prompt "SAVEFILE"
                if($titlescreen -notin $modern){
                    write-host "ERROR: You must specify a valid modern save file (1-3)" -ForegroundColor "red"
                }else{
                    $tprofile = ($regvalues | Select-String -Pattern "Profile_h")
                    Set-ItemProperty -Path "$regpath" -Name "$tprofile" -Value $titlescreen
                    Get-ItemProperty -Path "$regpath" -Name "$tprofile"
                    write-host "Done." -ForegroundColor "green"
                    break
                }
            }
        }
        elseif($promptconfig -eq "item"){
            $itemarray = @(1..12)
            write-host "1 - Scissors `n2 - Box Cutter `n3 - Screwdriver `n4 - Rat Posion `n5 - Alcohol `n6 - Cigarettes `n7 - Condoms `n8 - Lockpick `n9 - Sedative `n10 - Narcotics `n11 - Lethal Poison `n12 - Explosive"
            write-host "ENTER A VALUE OF AN ITEM (ID)"
            $item = read-host -Prompt "ID"
            if($item -notin $itemarray){
                write-host "ERROR: Invalid ID was specified." -ForegroundColor "red"
            }else{
                $temp = "Profile_" + "$savegame" + "_BringingItem"
                $bringitem = ($regvalues | Select-String -Pattern $temp)
                Set-ItemProperty -Path "$regpath" -Name "$bringitem" -Value $item
                Get-ItemProperty -Path "$regpath" -Name "$bringitem"
                write-host "Done." -ForegroundColor "green"
            }
        }
    }
    return
}
function cmdnpc{
    while($true){
        write-host "NPC: help, rep, state, kidnap, exit."
        $promptnpc = read-host "COMMAND"
        $arraynpc = @('help','exit','state','rep','kidnap')
        if($promptnpc -notin $arraynpc){
            write-host "ERROR: $promptnpc isn't a command."
        }
        elseif($promptnpc -eq "help"){
            write-host "Help for NPC commands: `n  help: displays this message `n  exit: goes to main menu `n  state: sets the 'isDying', not sure if this kills them. `n  rep: changes a characters repuation. `n  revive: allows the player to bring back dead NPC's. `n  kidnap: allows the player to manage victims and switch them."
        }
        elseif($promptnpc -eq "rep"){
            if($profiletype -eq "1"){
                write-host "You are in Ayano's time period, use the proper ID's."
            }else{
                write-host "You are in Ryoba's time period, use the proper ID's."
            }
            write-host "Enter the NPC's ID (1 for Taro, 11 for Osana, ETC."
            $npcid = read-host "ID"
            if($npcid -notin $idarray){
                write-host "ERROR: Invalid Student ID, Must be a integer between 1 and 100." -ForegroundColor "red"
            }else{
                write-host "Enter a reputation value, must be a integer, can be negative"
                $rep = read-host -Prompt "VALUE"
                $npc = "Profile_" + "$savegame" + "_StudentReputation_" + "$npcid"
                write-host $npc
                $npcrep = ($regvalues | Select-String -Pattern "$npc")
                Set-ItemProperty -Path "$regpath" -Name "$npcrep" -Value $rep
                Get-ItemProperty -Path "$regpath" -Name "$npcrep"
                write-host "Done." -ForegroundColor "green"
            }
            #TO DO: check if the value is int32, but powershell refuses to let me do it.
            #if($rep -is [int]){
                #$npc = "Profile_" + "$savegame" + "StudentReputation_" + "$npcid"
                #$npcrep = ($regvalues | Select-String -Pattern "$npc")
                #Set-ItemProperty -Path "$regpath" -Name "$npcrep" -Value $rep
                #Get-ItemProperty -Path "$regpath" -Name "$npcrep"
            #}else{
                #write-host $rep
                #write-host "Error: Inputted value is invalid. must be a integer. (any number that is not a decimal or fraction)" -ForegroundColor "red"
            #}
        }
        elseif($promptnpc -eq "exit"){
            break
        }
        #elseif($promptnpc -eq ""){
         #   write-warning "For the life of me I cannot figure out what this value is meant to do, I guess try putting in some value and see what happens?"
         #   write-host "Enter student ID"
         #   $npcid = read-host -Prompt "ID"
         #   if($npcid -notin $idarray){
         #       write-host "ERROR: Invalid Student ID, Must be a integer between 1 and 100." -ForegroundColor "red"
         #   }else{
         #       $deadoralive = read-host -Prompt "Enter value"
         #       $npc = "Profile_" + "$savegame" + "_StudentDying_" + "$npcid"
         #       $npcdeath = ($regvalues | Select-String -Pattern "$npc")
         #       Set-ItemProperty -Path "$regpath" -Name "$npcdeath" -Value $deadoralive
         #       Get-ItemProperty -Path "$regpath" -Name "$npcdeath"
         #       write-host "Done." -ForegroundColor "green"
         #   }
        # }
        elseif($promptnpc -eq "state"){
            $deadnpcs = "Profile_$savegame" + "_StudentDead_"
            write-host "Enter a student ID to modify life state."
            $npctorevive = read-host "ID"
            if($npctorevive -notin $idarray){
                write-host "ERROR: Invalid ID, must be a valid student ID."
            }else{
                $deadnpc = "$deadnpcs" + "$npctorevive"
                write-host "Enter Value for Student $npctorevive, 1 being dead, 0 meaning alive. Anything else will keep them dead."
                $death = read-host "VALUE"
                $studentrevive = $regvalues | Select-String -Pattern "$deadnpc"
                if($studentrevive -eq $null){
                    New-ItemProperty -path $regpath -name $deadnpc -value 0
                    Set-ItemProperty -path $regpath -name $deadnpc -value $death
                    Get-ItemProperty -Path $regpath -Name $deadnpc
                    write-host "The student was not killed before and therefore had a new value set for them."
                    write-host "Done." -ForegroundColor "green"
                }else{
                    Set-ItemProperty -Path "$regpath" -Name $studentrevive -Value $death
                    Get-ItemProperty -Path $regpath -Name $studentrevive
                    write-host "Done." -ForegroundColor "green"
                }
            }
        }
        elseif($promptnpc -eq "kidnap"){
            $kidnapcmd = @('victim','release','exit')
            while($true){
                write-host "Kidnap Management: victim, release, exit."
                $kidnapprompt = read-host "COMMAND"
                if($kidnapprompt -notin $kidnapcmd){
                    write-host "ERROR: $kidnapprompt isn't a command." -ForegroundColor "red"
                }
                elseif($kidnapprompt -eq "victim"){
                    write-host "Just a quick FYI, the game still thinks anybody you've actually kidnapped as kidnapped, so they wont come to school if you replaced them, you can always release them with the release command."
                    write-host "Enter the ID of the student you want to be set as your victim."
                    $kidnapvictim = read-host "ID"
                    if($kidnapvictim -notin $idarray){
                        write-host "ERROR: ID is invalid." -ForegroundColor "red"
                    }else{
                        $temp = "Profile_" + "$savegame" + "_KidnapVictim"
                        $kidnapvar = $regvalues | Select-String -Pattern "$temp"
                        if($kidnapvar -eq $null){
                            New-ItemProperty -Path $regpath -Name $temp -Value 0
                            Set-ItemProperty -path $regpath -Name $temp -Value $kidnapvictim
                            write-host "Since you had no prevous victims, a new value was written."
                            write-host "Done." -ForegroundColor "green"
                        }else{
                            Set-ItemProperty -path $regpath -Name $kidnapvar -Value $kidnapvictim
                            Get-ItemProperty -path $regpath -Name $kidnapvar
                            write-host "Done." -ForegroundColor "green"
                        }
                    }
                }
                elseif($kidnapprompt -eq "release"){
                    #I should not make new vars for this shit, until I can figure out a way, Ill use this.
                    $temp = "Profile_" + "$savegame" + "_StudentKidnapped_"
                    write-host "Profile_#_StudentKidnapped_ID_h#########"
                    $regvalues | Select-string -Pattern "$temp" -list
                    write-host "Even though this command is called 'release', it can do the opposite, simply enter a ID of a student you have kidnapped before and enter 1 at the next prompt."
                    write-host "Please choose a ID from the above list, otherwise errors will occur."
                    write-host "Enter a valid ID"
                    $releaseprompt = read-host "ID"
                    if($releaseprompt -notin $idarray){
                        write-host "ERROR: ID is invalid." -ForegroundColor "red"
                    }else{
                        $temp = "Profile_" + "$savegame" + "_StudentKidnapped_" + "$releaseprompt"
                        $kidnapvar2 = ($regvalues | Select-String -Pattern "$temp") #kill me later.
                        write-host "Enter a state for ID $releaseprompt, 1 being kidnapped, 0 being at school."
                        $releasevalue = read-host "VALUE"
                        if($releasevalue -notin $1or0){
                            write-host "ERROR: Must be 0 or 1." -ForegroundColor "red"
                        }else{
                            Set-ItemProperty -path $regpath -Name $kidnapvar2 -Value $releasevalue
                            Get-ItemProperty -path $regpath -Name $kidnapvar2
                            write-host "Done." -ForegroundColor "green"
                        }
                    }
                }
            }
        }
    }
}
function tinker{
    $regpath = "HKCU:\Software\YandereDev\YandereSimulator\"
    $regvalues = Get-Item -Path $regpath | Select-Object -ExpandProperty Property
    $tinkercmd = @('list','search','modify','exit','read','exists')
    write-host "Welcome to the tinkerer, the Registry command line edit tool for Yandere Simulator."
    write-host "Becuase some people want to modify any registry key."
    write-host "I/We are not responsible for save game corruption."
    write-host "This is more advanced stuff, so instructions may be vauge or technical."
    while($true){
        write-host "Tinkerer: list, search, modify, read, exists, exit."
        $tinkerinput = read-host "COMMAND"
        if($tinkerinput -notin $tinkercmd){
            write-host "ERROR: $tinkerinput isn't a command." -ForegroundColor "red"
        }elseif($tinkerinput -eq "exit"){
            break
        }elseif($tinkerinput -eq "list"){
            Get-Item -Path $regpath | Select-Object -ExpandProperty Property
            write-host "This isn't exactly really easy to read, so use the search function."
        }elseif($tinkerinput -eq "search"){
            write-host "Searches with simple pattern match, caps matter, Replace 1 in Profile_1 with any profile number to search through those."
            write-host "If your modifying things in a save file you did not select, simply restart instead of doing this."
            write-host "Enter a search pattern, eg 'Profile_1_Student' Don't forget the 'Profile_1'"
            $pattern = read-host "PATTERN"
            $regvalues | Select-string -Pattern "$pattern" -list
        }elseif($tinkerinput -eq "modify"){
            Write-Host "You might want to run the list or search commands before this one."
            write-warning "YandereDev made some values corrupt DWORDS, This means modifying them will break them and may break the game in strange ways. Money is a corrupt DWORD."
            write-warning "This stuff also may break if a invalid property was specified."
            write-host "Enter a valid registry property."
            $valueinput = read-host "PROPERTY"
            $setto = read-host "VALUE"
            Set-ItemProperty -Path "$regpath" -Name "$valueinput" -Value $setto
            Get-ItemProperty -Path $regpath -Name $valueinput
        }elseif($tinkerinput -eq "read"){
            Write-host "Enter a valid registry property."
            $read = read-host "PROPERTY"
            Get-ItemProperty -Path $regpath -Name $read
        }elseif($tinkerinput -eq "exists"){
            Write-host "Enter a registry property."
            $temp = read-host "PROPERTY"
            $checkfor = $regvalues | Select-string -Pattern "$temp" -List
            if($null -eq $checkfor){
                write-host "That value does not exist."
            }else{
                write-host "That value exists, full name $checkfor"
            }
        }
    }
}

while($true){
#big boi while loop
    while($true){
        write-host "Main Menu use 'help' for help."
        $prompt = read-host -Prompt "COMMAND"
        $available = @('help','npc','config','exit','tinker','deletesave')
        if($prompt -notin $available){
            write-host "ERROR: $prompt isn't a command. Type 'help' for help." -ForegroundColor "red"
        }
        if($prompt -eq "help"){
            cmdhelp
        }
        elseif($prompt -eq "config"){
            cmdconfig
        }
        elseif($prompt -eq "npc"){
            cmdnpc
        }
        elseif($prompt -eq "tinker"){
            tinker
        }
        elseif($prompt -eq "exit"){
            write-host "Goodbye."
            exit
        }
        elseif($prompt -eq "deletesave"){
            write-host "DANGER! this will destroy all config related to Yandere Simulator, Save files, Config, etc. You will have to run the game again to use this tool." -ForegroundColor "cyan"
            $deleteall = read-host "Delete all data? [y/n]"
            if($deleteall -eq "y"){
                Remove-Item -Path $regpath -Force
                write-host "All data deleted."
            }else{
                write-host "Aborted."
            }
        }
    }
}
