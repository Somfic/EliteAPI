{'tags': ['voiceattack', 'plugin', 'third party', 'eliteva', 'events', 'variables', 'version', 'commander', 'credits', 'empireranklocalised', 'empirerankprogress', 'federationranklocalised', 'federationrankprogress', 'combatranklocalised', 'combatrankprogress', 'traderanklocalised', 'traderankprogress', 'explorationranklocalised', 'explorationrankprogress', 'cqcrank', 'starsystem', 'bodytype','station','pips.systems', 'pips.engines', 'pips.weapons', 'pips.hardpoints', 'pips.shields', 'cargo', 'landed', 'gear', 'shields', 'supercruise', 'flightassist', 'hardpoints', 'winging', 'lights', 'cargoscoop', 'silentrunning', 'scooping', 'srvhandbreak', 'srvturrent', 'srvnearship', 'srvdriveassist', 'masslocked', 'fsdcharging', 'fsdcooldown', 'lowfuel', 'overheating', 'haslatlong', 'indanger', 'ininterdiction', 'inmothership', 'infighter', 'insrv', 'analysismode', 'nightvision', 'gamemode', 'innofirezone', 'jumprange', 'isrunning', 'inmainmenu', 'musictrack'], 'status': 1}

# EliteVA

## 01 Installation

