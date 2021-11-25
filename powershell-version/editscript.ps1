#YanSim Save data editor
Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName PresentationCore,PresentationFramework
[System.Windows.Forms.Application]::EnableVisualStyles()
function log(){
    param ([string]$text, [switch]$debug)
    if($debug -eq $false -and $nolog -eq "false"){
        Add-Content -Path ".\$date.log" -Value "[$seconds]: $text"
    }elseif($debug -eq $true -and $allowdebug -eq "true" -and $nolog -eq "false"){
        Add-Content -Path "$logfolder\$date.log" -Value "[$seconds]:[DEBUG]: $text"
    }
    if($printlog -eq "true"){
        write-host "[$seconds]: $text"
    }elseif($printlog -eq "true" -and $debug -eq $true){
        write-host  "[$seconds]:[DEBUG]: $text"
    }
}
$version = "1.4"
$idarray = @(1..100)
$array = @(1,2,3,11,12,13)
$modern = @(1,2,3)
$old = @(11,12,13)
$1or0 = @(0,1)
$date = Get-Date -Format "MM-dd-yyyy"
$seconds = Get-Date -Format "HH:mm:ss"
$time = Get-Date
#for later usage
$appdata = "$env:APPDATA\BTELNYY"
#configuration via registry
$globalconfigpath = "HKCU:\SOFTWARE\btelnyy"
$configpath = "$globalconfigpath\YanSaveEdit"
log("Starting Log, it is currently $time")
$temp = Test-Path -Path "$configpath"
if($temp -eq $true){
    log("Path for configuration exists. Parent: $globalconfigpath")
}else{
    New-Item -Path "HKCU:\SOFTWARE" -Name "btelnyy" | Out-null
    New-Item -Path $configpath -Name "YanSaveEdit" | Out-Null
}
function importconfig(){
    param ([string]$valuename, [string]$defaultvalue, [string]$override)
    $verify = (Get-Item $configpath).Property -contains "$valuename"
    if($verify -eq $false){
        New-ItemProperty -Path $configpath -Name "$valuename" -value "$defaultvalue" | Out-Null
        $output = Get-ItemPropertyValue -Path $configpath $valuename
        log("Created New Registry Value $valuename with value $defaultvalue in $configpath")
        return $output
    }else{
        $output = Get-ItemPropertyValue -Path $configpath $valuename
        if($output -eq ""){
            Set-ItemProperty -Path $configpath -Name $valuename -Value $defaultvalue
        }else{
            log("Importing value $valuename from $configpath with value $output")
            return $output
        }
    }
    write-host $override
    if($override -eq "true"){
        Set-ItemProperty -Path $configpath -Name "$valuename" -Value "$defaultvalue"
        log("Set value $valuename in $configpath with value $default value becuase override was true.")
    }
}
function exportconfig(){
    param ([string]$valuename, [string]$value)
    Set-ItemProperty -Path $regpath -Name $valuename -Value $value
    log("Set $valuename in $regpath to $value")
}
$allowdebug = importconfig -valuename "allowDebug" -defaultvalue "true"
if($allowdebug -eq "true"){log("All debug messages will be shown in the log.")}else{log("No debug messages will be shown in the log.")}
$logfolder = importconfig -valuename "logFolder" -defaultvalue "."
$skipagreement = importconfig -valuename "skipAgreement" -defaultvalue "false"
$nolog = importconfig -valuename "noLog" -defaultvalue "false"
$regpath = importconfig -valuename "regPath" -defaultvalue "HKCU:\SOFTWARE\YandereDev\YandereSimulator\"
$printlog = importconfig -valuename "printLog" -defaultvalue "false" 
$eolwarn = importconfig -valuename "eolWarn" -defaultvalue "true"
if($printlog -eq "true"){log("Printing to console is enabled, all log messages will be disaplayed on screen.")}
$regvalues = Get-Item -Path $regpath | Select-Object -ExpandProperty Property
write-host "BTELNYY's Yandere Simulator Save Game Editor v$version" -ForegroundColor "blue"
write-host "Yandere Simulator by Alexander Stuart Mahan or YandereDev." -ForegroundColor "blue"
write-host "Only Works for the Osana Demo or later (Including 1980's mode)" -ForegroundColor "blue"
write-host "If I restricted an input to a certian set of values, please, Just follow those values unless you want your save file to be gone." -ForegroundColor "blue"
write-host "I have a discord btw: https://discord.gg/P22tFkjTm3" -ForegroundColor "blue"
write-warning "There is no update mechanism, you'll have to check manually."
if($eolwarn -eq "true"){
    write-host "CRITICAL WARNING: Make sure you are watching for the new C# version of the game, this version will be outdated once that releases." -ForegroundColor "darkyellow"
}
write-host "------------------------------------------------------------------------------------------------------------------"
write-host "I agree and understand that any bugs and related issues in the game are not to be reported as bugs to YandereDev."
write-host "I understand that this tool may cuase game crashes, softlocks, and other bad situations."
if($skipagreement -eq "false"){
    while($true){
        $agreement = read-host "Do you agree and understand to the above statements? [y/n]"
        if($agreement -eq "y"){
            $temp = read-host "Would you like to never see this agreement before? (Default n)[y/n]"
            if($temp -eq "y"){
                Set-ItemProperty -Path $configpath -Name "skipAgreement" -value "true"
                write-host "You will not see this screen again."
            }else{
                write-host "You either inputted n, or another value. This agreement will display on next boot."
                break
            }
            break
        }elseif($agreement -eq "n"){
            write-host "Agreement declined. Exiting....."
            pause
            exit
        }else{

        }
    }
}
write-host "I understand that this tool may cause me to lose my save file."
write-host "Save Files are stored from the top being 1. and the bottom being 3 with 2 in the middle."
write-host "Select the file you are on, or going to be on."
write-host "In order for changes to take affect, you must reload your day."
write-host "What Porfile is the current player on? (1-3 Ayano, 11-13 Ryoba)"

