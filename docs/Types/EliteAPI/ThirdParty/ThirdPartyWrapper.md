{"tags":["ThirdPartyWrapper","EliteAPI","ThirdParty","GetVariables","GetRichPresenceSetting","GetEventVariables","GetEventName","GetIni","GetJournalFolder","GetLogFolder","ProcessCall"],"status":1}

# ThirdPartyWrapper

## 01 Definition

Namespace: `EliteAPI.ThirdParty`

Inheritance: `Object` → `ThirdPartyWrapper`



Class that functions as a wrapper for third party plugins.



## 02 Constructors

### `ThirdPartyWrapper` (`EliteDangerousAPI` api, `String` name, `String` iniPath)



Creates a new ThirdPartyWrapper object.



## 03 Methods

### `List`1` GetVariables ()



Returns all the variables to be set.



### `Boolean` GetRichPresenceSetting ()



Returns a value whether the API should automatically start the Discord Rich Presence.



### `List`1` GetEventVariables (`Object` e)



Gets all the variables to be set from an event.



### `String` GetEventName (`Object` e)



Gets the name from an event.



### `DirectoryInfo` GetJournalFolder ()



Gets the journal directory from the configuration file.



### `DirectoryInfo` GetLogFolder ()



Gets the log directory from the configuration file.



### `Void` ProcessCall (`String` content)



Processes third party plugin functions



