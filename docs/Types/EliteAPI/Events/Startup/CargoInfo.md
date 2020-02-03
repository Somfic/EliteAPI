{"tags":["CargoInfo","EliteAPI","Events","Startup","Vessel","Count","Inventory","Timestamp","Event"],"status":1}

# CargoInfo

## 01 Definition

Namespace: <span class='code'>EliteAPI.Events.Startup</span>

Inheritance: <span class='code'>Object</span> → <span class='code'>[EventBase](../../EliteAPI/Events/EventBase.html)</span> → <span class='code'>[CargoInfo](../../../EliteAPI/Events/Startup/CargoInfo.html)</span>



This event is written when the game has started.



## 02 Properties

### <span class='code'>[VesselType](../../../EliteAPI/Events/Startup/VesselType.html)</span> Vessel



The type of vessel, either 'Ship' or 'SRV'.



### <span class='code'>Int32</span> Count



The total amount of cargo in the vessel.



### <span class='code'>IReadOnlyList`1</span> Inventory



A list of all inventory in the vessel, grouped by name.



### <span class='code'>DateTime</span> Timestamp

### <span class='code'>String</span> Event

