# Watermark
This application is a simple watermarking tool for windows screens.  
This is designed to be used as identification of the laptop in an organization.  
Watermark is a simple application that runs in the background and displays the watermark on the screen.  
The text of the watermark is customizable and can be changed by editing the CLI args when starting the application.  

## Installation
1. Download the latest release from [here](https://github.com/Nathanwoodburn/Watermark/releases)
2. Copy a link to .exe file to the startup folder
   1. Press `Win + R`
   2. Enter `shell:startup`
   3. Add a link to the .exe file from the startup directory

## Configuration
Add your text by editing the CLI arguments in the shortcut.  
The first argument is the title of the watermark.
The second argument is the body of the watermark.

The second CLI arg can contain arguments that will be replaced with the appropriate text.
The arguments are enclosed in curly braces.

## Arguments
These arguments only work in the body (second CLI arg)
`{MACHINENAME}` Machine Name
`{USERNAME}` Username
`{USERDNAME}` User Domain Name
`{PROCESSORCOUNT}` Number of Processors in the Computer
`{email@email.com}` Makes clickable to send email
`{TIME}` displays current time is hh:mm:ss AM/PM format (This will increase power usage)
`{brown}` sets body colour. Colours include black, white, red, green, brown.
`{tblack}` sets title colour. Colours include black, white, red, green, brown.

## Examples
```
...\Watermark.exe" "Organization Name" "If you need support email {support@email.com}" "Your computer name is {MACHINENAME}"
...\Watermark.exe" "The time is" "{TIME}"
...\Watermark.exe" "You are logged in as" "{USERNAME}
```