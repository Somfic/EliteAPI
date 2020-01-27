{"tags":["RichPresenceClient","EliteAPI","Discord","WithCustomID","UpdatePresence","TurnOn","TurnOff","IsRunning","IsReady"],"status":1}

# RichPresenceClient

## 01 Definition

Namespace: `EliteAPI.Discord`

Inheritance: `Object` → `RichPresenceClient`

## 02 Constructors

### `RichPresenceClient` (`EliteDangerousAPI` api)



Creates a new Discord Rich Presence client based on the EliteDangerousAPI object.



### `RichPresenceClient` (`EliteDangerousAPI` api, `String` rpcID)



Creates a new Discord Rich Presence client based on the EliteDangerousAPI object, with a custom RPC ID, for when you have your own Rich Presence registered with Discord.



## 03 Properties

### `Boolean` IsRunning



Whether the rich presence is running.



### `Boolean` IsReady



Whether the rich presence is connected and ready.



## 04 Methods

### `RichPresenceClient` WithCustomID (`String` id)



Set a custom ID to be used, for when you have your own RPC registered with Discord.



### `RichPresenceClient` UpdatePresence (`RichPresence` presence)



Update the rich presence.



### `RichPresenceClient` TurnOn (`Boolean` automatic)



Turn the rich presence on.



### `RichPresenceClient` TurnOff ()



Turn the rich presence off.



