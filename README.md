<img src="https://i.imgur.com/keDXwjY.png" align="right"
     title="EliteAPI by Somfic" width="280" height="280">
# EliteAPI
A powerful event based API for [Elite: Dangerous](https://www.elitedangerous.com/) that hooks into the [Player Journal](http://edcodex.info/?m=doc). Created by CMDR [Somfic](https://github.com/Somfic).

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/480f394b3d044412afb33351120253f9)](https://app.codacy.com/app/EliteAPI/EliteAPI?utm_source=github.com&utm_medium=referral&utm_content=Somfic/EliteAPI&utm_campaign=Badge_Grade_Dashboard) [![Discord](https://img.shields.io/discord/498422961297031168.svg)](https://discord.gg/jwpFUPZ) [![GitHub issues](https://img.shields.io/github/issues/EliteAPI/EliteAPI.svg)](https://github.com/EliteAPI/EliteAPI/issues) [![GitHub forks](https://img.shields.io/github/forks/EliteAPI/EliteAPI.svg)](https://github.com/EliteAPI/EliteAPI/network) [![GitHub stars](https://img.shields.io/github/stars/EliteAPI/EliteAPI.svg)](https://github.com/EliteAPI/EliteAPI/stargazers) [![GitHub license](https://img.shields.io/github/license/EliteAPI/EliteAPI.svg)](https://github.com/EliteAPI/EliteAPI/blob/master/LICENSE)

[![Nuget](https://img.shields.io/nuget/v/EliteAPI.svg)](https://www.nuget.org/packages/EliteAPI/) [![GitHub tag](https://img.shields.io/github/tag/EliteAPI/EliteAPI.svg)](https://github.com/EliteAPI/EliteAPI/releases) [![GitHub last commit](https://img.shields.io/github/last-commit/EliteAPI/EliteAPI.svg)](https://github.com/EliteAPI/EliteAPI/commits/master) [![GitHub Release Date](https://img.shields.io/github/release-date/EliteAPI/EliteAPI.svg)](https://github.com/EliteAPI/EliteAPI/releases) [![NuGet](https://img.shields.io/nuget/dt/EliteAPI.svg)](https://www.nuget.org/packages/EliteAPI/)

Join the [Discord](https://discord.gg/jwpFUPZ), or contact me personally: Somfic#9987

# Getting started

## Prerequisites
```
Visual studio
Elite: Dangerous (PC)
```

## Installing
You can install this library in a number of different ways.

##### Nuget
Use the nuget package manager console.

```Install-Package EliteAPI```

##### Nuget package manager
Available in the nuget package manager via Visual Studio. 
Simply search for ***EliteAPI***.

##### Github
You can find the latest release [here](https://github.com/EliteAPI/EliteAPI/releases). 
Download the .dll file and reference it to your Visual Studio project.

## API examples
The API works with the .NET language C#.

### Message on docking
Now to the fun part. Make sure you've ran Elite: Dangerous at least once before continuing.

First, add the namespace to your class.
```csharp
using EliteAPI;
```
Then create a new `EliteDangerousAPI` object.
```csharp
EliteDangerousAPI EliteAPI = new EliteDangerousAPI();
```
Since `EliteDangerousAPI` needs a reference to the directory that contains the PlayerJournals, we have to pass it a `DirectoryInfo` object. Usually, the Player Journal folder is located in `C:\Users\%username%\Saved Games\Frontier Developments\Elite Dangerous`.
```csharp
DirectoryInfo playerJournalFolder = new DirectoryInfo(
$@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous");

EliteDangerousAPI EliteAPI = new EliteDangerousAPI( playerJournalFolder );
```
Now that we are hooked to the API, we can setup the events that we want to get information about. Let's say we want to know when the player docks at a station. Simply hook into its event and create a method for it. After that start the API.
```csharp
DirectoryInfo playerJournalFolder = new DirectoryInfo(
$@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous");

EliteDangerousAPI EliteAPI = new EliteDangerousAPI( playerJournalFolder );

EliteAPI.DockedEvent += EliteAPI_DockedEvent;

EliteAPI.Start();
```
```csharp
private static void EliteAPI_DockedEvent(object sender, DockedInfo e)
{
     //This method will be ran every time the player docks.
}
```
Now if you want to display the station's name for example, you can use the `DockedInfo` object.
```csharp
private static void EliteAPI_DockedEvent(object sender, DockedInfo e)
{
     //This method will be ran every time the player docks.
     Console.WriteLine($"Docked at {e.StationName}.");
}
```
### Check whether the landing gear is down
Again, we start with hooking into the API.
```csharp
DirectoryInfo playerJournalFolder = new DirectoryInfo(
$@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous");

EliteDangerousAPI EliteAPI = new EliteDangerousAPI( playerJournalFolder );

EliteAPI.Start();
```
Then, you can access the `EliteAPI.Status.LandingGear` field.
```csharp
switch (EliteAPI.Status.LandingGear) {
     case true:
          Console.WriteLine("The landing gear is down!");
          break;
          
     case false:
          Console.WriteLine("That gear ain't down, chief.");
          break;
}
```
Simple as that.

# EliteVA
EliteAPI is also a [VoiceAttack](http://voiceattack.com) plugin, called EliteVA.

##  Installation
Copy both `EliteVA.dll` **and** `Newtonsoft.Json.dll` to your VoiceAttack Apps directory. Usually, you can find that directory at these locations: 

Usual installation: `C:\Program Files (x86)\VoiceAttack\Apps`

Steam installation: `C:\Program Files (x86)\Steam\steamapps\common\VoiceAttack\Apps` 

**_Make sure you create a new folder in the Apps folder, you can name it anything, otherwise the plugin will not be detected by VA!_**

You'll also have to Enable Plugin Support in VoiceAttack in order for plugins to be, well, supported. After having enabled this option, you have to restart VoiceAttack.

After having enabled EliteVA, you should see the text `Plugin 'EliteAPI' initialized.` together with a blue dot.

## Usage
VoiceAttack uses variables in the form of [tokens](https://forum.voiceattack.com/smf/index.php?topic=31.0). EliteVA enables you to use a number of tokens. You can find a full list on the [EliteVA Wiki]().

### Example: check whether we're mass locked before jumping
Let's say the Commander wants to jump to another system, after having undocked from a station. We could just have VoiceAttack press the `J` key and let the game display the error message, or, we can take matters in our own hands.

To create a new command, press on the **edit profile** button, and then tap **new command**. 

Then, at *when I say*, type something like `charge frameshiftdrive`. 

Navigate to `Other >` > `Advanced >` > `Execute an External Plugin Function`. Select EliteAPI, and press `OK`, this part of the command updates the data and loads it in VoiceAttack.  

Click on `Other >` > `Advanced >` > `Begin a Conditional (If Statement) Block > ` > `Single Condition`. Now, you should be in the *True/False (Boolean)* tab, if you're not, navigate to that tab.

Enter `{EliteAPI.MASSLOCKED}` at Variable Name, and make sure you've `A Value` and `False` selected. Press `OK`.

Finally, we can add the pressing `J` (or whatever your keybinding for jumping is) part. Go to `Key Press`, record your key, and press `OK`.

Okay, now everything should be set up. This command updates the values, then checks whether we're massed locked by checking the value called `EliteAPI.MASSLOCKED`, and if we're not, it will press our jumping key.

Now head out into the void and test it out!

# FAQ
### **Can it be used on PS4 / XBOX?**
No. There are currently no plans to add support for these platforms either.

### **What can this be used for?**
You can link this to a number of things, like Discord's rich presence feature or a jump tracker.
