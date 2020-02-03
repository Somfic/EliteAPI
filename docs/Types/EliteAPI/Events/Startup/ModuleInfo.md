{"tags":["ModuleInfo","EliteAPI","Events","Startup","Slot","Item","On","Priority","Health","Value","AmmoInClip","AmmoInHopper","EngineeringInfo"],"status":1}

# ModuleInfo

## 01 Definition

Namespace: <span class='code'>EliteAPI.Events.Startup</span>

Inheritance: <span class='code'>Object</span> → <span class='code'>[ModuleInfo](../../../EliteAPI/Events/Startup/ModuleInfo.html)</span>



An installed item on the ship.



## 02 Properties

### <span class='code'>String</span> Slot



The name of the slot.



### <span class='code'>String</span> Item



The name of the module in this slow in lowercase.



### <span class='code'>Boolean</span> On



Whether this module is turned on.



### <span class='code'>Int32</span> Priority



The priority group of power for this module.



### <span class='code'>Single</span> Health



The health of the module.



### <span class='code'>Nullable`1</span> Value



The value of the module.



### <span class='code'>Nullable`1</span> AmmoInClip



Amount of ammunition in the clip.

Can also be amount of places in a passenger cabin.



### <span class='code'>Nullable`1</span> AmmoInHopper



The amount of ammunition in the hopper.



### <span class='code'>[EngineeringInfo](../../../EliteAPI/Events/Startup/EngineeringInfo.html)</span> EngineeringInfo



The engineering that has been done on this module.