The EliteVA setup file can be downloaded on the [EliteAPI GitHub releases page](https://github.com/EliteAPI/EliteAPI/releases). Make sure the correct installation folder is selected. This should be a new folder in the Apps directory of the VoiceAttack installation.

Example: `C:\Program Files (x86)\VoiceAttack\Apps\EliteAPI`.

## 02 Variables

EliteVA uses a the `EliteAPI` prefix for all variables in VoiceAttack in order to be compatible with other plugins. The standard syntax for all variables in EliteVA is as follows: `EliteAPI.(Event).[Name]` (*() = optional, [] = required*).

There are two types of variables EliteVA uses to convey information: Status and Event variables.

### Status variables

Status variables are updated live and cover the ship's status, such as the status of the landing gear, mass lock and much more. All of these variables follow the following syntax: `EliteAPI.[Name]`.

Here follows a list of all the available status variables.

#### `Text` EliteAPI.Version

This EliteAPI version.

Example: `2.3.0.0`.

#### `Text` EliteAPI.Commander

The name of the current commander.

Example: `Somfic`.

#### `Int` EliteAPI.Credits

The amount of credits the commander has.

Example: `524616641`.

#### `Int` EliteAPI.EmpireRank

The commander's current rank within the Empire faction. Goes from 0 - 12.

Example: `12`.

#### `Text` EliteAPI.EmpireRankLocalised

The commander's current rank within the Empire faction as the title.

Example: `Duke`.

#### `Int` EliteAPI.EmpireRankProgress

The percentage of progress the commander has in the Empire faction. Goes from 0 - 100.

Example: `73`.

#### `Int` EliteAPI.FederationRank

The commander's current rank within the Federation faction. Goes from 0 - 12.

Example: `7`.

#### `Text` EliteAPI.FederationRankLocalised

The commander's current rank within the Federation faction as the title.

Example: `Ensign`.

#### `Int` EliteAPI.FederationRankProgress

The percentage of progress the commander has in the Federation faction. Goes from 0 - 100.

Example: `73`.

#### `Int` EliteAPI.CombatRank

The commander's current rank for combat. Goes from 0 - 8.

Example: `5`.

#### `Text` EliteAPI.CombatRankLocalised

The commander's current rank for combat as the title.

Example: `Master`.

#### `Int` EliteAPI.CombatRankProgress

The percentage of progress the commander has in the combat rank. Goes from 0 - 100.

Example: `81`.

#### `Int` EliteAPI.TradeRank

The commander's current rank for trade. Goes from 0 - 8.

Example: `8`.

#### `Text` EliteAPI.TradeRankLocalised

The commander's current rank for trade as the title.

Example: `Elite`.

#### `Int` EliteAPI.TradeRankProgress

The percentage of progress the commander has in the trade rank. Goes from 0 - 100.

Example: `100`.

#### `Int` EliteAPI.ExplorationRank

The commander's current rank for exploration. Goes from 0 - 8.

Example: `6`.

#### `Text` EliteAPI.ExplorationRankLocalised

The commander's current rank for exploration as the title.

Example: `Ranger`.

#### `Int` EliteAPI.ExplorationRankProgress

The percentage of progress the commander has in the exploration rank. Goes from 0 - 100.

Example: `50`.

#### `Int` EliteAPI.CqcRank

The commander's current rank for CQC. Goes from 0 - 8.

Example: `0`.

#### `Text` EliteAPI.StarSystem

The last known and often current star system the commander is traveling through.

Example: `Shinrarta Dezhra`.

#### `Text` EliteAPI.Body

The last known body the commander is traveling near. Can be a station, star, ring, or planet.

Example: `Jameson Memorial`.
Example: `Fusang A1`.

#### `Text` EliteAPI.BodyType

The type of `EliteAPI.Body`. Can be 'Station', 'Star', 'Planet' or 'Ring'.

Example: `Station`.
Example: `Planet`.

#### `Text` EliteAPI.Station

The name of the last known station the commander has visited.

Example: `Jameson Memorial`.

#### `Int` EliteAPI.Pips.Systems

The amount of pips set to the systems subsystem. Goes from 0 - 12.

Example: `4`.

#### `Int` EliteAPI.Pips.Engines

The amount of pips set to the engines subsystem. Goes from 0 - 12.

Example: `6`.

#### `Int` EliteAPI.Pips.Weapons

The amount of pips set to the weapons subsystem. Goes from 0 - 12.

Example: `2`.

#### `Int` EliteAPI.Cargo

The amount of tonnes of cargo currently aboard the ship.

Example: `36`.

#### `Bool` EliteAPI.Docked

Whether the ship is currently docked at a station. Still returns false when landed on a planet.

Example: `False`.

#### `Bool` EliteAPI.Landed

Whether the ship is currently landed on a planet. Still returns false when docked at a station.

Example: `True`.

#### `Bool` EliteAPI.Gear

Returns true when the landing gear is deployed, false when the gear is retracted.

Example: `True`.

#### `Bool` EliteAPI.Shields

Returns the current state of the shields. True means online, false means offline.

Example: `True`.

#### `Bool` EliteAPI.Supercruise

Whether or not the ship is currently in supercruise.

Example: `False`.

#### `Bool` EliteAPI.FlightAssist

If flight assist is enabled, this returns true.

Example: `False`.

#### `Bool` EliteAPI.Hardpoints

Returns true when the weapons are deployed.

Example: `False`.

#### `Bool` EliteAPI.Winging

If the commander is in a wing, this will return true.

Example: `True`.

#### `Bool` EliteAPI.Lights

Whether the ship's lights are currently in use.

Example: `True`.

#### `Bool` EliteAPI.CargoScoop

Returns whether or not the cargo scoop is currently deployed.

Example: `False`.

#### `Bool` EliteAPI.SilentRunning

Whether the silent running mode is currently in use.

Example: `False`.

#### `Bool` EliteAPI.Scooping

Returns true when the ship is refuelling from a star.

Example: `False`.

#### `Bool` EliteAPI.SrvHandbreak

Whether the SRV's handbrake is enabled

Example: `True`.

#### `Bool` EliteAPI.SrvTurrent

Whether the SRV's turrent is currently in use.

Example: `True`.

#### `Bool` EliteAPI.SrvNearShip

Whether the SRV is near it's ship. The turrent will not be able to be deployed when this returns true.

Example: `True`.

#### `Bool` EliteAPI.SrvDriveAssist

Returns true when the SRV drive assist mode is enabled.

Example: `False`.

#### `Bool` EliteAPI.MassLocked

Whether the ship is currently under mass lock. The ship will not be able to jump or enter supercruise while under mass lock.

Example: `False`.

#### `Bool` EliteAPI.FsdCharging

Returns true when the frameshift drive is charging for a hop or when entering supercruise.

Example: `True`.

#### `Bool` EliteAPI.FsdCooldown

Whether the frameshift drive is currently cooling down from a jump or cruise. The commander will not be able to use the frameshift drive while this is true.

Example: `False`.

#### `Bool` EliteAPI.LowFuel

Returns true when the ship is low on fuel.

Example: `True`.

#### `Bool` EliteAPI.Overheating

When the ship is overheating this will return true.

Example: `True`.

#### `Bool` EliteAPI.HasLatlong

(?)

Example: `True`.

#### `Bool` EliteAPI.InDanger

Whether or not the ship is in danger. This could be from overheating or an attack.

Example: `False`.

#### `Bool` EliteAPI.InInterdiction

This will return true when the commander is being interdicted. This does not return true when the commander initiated the interdiction.

Example: `True`.

#### `Bool` EliteAPI.InMothership

This will return false when the commander is in a SRV or Fighter.

Example: `False`.

#### `Bool` EliteAPI.InFighter

Returns true when the commander is piloting a fighter ship.

Example: `True`.

#### `Bool` EliteAPI.InSRV

Returns true when the commander is driving a SRV.

Example: `True`.

#### `Bool` EliteAPI.AnalysisMode

Whether analysis mode is currently enabled.

Example: `False`.

#### `Bool` EliteAPI.NightVision

Returns true when night vision mode is enabled.

Example: `True`.

#### `Text` EliteAPI.GameMode

Returns the commander's game mode. Could be solo or open.

Example: `Solo`.

#### `Bool` EliteAPI.InNoFireZone

Returns true when the commander is within range of a station's no-fire zone.

Example: `False`.

#### `Decimal` EliteAPI.JumpRange

The ship's maximum jump range.
**This might not work as intended yet.**

Example: `25.4`.

#### `Bool` EliteAPI.IsRunning

Whether EliteVA is currently running. Almost always returns true.

Example: `True`.

#### `Bool` EliteAPI.InMainMenu

Whether the commander is in the main menu.

Example: `False`.

#### `Text` EliteAPI.MusicTrack

Returns the name of the music currently being played. Can serve as an indication of the current activity of the commander.

Example: `Exploration`.