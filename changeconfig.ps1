Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing
[System.Windows.Forms.Application]::EnableVisualStyles()
$globalconfigpath = "HKCU:\SOFTWARE\btelnyy"
$configpath = "$globalconfigpath\YanSaveEdit"
$date = Get-Date -Format "MM-dd-yyyy"
$seconds = Get-Date -Format "HH:mm:ss"
$time = Get-Date
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
function importconfig(){
    param ([string]$valuename, [string]$defaultvalue)
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
}
function exportconfig(){
    param ([string]$valuename, [string]$value)
    Set-ItemProperty -Path $configpath -Name $valuename -Value $value
    log("Set $valuename in $configpath to $value")
}
$allowdebug = importconfig -valuename "allowDebug" -defaultvalue "true"
if($allowdebug -eq "true"){log("All debug messages will be shown in the log.")}else{log("No debug messages will be shown in the log.")}
$logfolder = importconfig -valuename "logFolder" -defaultvalue "."
$skipagreement = importconfig -valuename "skipAgreement" -defaultvalue "false"
$nolog = importconfig -valuename "noLog" -defaultvalue "false"
$regpath = importconfig -valuename "regPath" -defaultvalue "HKCU:\SOFTWARE\YandereDev\YandereSimulator\"
$printlog = importconfig -valuename "printLog" -defaultvalue "false" 
if($printlog -eq "true"){log("Printing to console is enabled, all log messages will be disaplayed on screen.")}

$nolog = importconfig -valuename "noLog" -defaultvalue "false"
$Form  = New-Object system.Windows.Forms.Form
$Form.ClientSize  = New-Object System.Drawing.Point(700,700)
$Form.text  = "Configuration"
$Form.TopMost = $false
$Form.FormBorderStyle  = 'Fixed3D'
$Form.maximizeBox = $false

$save = New-Object System.Windows.Forms.Button
$save.Height = 30
$save.Width = 60
$save.location = New-Object System.Drawing.Point(640,670)
$save.text = "Save"
$Form.Controls.Add($save)
$save.Add_Click({
    exportconfig -valuename "noLog" -value $nologlist.SelectedItem
    $nolog = $nologlist.SelectedItem
    exportconfig -valuename "allowDebug" -value $allowdebuglist.SelectedItem
    if($nolog -eq "true"){
        $allowdebuglist.Enabled = $false
    }else{
        $allowdebuglist.Enabled = $true
    }
    exportconfig -valuename "printLog" -value $logprintlist.SelectedItem
    if($nolog -eq "true"){
        $logprintlist.Enabled = $false
    }else{
        $logprintlist.Enabled = $true
    }
    $Form.Refresh()
})




$info = New-Object System.Windows.Forms.Label
$info.Location = New-Object System.Drawing.Point(10,10)
$Info.Text = "Change configuration of BTELNYY's Yansim save edit tool. This is client side config and nothing to do with the game."
$Info.AutoSize = $true
$Form.Controls.Add($Info)

$nologlabel = New-Object System.Windows.Forms.Label
$nologlabel.Location = New-Object System.Drawing.Point(10,30)
$nologlabel.Text = "Disallow log generation by programs?"
$nologlabel.AutoSize = $true
$Form.Controls.Add($nologlabel)

$nologlist = New-Object System.Windows.Forms.ComboBox
$nologlist.Location = New-Object System.Drawing.Point(10,50)
$nologlist.Height = 25
[void]$nologlist.Items.Add("true")
[void]$nologlist.Items.Add("false")
if($nolog -eq "true"){
    $nologlist.SelectedIndex = 1
}elseif($nolog -eq "false"){
    $nologlist.SelectedIndex = 0
}
$Form.Controls.Add($nologlist)

$debuglog = New-Object System.Windows.Forms.Label
$debuglog.Location = New-Object System.Drawing.Point(10,75)
$debuglog.Text = "Allow program to generate debug logs?"
$debuglog.AutoSize = $true
$Form.Controls.Add($debuglog)

$allowdebuglist = New-Object System.Windows.Forms.ComboBox
$allowdebuglist.Location = New-Object System.Drawing.Point(10,95)
$allowdebuglist.Height = 25
[void]$allowdebuglist.Items.Add("true")
[void]$allowdebuglist.Items.Add("false")
if($allowdebug -eq "true"){
    $allowdebuglist.SelectedIndex = 0
}elseif($allowdebug -eq "false"){
    $allowdebuglist.SelectedIndex = 1
}
if($nolog -eq "true"){
    $allowdebuglist.Enabled = $false
}
$Form.Controls.Add($allowdebuglist)

$logprint = New-Object System.Windows.Forms.Label
$logprint.Location = New-Object System.Drawing.Point(10,120)
$logprint.Text = "Print Logs to console?"
$logprint.AutoSize = $true
$Form.Controls.Add($logprint)

$logprintlist = New-Object System.Windows.Forms.ComboBox
$logprintlist.Location = New-Object System.Drawing.Point(10,140)
$logprintlist.Height = 25
[void]$logprintlist.Items.Add("true")
[void]$logprintlist.Items.Add("false")
if($printlog -eq "true"){
    $logprintlist.SelectedIndex = 0
}elseif($printlog -eq "false"){
    $logprintlist.SelectedIndex = 1
}
if($nolog -eq "true"){
    $logprintlist.Enabled = $false
}
$Form.Controls.Add($logprintlist)


[void]$Form.ShowDialog()