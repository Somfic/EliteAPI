{"tags":["EliteDangerousAPI","EliteAPI","Reset","Start","ChangeJournal","Stop","IsReady","StandardDirectory","Version","IsRunning","JournalDirectory","Events","Logger","Status","Cargo","Modules","Materials","Bindings","Commander","Location","DiscordRichPresence","SkipCatchUp","OnReady","OnQuit","OnError","OnLoad"],"status":1}

# EliteDangerousAPI

## 01 Definition

Namespace: `EliteAPI`

Inheritance: `Object` → `EliteDangerousAPI`



Main EliteAPI class.



## 02 Constructors

### `EliteDangerousAPI` ()



Creates a new EliteDangerousAPI object using the standard Journal directory.



### `EliteDangerousAPI` (`DirectoryInfo` JournalDirectory)



Creates a new EliteDangerousAPI object.



### `EliteDangerousAPI` (`Boolean` SkipCatchUp)



Creates a new EliteDangerousAPI object using the standard Journal directory.



### `EliteDangerousAPI` (`DirectoryInfo` journalDirectory, `Boolean` skipCatchUp)



Creates a new EliteDangerousAPI object.



## 03 Properties

### `Boolean` IsReady



Set to true when the API is ready.



### `DirectoryInfo` StandardDirectory



The default directory of the Journal files `C:\Users\%username%\Saved Games\Frontier Developments\Elite Dangerous`.





If the default directory could not be returned, the current directory will be returned.



### `String` Version



This version of EliteAPI.



### `Boolean` IsRunning



Whether the API is currently running.



### `DirectoryInfo` JournalDirectory



The Journal directory that is EliteAPI is currently using.



### `EventHandler` Events



All of the EliteAPI events are stored in this object.



### `Logger` Logger



The logger using across the API.



### `GameStatus` Status



Holds the ship's live status.





Values like the landing gear and other variables are stored here.



### `ShipCargo` Cargo



Holds information on the ship's current cargo situation.



### `ShipModules` Modules



Returns all the modules installed on the current ship.



### `MaterialsInfo` Materials



Holds information on the ship's current materials situation.



### `UserBindings` Bindings



Holds information on all key bindings in the game set by the user.



### `CommanderStatus` Commander



Holds information about the commander.



### `LocationStatus` Location



Holds information about the last known location of the commander.



### `RichPresenceClient` DiscordRichPresence



Rich presence service for Discord.



### `Boolean` SkipCatchUp



Whether the API should skip the processing of previous events before the API was started.



## 04 Methods

### `Void` Reset ()



Resets the API.



### `Void` Start (`Boolean` runRichPresence)



Starts the API.



### `Void` ChangeJournal (`DirectoryInfo` newJournalDirectory)



Changes the journal directory.



### `Void` Stop ()



Stops the API.



## 05 Events

### `EventHandler<EventArgs>` OnReady



Gets triggered when EliteAPI has successfully loaded up.



### `EventHandler<EventArgs>` OnQuit



Gets triggered when EliteAPI is closing.



### `EventHandler`1<Tuple`2>` OnError



Gets triggered when EliteAPI could not successfully load up.



### `EventHandler`1<Tuple`2>` OnLoad



Gets triggered when EliteAPI is starting up.



