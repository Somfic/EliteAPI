{"tags":["InventoryInfo","EliteAPI","Events","Startup","Name","NameLocalised","Count","Stolen"],"status":1}

# InventoryInfo

## 01 Definition

Namespace: <span class='code'>EliteAPI.Events.Startup</span>

Inheritance: <span class='code'>Object</span> → <span class='code'>[InventoryInfo](../../../EliteAPI/Events/Startup/InventoryInfo.html)</span>



Inventory in the vessel, grouped by name.



## 02 Properties

### <span class='code'>String</span> Name



The name of the cargo item.



### <span class='code'>String</span> NameLocalised



The localised name of the cargo item.

Returns null when the 'Name' property is already localised.



### <span class='code'>Int32</span> Count



The amount of cargo of this type.



### <span class='code'>Int32</span> Stolen



The amount of stolen cargo of this type.



