{"tags":["IEliteDangerousAPI","EliteAPI","Reset","Start","Stop","ChangeJournal","Version","IsRunning","JournalDirectory","SkipCatchUp","Events","Logger","Status","Cargo","Modules","Bindings","Commander","Location","DiscordRichPresence","OnError","OnQuit","OnReady"],"status":1}

# IEliteDangerousAPI

## 01 Definition

Namespace: `EliteAPI`

Inheritance: `IEliteDangerousAPI`



Interface for the EliteDangerousAPI class.



## 02 Properties

### `String` Version



Set to true when the API is ready.



### `Boolean` IsRunning



Whether the API is currently running.



### `DirectoryInfo` JournalDirectory



The Journal directory that is being used by the API.



### `Boolean` SkipCatchUp



Whether the API should skip the processing of previous events before the API was started.



### `EventHandler` Events



Object that holds all the events.



### `Logger` Logger



Objects that holds all logging related functions.



### `GameStatus` Status



Holds the ship's current status.



### `ShipCargo` Cargo



Holds the ship's current cargo situation.



### `ShipModules` Modules



Returns all the modules installed on the current ship.



### `UserBindings` Bindings



Holds information on all key bindings in the game set by the user.



### `CommanderStatus` Commander



Holds information about the commander.



### `LocationStatus` Location



Holds information about the last known location of the commander.



### `RichPresenceClient` DiscordRichPresence



Rich presence service for Discord.



## 03 Methods

### `Void` Reset ()



Resets the API.



### `Void` Start (`Boolean` runRichPresence)



Starts the API.



### `Void` Stop ()



Stops the API.



### `Void` ChangeJournal (`DirectoryInfo` newJournalDirectory)



Changes the journal directory.



## 04 Events

### `EventHandler`1<Tuple`2>` OnError



Gets triggered when EliteAPI could not successfully load up.



### `EventHandler<EventArgs>` OnQuit



Gets triggered when EliteAPI is closing.



### `EventHandler<EventArgs>` OnReady



Gets triggered when EliteAPI has successfully loaded up.



