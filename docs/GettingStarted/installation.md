{'tags': ['installing', 'downloading', 'dependencies', 'requirements', 'compiling', 'voiceattack', 'voicemacro', 'source', 'github', 'getting', 'started'], 'status': 1}

# Download and installation

## 01Compiled code

EliteAPI is distributed under the [GNU General Public License v3.0](https://github.com/EliteAPI/EliteAPI/blob/master/LICENSE).

The compiled EliteAPI.dll file can be downloaded from the [EliteAPI GitHub releases page](https://github.com/EliteAPI/EliteAPI/releases). This library needs to be referenced in your .NET project.

EliteAPI can also be found on NuGet under the name `EliteAPI`.

<div class="console"><span class="icon">$</span><span class="platform">NuGet package manager</span><span class="text">Install-Package EliteAPI</span></div>
<div class="console"><span class="icon">$</span><span class="platform">NuGet .NET CLI</span><span class="text">dotnet add package EliteAPI</span></div>

## 02VoiceAttack & VoiceMacro

The setup files for the VoiceAttack and VoiceMacro plugins can be found on the [EliteAPI GitHub releases page](https://github.com/EliteAPI/EliteAPI/releases).

### VoiceAttack

Make sure the correct installation folder is selected. This should be a new folder in the Apps directory of the VoiceAttack installation.

Example: `C:\Program Files (x86)\VoiceAttack\Apps\EliteAPI`.

### VoiceMacro

Make sure the correct installation folder is selected. This should the Plugins folder in the VoiceMacro installation directory.

Example: `C:\Program Files (x86)\VoiceMacro\Plugins`.

Please note that EliteAPI is only supported on VoiceMacro `>= v1.3.0.11`.

## 03Source code

EliteAPI runs on .NET Standard 2.0.

The EliteAPI source code is hosted on the [EliteAPI GitHub repository](https://github.com/EliteAPI/EliteAPI) and can be downloaded [here](https://github.com/EliteAPI/EliteAPI/archive/master.zip) or cloned via Git. The source code can be compiled in Visual Studio to retrieve the EliteAPI.dll file.

<div class="console"><span class="icon">$</span><span class="platform">Git</span><span class="text">git clone https://github.com/EliteAPI/EliteAPI.git</span></div>

## 04Dependencies

EliteAPI needs a few dependencies to be installed before being able to compile.

<div class="dependencies">
<a href="https://www.nuget.org/packages/Costura.Fody/" class="dependency">Costura.Fody <span class="version">&gt;= 4.1.0</span></a><a href="https://www.nuget.org/packages/ini-parser/" class="dependency">ini-parser <span class="version">&gt;= 2.5.2</span></a><a href="https://www.nuget.org/packages/Microsoft.CSharp/" class="dependency">Microsoft.CSharp <span class="version">&gt;= 4.7.0</span></a><a href="https://www.nuget.org/packages/Newtonsoft.Json/" class="dependency">Newtonsoft.Json <span class="version">&gt;= 12.0.3</span></a><a href="https://www.nuget.org/packages/Somfic/" class="dependency">Somfic <span class="version">&gt;= 1.1.3</span></a><a class="dependency" href="https://www.nuget.org/packages/System.ComponentModel.Annotations/">System.ComponentModel.Annotations <span class="version">&gt;= 4.7.0</span></a></div>