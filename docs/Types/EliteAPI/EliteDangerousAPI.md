{"tags":["EliteDangerousAPI","EliteAPI","Reset","Start","ChangeJournal","Stop","IsReady","StandardDirectory","Version","IsRunning","JournalDirectory","Events","Logger","Status","Cargo","Modules","Materials","Bindings","Commander","Location","DiscordRichPresence","SkipCatchUp","OnReady","OnQuit","OnError","OnLoad"],"status":1}

# EliteDangerousAPI

## 01 Definition

Namespace: <span class='code'>EliteAPI</span>

Inheritance: <span class='code'>Object</span> → <span class='code'>[EliteDangerousAPI](../EliteAPI/EliteDangerousAPI.html)</span>



Main EliteAPI class.



## 02 Constructors

### <span class='code'>[EliteDangerousAPI](../EliteAPI/EliteDangerousAPI.html)</span> ()



Creates a new EliteDangerousAPI object using the standard Journal directory.



### <span class='code'>[EliteDangerousAPI](../EliteAPI/EliteDangerousAPI.html)</span> (<span class='code'>DirectoryInfo</span> JournalDirectory)



Creates a new EliteDangerousAPI object.



### <span class='code'>[EliteDangerousAPI](../EliteAPI/EliteDangerousAPI.html)</span> (<span class='code'>Boolean</span> SkipCatchUp)



Creates a new EliteDangerousAPI object using the standard Journal directory.



### <span class='code'>[EliteDangerousAPI](../EliteAPI/EliteDangerousAPI.html)</span> (<span class='code'>DirectoryInfo</span> journalDirectory, <span class='code'>Boolean</span> skipCatchUp)



Creates a new EliteDangerousAPI object.



## 03 Properties

### <span class='code'>Boolean</span> IsReady



Set to true when the API is ready.



### <span class='code'>DirectoryInfo</span> StandardDirectory



The default directory of the Journal files <span class='code'>C:\Users\%username%\Saved Games\Frontier Developments\Elite Dangerous</span>.





If the default directory could not be returned, the current directory will be returned.



### <span class='code'>String</span> Version



This version of EliteAPI.



### <span class='code'>Boolean</span> IsRunning



Whether the API is currently running.



### <span class='code'>DirectoryInfo</span> JournalDirectory



The Journal directory that is EliteAPI is currently using.



### <span class='code'>[EventHandler](../../EliteAPI/Events/EventHandler.html)</span> Events



All of the EliteAPI events are stored in this object.



### <span class='code'>Logger</span> Logger



The logger using across the API.



### <span class='code'>[GameStatus](../../EliteAPI/Status/GameStatus.html)</span> Status



Holds the ship's live status.





Values like the landing gear and other variables are stored here.



### <span class='code'>[ShipCargo](../../EliteAPI/Status/ShipCargo.html)</span> Cargo



Holds information on the ship's current cargo situation.



### <span class='code'>[ShipModules](../../EliteAPI/Status/ShipModules.html)</span> Modules



Returns all the modules installed on the current ship.



### <span class='code'>[MaterialsInfo](../../EliteAPI/Events/MaterialsInfo.html)</span> Materials



Holds information on the ship's current materials situation.



### <span class='code'>[UserBindings](../../EliteAPI/Bindings/UserBindings.html)</span> Bindings



Holds information on all key bindings in the game set by the user.



### <span class='code'>[CommanderStatus](../../EliteAPI/Status/CommanderStatus.html)</span> Commander



Holds information about the commander.



### <span class='code'>[LocationStatus](../../EliteAPI/Status/LocationStatus.html)</span> Location



Holds information about the last known location of the commander.



### <span class='code'>[RichPresenceClient](../../EliteAPI/Discord/RichPresenceClient.html)</span> DiscordRichPresence



Rich presence service for Discord.



### <span class='code'>Boolean</span> SkipCatchUp



Whether the API should skip the processing of previous events before the API was started.



## 04 Methods

### <span class='code'>Void</span> Reset ()



Resets the API.



### <span class='code'>Void</span> Start (<span class='code'>Boolean</span> runRichPresence)



Starts the API.



### <span class='code'>Void</span> ChangeJournal (<span class='code'>DirectoryInfo</span> newJournalDirectory)



Changes the journal directory.



### <span class='code'>Void</span> Stop ()



Stops the API.



## 05 Events

### <span class='code'>EventHandler<EventArgs></span> OnReady



Gets triggered when EliteAPI has successfully loaded up.



### <span class='code'>EventHandler<EventArgs></span> OnQuit



Gets triggered when EliteAPI is closing.



### <span class='code'>EventHandler`1<Tuple`2></span> OnError



Gets triggered when EliteAPI could not successfully load up.



### <span class='code'>EventHandler`1<Tuple`2></span> OnLoad



Gets triggered when EliteAPI is starting up.



