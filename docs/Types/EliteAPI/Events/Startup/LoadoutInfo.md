{"tags":["LoadoutInfo","EliteAPI","Events","Startup","Ship","ShipId","ShipName","ShipIdent","HullValue","ModulesValue","HullHealth","UnladenMass","FuelCapacity","CargoCapacity","MaxJumpRange","Rebuy","Hot","Modules","Timestamp","Event"],"status":1}

# LoadoutInfo

## 01 Definition

Namespace: <span class='code'>EliteAPI.Events.Startup</span>

Inheritance: <span class='code'>Object</span> → <span class='code'>[EventBase](../../EliteAPI/Events/EventBase.html)</span> → <span class='code'>[LoadoutInfo](../../../EliteAPI/Events/Startup/LoadoutInfo.html)</span>



This event is written when the game has started, after switching ships, after outfitting, and after docking a SRV.



## 02 Properties

### <span class='code'>String</span> Ship



The type of ship.



### <span class='code'>Int64</span> ShipId



The id of the ship.



### <span class='code'>String</span> ShipName



The user-defined name of the ship.



### <span class='code'>String</span> ShipIdent



The user-defined id of the ship.



### <span class='code'>Int64</span> HullValue



The value of the integrity of the hull.



### <span class='code'>Int64</span> ModulesValue



The value of the integrity of the modules.



### <span class='code'>Single</span> HullHealth



The health of the hull.



### <span class='code'>Int32</span> UnladenMass



The mass of the hull and all modules. Fuel and cargo are not included.



### <span class='code'>[FuelInfo](../../../EliteAPI/Events/Startup/FuelInfo.html)</span> FuelCapacity



Information on the fuel of the ship.



### <span class='code'>Int32</span> CargoCapacity



The maximum amount of cargo this ship can carry.



### <span class='code'>Single</span> MaxJumpRange



The maximum jump range of the ship.





This value is based on no cargo and limited fuel.



### <span class='code'>Int64</span> Rebuy



The cost of rebuy.



### <span class='code'>Boolean</span> Hot



Whether the ship is wanted.



### <span class='code'>IReadOnlyList`1</span> Modules



A list of installed items on the ship.



### <span class='code'>DateTime</span> Timestamp

### <span class='code'>String</span> Event