function errorgui(){
    #currently not used, will be needed when I make a GUI.
    param([string]$msg, [string]$details)
    log("Error occured, error msg: $msg, error details: $details")
    $Form                            = New-Object system.Windows.Forms.Form
    $Form.ClientSize                 = New-Object System.Drawing.Point(500,300)
    $Form.text                       = "Error"
    $Form.TopMost                    = $false
    $Form.FormBorderStyle            = 'Fixed3D'
    $Form.maximizeBox                = $false

    $Panel1                          = New-Object system.Windows.Forms.TextBox
    $Panel1.ReadOnly                 = $true
    $Panel1.height                   = 190
    $Panel1.width                    = 460
    $Panel1.location                 = New-Object System.Drawing.Point(20,75)
    $Panel1.MultiLine                = $true
    $Panel1.WordWrap                 = $true
    $Panel1.Scrollbars               = "Vertical"
    $Panel1.Text                     = $details

    $closebutton                     = New-Object system.Windows.Forms.Button
    $closebutton.text                = "Close"
    $closebutton.width               = 60
    $closebutton.height              = 30
    $closebutton.location            = New-Object System.Drawing.Point(440,270)
    $closebutton.Font                = New-Object System.Drawing.Font('Microsoft Sans Serif',10)
    $closebutton.Add_Click{
        $Form.Close()
        return
    }

    $Label1                          = New-Object system.Windows.Forms.Label
    $Label1.Text                     = $msg
    $Label1.AutoSize                 = $true
    $Label1.width                    = 25
    $Label1.height                   = 10
    $Label1.location                 = New-Object System.Drawing.Point(5,15)
    $Label1.Font                     = New-Object System.Drawing.Font('Microsoft Sans Serif',10)

    $Form.controls.AddRange(@($closebutton,$Panel1,$TextBox1,$TextBox2,$Label1,$Button1,$CheckBox1,$closebutton2,$checkbox2,$TextBox5,$GroupLabel,$Button3,$Button4))
    [void]$Form.ShowDialog()
}
#errorgui -msg "error message" -details "error details"
#keep above line for later
if((Test-Path -Path "$env:APPDATA\btelnyy") -eq $false){
    New-Item -path "$env:APPDATA\" -Name "btelnyy" -ItemType "directory" | Out-Null
}else{
    log("ignored creation of appdata directory as it already exists.")
}
while($true){
    $savegame = read-host "Value Between 1-3, 11-13"
    $temp = "ProfileCreated_$savegame"
    $temp2 = $regvalues | Select-String -Pattern $temp
    $temp3 = Get-ItemPropertyValue -Path $regpath $temp2
    if($savegame -notin $array){
        Write-host "ERROR: invalid save game specified." -ForegroundColor "red" 
    }elseif($null -eq $temp2){
        write-host "ERROR: save file doesn't exist." -ForegroundColor "red"
    }elseif($temp3 -eq 0){
        write-host "ERROR: save file was deleted." -ForegroundColor "red"
    }
    elseif($savegame -in $modern){
       Write-host "Ok, Selected Ayano's time period." -ForegroundColor "green"
        $profiletype = 1
        break
    }elseif($savegame -in $old){
        write-host "Ok, Selected Ryoba's time period." -ForegroundColor "green"
        $profiletype = 0
        break
    }
}      
log("The current profile is $savegame")
log("The current registry path is $regpath")
log("The current appdata directory is $appdata")
#disabled until I can figure out how to edit JSON files.
#$gamepath = read-host "Enter the games directory (Where EXE is located)"
#write-host "Warning: Pointing to a invalid folder won't trigger any errors, just please don't" -ForegroundColor "yellow"



