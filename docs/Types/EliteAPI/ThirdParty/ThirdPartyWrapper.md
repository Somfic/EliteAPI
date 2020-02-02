{"tags":["ThirdPartyWrapper","EliteAPI","ThirdParty","GetVariables","GetRichPresenceSetting","GetEventVariables","GetEventName","GetIni","GetJournalFolder","GetLogFolder","ProcessCall"],"status":1}

# ThirdPartyWrapper

## 01 Definition

Namespace: <span class='code'>EliteAPI.ThirdParty</span>

Inheritance: <span class='code'>Object</span> → <span class='code'>[ThirdPartyWrapper](../../EliteAPI/ThirdParty/ThirdPartyWrapper.html)</span>



Class that functions as a wrapper for third party plugins.



## 02 Constructors

### <span class='code'>[ThirdPartyWrapper](../../EliteAPI/ThirdParty/ThirdPartyWrapper.html)</span> (<span class='code'>[EliteDangerousAPI](../EliteAPI/EliteDangerousAPI.html)</span> api, <span class='code'>String</span> name, <span class='code'>String</span> iniPath)



Creates a new ThirdPartyWrapper object.



## 03 Methods

### <span class='code'>List<[Variable](../../EliteAPI/ThirdParty/Variable.html)></span> GetVariables ()



Returns all the variables to be set.



### <span class='code'>Boolean</span> GetRichPresenceSetting ()



Returns a value whether the API should automatically start the Discord Rich Presence.



### <span class='code'>List<[Variable](../../EliteAPI/ThirdParty/Variable.html)></span> GetEventVariables (<span class='code'>Object</span> e)



Gets all the variables to be set from an event.



### <span class='code'>String</span> GetEventName (<span class='code'>Object</span> e)



Gets the name from an event.



### <span class='code'>DirectoryInfo</span> GetJournalFolder ()



Gets the journal directory from the configuration file.



### <span class='code'>DirectoryInfo</span> GetLogFolder ()



Gets the log directory from the configuration file.



### <span class='code'>Void</span> ProcessCall (<span class='code'>String</span> content)



Processes third party plugin functions



