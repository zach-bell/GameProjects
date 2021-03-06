; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{34783FE4-71A8-41EC-B625-60CF8764B768}
AppName=Pacman Game Thing
AppVersion=1.0
;AppVerName=Pacman Game Thing 1.0
AppPublisher=Just a guy software
AppPublisherURL=https://nerdist.com/wp-content/uploads/2014/11/111014_TysonTweet_FEAT.jpg
AppSupportURL=https://nerdist.com/wp-content/uploads/2014/11/111014_TysonTweet_FEAT.jpg
AppUpdatesURL=https://nerdist.com/wp-content/uploads/2014/11/111014_TysonTweet_FEAT.jpg
DefaultDirName=\Pacman Game Thing
DefaultGroupName=Pacman Game Thing
AllowNoIcons=yes
OutputBaseFilename=Pacman_setup_file
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "F:\User\Documents\school\School SPRINGS\spring 2018\CS 487\GameProjects\Builds\Pacman\Pacman_Installer_v1.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "F:\User\Documents\school\School SPRINGS\spring 2018\CS 487\GameProjects\Builds\Pacman\UnityPlayer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "F:\User\Documents\school\School SPRINGS\spring 2018\CS 487\GameProjects\Builds\Pacman\Pacman_Installer_v1_Data\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\Pacman Game Thing"; Filename: "{app}\Pacman_Installer_v1.exe"
Name: "{commondesktop}\Pacman Game Thing"; Filename: "{app}\Pacman_Installer_v1.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\Pacman_Installer_v1.exe"; Description: "{cm:LaunchProgram,Pacman Game Thing}"; Flags: nowait postinstall skipifsilent

