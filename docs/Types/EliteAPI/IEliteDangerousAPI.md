{"tags":["IEliteDangerousAPI","EliteAPI","Reset","Start","Stop","ChangeJournal","IsRunning","JournalDirectory","SkipCatchUp","Events","Logger","Status","Cargo","Modules","Bindings","Commander","Location","DiscordRichPresence","OnError","OnQuit","OnReady"],"status":1}

# IEliteDangerousAPI

## 01 Definition

Namespace: <span class='code'>EliteAPI</span>

Inheritance: <span class='code'>[IEliteDangerousAPI](../EliteAPI/IEliteDangerousAPI.html)</span>



Interface for the EliteDangerousAPI class.



## 02 Properties

### <span class='code'>Boolean</span> IsRunning



Whether the API is currently running.



### <span class='code'>DirectoryInfo</span> JournalDirectory



The Journal directory that is being used by the API.



### <span class='code'>Boolean</span> SkipCatchUp



Whether the API should skip the processing of previous events before the API was started.



### <span class='code'>[EventHandler](../../EliteAPI/Events/EventHandler.html)</span> Events



Object that holds all the events.



### <span class='code'>Logger</span> Logger



Objects that holds all logging related functions.



### <span class='code'>[GameStatus](../../EliteAPI/Status/GameStatus.html)</span> Status



Holds the ship's current status.



### <span class='code'>[ShipCargo](../../EliteAPI/Status/ShipCargo.html)</span> Cargo



Holds the ship's current cargo situation.



### <span class='code'>[ShipModules](../../EliteAPI/Status/ShipModules.html)</span> Modules



Returns all the modules installed on the current ship.



### <span class='code'>[UserBindings](../../EliteAPI/Bindings/UserBindings.html)</span> Bindings



Holds information on all key bindings in the game set by the user.



### <span class='code'>[CommanderStatus](../../EliteAPI/Status/CommanderStatus.html)</span> Commander



Holds information about the commander.



### <span class='code'>[LocationStatus](../../EliteAPI/Status/LocationStatus.html)</span> Location



Holds information about the last known location of the commander.



### <span class='code'>[RichPresenceClient](../../EliteAPI/Discord/RichPresenceClient.html)</span> DiscordRichPresence



Rich presence service for Discord.



## 03 Methods

### <span class='code'>Void</span> Reset ()



Resets the API.



### <span class='code'>Void</span> Start (<span class='code'>Boolean</span> runRichPresence)



Starts the API.



### <span class='code'>Void</span> Stop ()



Stops the API.



### <span class='code'>Void</span> ChangeJournal (<span class='code'>DirectoryInfo</span> newJournalDirectory)



Changes the journal directory.



## 04 Events

### <span class='code'>EventHandler`1<Tuple`2></span> OnError



Gets triggered when EliteAPI could not successfully load up.



### <span class='code'>EventHandler<EventArgs></span> OnQuit



Gets triggered when EliteAPI is closing.



### <span class='code'>EventHandler<EventArgs></span> OnReady



Gets triggered when EliteAPI has successfully loaded up.



