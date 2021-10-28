#YanSim Save data editor
$version = "1.1"
$idarray = @(1..100)
write-host "BTELNYY's Yandere Simulator Save Game Editor v$version" -ForegroundColor "blue"
write-host "Yandere Simulator by Alexander Stuart Mahan or YandereDev." -ForegroundColor "blue"
write-host "Only Works for the Osana Demo or later (Including 1980's mode)" -ForegroundColor "blue"
write-host "If I restricted an input to a certian set of values, please, Just follow those values unless you want your save file to be gone." -ForegroundColor "blue"
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
while($true){
function cmdhelp{
    write-host "Help: `n Commands: `n  help: Displays this message. `n  npc: change npc stats and such. (no, not the json ones, maybe later) `n  config: change game wide configuration. `n  exit: stops the utility. `n  tinker: opens the tinker menu. `n  deletesave: deletes save data. `nKeep in mind that everything is CaSe SeNsItIvE"
}
function cmdconfig{
    while($true){
        $promptconfig = read-host "Configuration: debug, exit, uniform, titlescreen (updates the title screen)"
        $arrayconfig = @('debug','exit','uniform','titlescreen')
        if($promptconfig -notin $arrayconfig){
            write-host "ERROR: $promptconfig isn't a command." -ForegroundColor "red"
        }
        elseif($promptconfig -eq "debug"){
            write-warning "This command updated your global debug value aswell, this may cause all save files to have debug commands."
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
                if($profiletype -eq 0){
                    write-warning "Debug mode within Ryoba's time period may cause problems."
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
                    break
                }
            }
        }
    }
    return
}
function cmdnpc{
    while($true){
        write-host "NPC: help, exit, rep, state, revive"
        $promptnpc = read-host "COMMAND"
        $arraynpc = @('help','exit','state','rep','revive')
        if($promptnpc -notin $arraynpc){
            write-host "ERROR: $promptnpc isn't a command."
        }
        elseif($promptnpc -eq "help"){
            write-host "Help for NPC commands: `n  help: displays this message `n  exit: goes to main menu `n  state: sets the 'isDying', not sure if this kills them. `n  rep: changes a characters repuation. `n  revive: allows the player to bring back dead NPC's "
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
        elseif($promptnpc -eq "state"){
            write-warning "For the life of me I cannot figure out what this value is meant to do, I guess try putting in some value and see what happens?"
            write-host "Enter student ID"
            $npcid = read-host -Prompt "ID"
            if($npcid -notin $idarray){
                write-host "ERROR: Invalid Student ID, Must be a integer between 1 and 100." -ForegroundColor "red"
            }else{
                $deadoralive = read-host -Prompt "Enter value"
                $npc = "Profile_" + "$savegame" + "_StudentDying_" + "$npcid"
                $npcdeath = ($regvalues | Select-String -Pattern "$npc")
                Set-ItemProperty -Path "$regpath" -Name "$npcdeath" -Value $deadoralive
                Get-ItemProperty -Path "$regpath" -Name "$npcdeath"
            }
        }elseif($promptnpc -eq "revive"){
            $deadnpcs = "Profile_$savegame" + "_StudentDead_"
            write-host "Profile_#_StudentDead_ID_h##########"
            $regvalues | Select-string -Pattern "$deadnpcs"
            write-host "If the Above list is empty, no students are dead. attempting to revive a already alive student will result in errors."
            write-host "From the list above, please choose a NPC by ID to revive."
            $npctorevive = read-host "ID"
            if($npctorevive -notin $idarray){
                write-host "ERROR: Invalid ID, must be a valid student ID."
            }else{
                $deadnpc = "$deadnpcs" + "$npctorevive"
                write-host "Enter Value for Student $npctorevive, 1 being dead, 0 meaning alive. Anything else will keep them dead."
                $death = read-host "VALUE"
                $studentrevive = ($regvalues | Select-String -Pattern "$deadnpc") 
                Set-ItemProperty -Path "$regpath" -Name $studentrevive -Value $death
                Get-ItemProperty -Path $regpath -Name $studentrevive
            }
        }
    }
}
function tinker{
    $regpath = "HKCU:\Software\YandereDev\YandereSimulator\"
    $regvalues = Get-Item -Path $regpath | Select-Object -ExpandProperty Property
    $tinkercmd = @('list','search','modify','exit','read')
    write-host "Welcome to the tinkerer, the Registry command line edit tool for Yandere Simulator."
    write-host "Becuase some people want to modify any registry key."
    write-host "I/We are not responsible for save game corruption."
    write-host "This is more advanced stuff, so instructions may be vauge or technical."
    while($true){
        write-host "Tinkerer: list, search, modify, read, exit."
        $tinkerinput = read-host "COMMAND"
        if($tinkerinput -notin $tinkercmd){
            write-host "ERROR: $tinkerinput isn't a command."
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
        }
    }
}



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