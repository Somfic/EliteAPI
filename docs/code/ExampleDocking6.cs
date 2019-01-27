private static void EliteAPI_DockingGrantedEvent(object sender, DockingGrantedInfo e)
{
    //This method will be ran every time the player is allowed to dock.
    if(EliteAPI.Status.Gear != true) //If the gear is not deployed, deploy it.
    {
        Keyboard.KeyPress(Keys.G);
    }
}
