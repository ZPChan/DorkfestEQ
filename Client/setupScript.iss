; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "DorkfestEQ"
#define MyAppVersion "1.1"
#define MyAppPublisher "dorkfest"
#define MyAppExeName "eqgame.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{35D0B5BD-4FF8-4277-AB0A-2EA97464B7FE}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autoappdata}\{#MyAppName}
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
PrivilegesRequired=lowest
OutputBaseFilename=DorkfestEQSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern
DiskSpanning=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "EQFolder\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs
Source: "dxwebsetup.exe"; DestDir: "{app}"

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Parameters: "patchme"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Parameters: "patchme"; Tasks: desktopicon

[Run]
Filename: "{app}\dxwebsetup.exe"; Parameters: "/Q"; StatusMsg: "Installing legacy DirectX..."; Flags: runasoriginaluser
