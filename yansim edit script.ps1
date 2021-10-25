#YanSim Save data editor
title "Yandere Simulator Save Game Editor"
$version = "1.0"
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
[int32]$savegame = read-host -Prompt "What Porfile is the current player on? (1-3 Ayano, 11-13 Ryoba)"
$array = @(1,2,3,11,12,13)
$modern = @(1,2,3)
$old = @(11,12,13)
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
    write-host "Help: `n Commands: `n  help: Displays this message. `n  npc: change npc stats and such. (no, not the json ones, maybe later) `n  config: change game wide configuration. `n  exit: stops the utility `nKeep in mind that everything is CaSe SeNsItIvE"
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
            $globaldebug = ($regvalues | Select-String -Pattern "Profile_0_Debug")
            $debugvalue = read-host -Prompt "Enter 0 to disable debug, 1 to enable debug."
            if($debug -notin @(0,1)){
                write-host "Error: Value must be 0 or 1." -ForegroundColor "red"
            }else{
                Set-ItemProperty -Path "$regpath" -Name "$debug" -Value $debugvalue
                Get-ItemProperty -Path "$regpath" -Name $debug
                Set-ItemProperty -Path "$regpath" -Name "$globaldebug" -Value $debugvalue
                Get-ItemProperty -Path "$regpath" -Name $globaldebug
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
                $promptuni = read-host -Prompt "Edit Uniform: female, male, reset or exit (keep all lower case)"
                if($promptuni -notin $uniarray){
                    write-host "ERROR: input must be female or male or exit." -ForegroundColor "red"
                }
                elseif($promptuni -eq "female"){
                    $uniid = read-host -Prompt "Enter the uniform value from 1 to 6."
                    if($uniid -notin $uniidarry){
                        write-host "ERROR: value must be between 1 and 6" -ForegroundColor "red"
                    }else{
                        Set-ItemProperty -Path "$regpath" -Name "$funiform" -Value "$uniid"
                        Get-ItemProperty -Path "$regpath" -Name "$funiform"
                    }
                }
                elseif($promptuni -eq "male"){
                    $uniid = read-host -Prompt "Enter the uniform value from 1 to 6."
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
                $titlescreen = read-host -Prompt "Enter a save file to show on the title screen. (Background for Osana only)"
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
        $promptnpc = read-host -Prompt "NPC: help, exit, rep, state"
        $arraynpc = @('help','exit','state','rep')
        if($promptnpc -notin $arraynpc){
            write-host "ERROR: $promptnpc isn't a command."
        }
        elseif($promptnpc -eq "help"){
            write-host "Help for NPC commands: `n  help: displays this message `n  exit: goes to main menu `n  kill: sets the 'isDying', not sure if this kills them. `n  rep: changes a characters repuation.  "
        }
        elseif($promptnpc -eq "rep"){
            if($profiletype -eq "1"){
                write-host "You are in Ayano's time period, use the proper ID's."
            }else{
                write-host "You are in Ryoba's time period, use the proper ID's."
            }
            $npcid = read-host -Prompt "Enter the NPC's ID (1 for Taro, 11 for Osana, ETC."
            $rep = read-host -Prompt "Enter the reputation (you can use negative numbers, just use the '-' symbol before that."
            $npc = "Profile_" + "$savegame" + "_StudentReputation_" + "$npcid"
            write-host $npc
            $npcrep = ($regvalues | Select-String -Pattern "$npc")
            Set-ItemProperty -Path "$regpath" -Name "$npcrep" -Value $rep
            Get-ItemProperty -Path "$regpath" -Name "$npcrep"
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
            $npcid = read-host -Prompt "Enter the NPC's ID (1 for Taro, 11 for Osana, ETC.)"
            $deadoralive = read-host -Prompt "Enter value"
            $npc = "Profile_" + "$savegame" + "_StudentDying_" + "$npcid"
            $npcdeath = ($regvalues | Select-String -Pattern "$npc")
            Set-ItemProperty -Path "$regpath" -Name "$npcdeath" -Value $deadoralive
            Get-ItemProperty -Path "$regpath" -Name "$npcdeath"
        }
    }
}

#big boi while loop
while($true){
    $prompt = read-host -Prompt "Main Menu use 'help' for help."
    $available = @('help','npc','config','exit')
    if($prompt -notin $available){
        write-host "ERROR: $prompt isn't a command. Type 'help' for help." -ForegroundColor "red"
    }
    if($prompt -eq "help"){
        cmdhelp
    }
    elseif($prompt -eq "config"){
        cmdconfig
        break
    }
    elseif($prompt -eq "npc"){
        cmdnpc
    }
    elseif($prompt -eq "exit"){
        write-host "Goodbye."
        exit
    }
}

}