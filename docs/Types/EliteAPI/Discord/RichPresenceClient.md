{"tags":["RichPresenceClient","EliteAPI","Discord","WithCustomID","UpdatePresence","TurnOn","TurnOff","IsRunning","IsReady"],"status":1}

# RichPresenceClient

## 01 Definition

Namespace: <span class='code'>EliteAPI.Discord</span>

Inheritance: <span class='code'>Object</span> → <span class='code'>[RichPresenceClient](../../EliteAPI/Discord/RichPresenceClient.html)</span>

## 02 Constructors

### <span class='code'>[RichPresenceClient](../../EliteAPI/Discord/RichPresenceClient.html)</span> (<span class='code'>[EliteDangerousAPI](../EliteAPI/EliteDangerousAPI.html)</span> api)



Creates a new Discord Rich Presence client based on the EliteDangerousAPI object.



### <span class='code'>[RichPresenceClient](../../EliteAPI/Discord/RichPresenceClient.html)</span> (<span class='code'>[EliteDangerousAPI](../EliteAPI/EliteDangerousAPI.html)</span> api, <span class='code'>String</span> rpcID)



Creates a new Discord Rich Presence client based on the EliteDangerousAPI object, with a custom RPC ID, for when you have your own Rich Presence registered with Discord.



## 03 Properties

### <span class='code'>Boolean</span> IsRunning



Whether the rich presence is running.



### <span class='code'>Boolean</span> IsReady



Whether the rich presence is connected and ready.



## 04 Methods

### <span class='code'>[RichPresenceClient](../../EliteAPI/Discord/RichPresenceClient.html)</span> WithCustomID (<span class='code'>String</span> id)



Set a custom ID to be used, for when you have your own RPC registered with Discord.



### <span class='code'>[RichPresenceClient](../../EliteAPI/Discord/RichPresenceClient.html)</span> UpdatePresence (<span class='code'>[RichPresence](../../EliteAPI/Discord/RichPresence.html)</span> presence)



Update the rich presence.



### <span class='code'>[RichPresenceClient](../../EliteAPI/Discord/RichPresenceClient.html)</span> TurnOn (<span class='code'>Boolean</span> automatic)



Turn the rich presence on.



### <span class='code'>[RichPresenceClient](../../EliteAPI/Discord/RichPresenceClient.html)</span> TurnOff ()



Turn the rich presence off.