function cmdhelp{
    write-host "Help: `n Commands: `n  help: Displays this message. `n  npc: change npc stats and such. (no, not the json ones, maybe later) `n  config: change game wide configuration. `n  exit: stops the utility. `n  tinker: opens the tinker menu. `n  deletesave: deletes save data. `nself: modify things about your player. `nKeep in mind that everything is CaSe SeNsItIvE"
}
function self{
    log("Entering self config")
    while($true){
        write-host "Don't worry, more comming sono!"
        write-host "Self Config: club, exit."
        $selfpromptarray = @('club','exit')
        $selfprompt = read-host "COMMAND"
        $clubs = @(0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,99,100,101)
        if($selfprompt -notin $selfpromptarray){
            write-host "ERROR: $selfprompt isn't a command." -ForegroundColor "red"
        }elseif($selfprompt -eq "exit"){
            log("Exitting self config")
            break
        }elseif($selfprompt -eq "club"){
            write-host "Enter a club ID (0-15, 99, 100, 101)"
            write-host "If you know what all the clubs names are, please contact me on discord at: https://discord.gg/P22tfkjTm3 or create a github issue."
            $clubid = read-host "ID"
            if($clubid -notin $clubs){
                write-host "ERROR: Invalid club ID." -ForegroundColor "red"
                log("Invalid Club id was specified")
            }else{
                $newclub = "Profile_$savegame" + "_Club"
                $oldclub = "Profile_$savegame" + "_Club_h"
                $oldclub2 = $regvalues | Select-String -Pattern "$oldclub"
                log -text "oldphoto2 = $oldclub2" -debug
                $verify = (Get-Item $regpath).Property -contains $newclub
                $verify2 = (Get-ITem $regpath).Property -contains $oldclub2
                if($verify -eq $true){
                    $temp = "Profile_$savegame" + "_Club"
                    Set-ItemProperty -path $regpath -name $temp -value $clubid
                    write-host "Done." -ForegroundColor "green"
                    log("User has not reset the game to title screen, $temp in $regpath has been set to $value")
                }elseif($verify -eq $false -and $verify2 -eq $false){
                    log("[DEBUG] value 'verify' is $verify and value 'verify2' is $verify2")
                    $temp = "Profile_$savegame" + "_Club"
                    New-ItemProperty -path $regpath -Name $temp -Value 0
                    Set-ItemProperty -path $regpath -Name $temp -Value $clubid
                    write-host "Done." -ForegroundColor "green"
                    log("Wrote new value called $temp in $regpath with a value of $clubid")
                }else{
                    log("Changed value in $regpath with name $oldclub2 to value $clubid")
                    $temp = "Profile_$savegame" + "_Club_h"
                    $temp2 = $regvalues | Select-String -Pattern $temp
                    Set-ItemProperty -Path $regpath -Name $temp2 -Value $clubid
                    write-host "Done." -ForegroundColor "green"
                }
            }
        }
    }
}
function cmdconfig{
    while($true){
        write-host "Configuration: debug, exit, uniform, titlescreen (updates the title screen), item (force brings an item from home), gday (changes the gameplayday), gweek (changes the gameplay week)"
        $promptconfig = read-host "COMMAND" 
        $arrayconfig = @('debug','exit','uniform','titlescreen','item','gday','gweek')
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
                log("debug key for current profile is $debug")
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
                log("Set $bringitem in $regpath to $item")
                Get-ItemProperty -Path "$regpath" -Name "$bringitem"
                write-host "Done." -ForegroundColor "green"
            }
        }elseif($promptconfig -eq "gday"){
            $gdaydays = @(0..7)
            log("Accessing the gameplay day menu")
            write-host "Enter a number from 0-7"
            $value = read-host "VALUE"
            if($value -notin $gdaydays){
                write-host "ERROR: Invalid day specified." -ForegroundColor "red"
            }else{
                $gameday = "Profile_$savegame" + "_GameplayDay"
                $gameday2 = $regvalues | Select-String -Pattern $gameday #temp refused to work. OK BUDDY.
                Set-ItemProperty -path $regpath -name "$gameday2" -value $value
                $gameday22 = "Profile_$savegame" + "_WeekDay"
                $gameday23 = $regvalues | Select-String -Pattern $gameday22
                Set-ItemProperty -path $regpath -name "$gameday23" -value $value
            }
        }elseif($promptconfig -eq "gweek"){
            $gweekweeks = @(1..10)
            log("Accessing the gameplay week menu.")
            write-host "Enter a number from 0-10"
            $value = read-host "VALUE"
            if($value -notin $gweekweeks){
                write-host "ERROR: Invalid week specified." -ForegroundColor "red"
            }else{
                $week = "Profile_$savegame" + "_Week"
                $week2 = $regvalues | Select-String -Pattern $week
                Set-ItemProperty -path $regpath -name "$week2" -value $value
                log("Set $week2 in $regpath to $value")
            }
        }
    }
    return
}
function cmdnpc{
    log("Entered NPC submenu")
    while($true){
        write-host "NPC: help, rep, state, kidnap, photo, exit."
        $promptnpc = read-host "COMMAND"
        $arraynpc = @('help','exit','state','rep','kidnap','photo')
        if($promptnpc -notin $arraynpc){
            write-host "ERROR: $promptnpc isn't a command."
        }
        elseif($promptnpc -eq "help"){
            write-host "Help for NPC commands: `n  help: displays this message `n  exit: goes to main menu `n  state: sets living status for NPCs. `n  rep: changes a characters repuation. `n  kidnap: allows the player to manage victims and switch them. `n photo: allows players to have 'photos' of students. (ID Screen)."
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
                $npcrep = ($regvalues | Select-String -Pattern "$npc")
                Set-ItemProperty -Path "$regpath" -Name "$npcrep" -Value $rep
                Get-ItemProperty -Path "$regpath" -Name "$npcrep"
                log("Changed NPC $npcid's reputation to $rep with key $npc")
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
            log("Exit NPC submenu")
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
                        $temp = "Profile_" + "$savegame" + "_StudentKidnapped_" + "$releaseprompt" + "_"
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
        }elseif($promptnpc -eq "photo"){
            log("Photo prompt ready.")
            write-host "Enter a NPC ID to change status of Photograph."
            $npcid = read-host "ID"

            if($npcid -notin $idarray){
                write-host "ERROR: Invalid ID specified." -ForegroundColor "red"
                log("User specified invalid ID for the photo prompt.")
            }else{
                $newphoto = "Profile_$savegame" + "_StudentPhotographed_$npcid"
                $oldphoto = "Profile_$savegame" + "_StudentPhotographed_" + "$npcid" + "_h"
                $oldphoto2 = $regvalues | Select-String -Pattern "$oldphoto"
                log -text "oldphoto2 = $oldphoto2" -debug
                write-host "Enter value: 1 being photographed (true) and 0 being not photographed (false)"
                $value = read-host -Prompt "VALUE" 
                $verify = (Get-Item $regpath).Property -contains $newphoto
                $verify2 = (Get-ITem $regpath).Property -contains $oldphoto2
                if($verify -eq $true){
                    $temp = "Profile_$savegame" + "_StudentPhotographed_$npcid"
                    Set-ItemProperty -path $regpath -name $temp -value $value
                    write-host "Done." -ForegroundColor "green"
                    log("User has not reset the game to title screen, $temp in $regpath has been set to $value")
                }elseif($verify -eq $false -and $verify2 -eq $false){
                    log("[DEBUG] value 'verify' is $verify and value 'verify2' is $verify2")
                    $temp = "Profile_$savegame" + "_StudentPhotographed_$npcid"
                    New-ItemProperty -path $regpath -Name $temp -Value 0
                    Set-ItemProperty -path $regpath -Name $temp -Value $value
                    write-host "Done." -ForegroundColor "green"
                    log("Wrote new value called $temp in $regpath with a value of $value")
                }else{
                    log("Changed value in $regpath with name $oldphoto2 to value $value")
                    $temp = "Profile_$savegame" + "_StudentPhotographed_" + "$npcid" + "_h"
                    $temp2 = $regvalues | Select-String -Pattern $temp
                    Set-ItemProperty -Path $regpath -Name $temp2 -Value $value
                    write-host "Done." -ForegroundColor "green"
                }
            } 
        }
    }
}
function tinker{
    log("Entered Tinker Menu")
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
            log("Exited Tinker Menu")
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
        $available = @('help','npc','config','exit','tinker','deletesave','self')
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
            log("Shutting Down Application at $time")
            write-host "Goodbye."
            exit
        }
        elseif($prompt -eq "deletesave"){
            log("entered delete save submenu")
            write-host "DANGER! this will destroy all config related to Yandere Simulator, Save files, Config, etc. You will have to run the game again to use this tool." -ForegroundColor "cyan"
            $deleteall = read-host "Delete all data? [y/n]"
            if($deleteall -eq "y"){
                Remove-Item -Path $regpath -Force
                write-host "All data deleted."
                log("All save data was destroyed by deletesave.")
            }else{
                write-host "Aborted."
                log("exited delete save submenu (Aborted)")
            }
        }elseif($prompt -eq "self"){
            self
        }
    }
}