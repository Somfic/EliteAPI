DirectoryInfo playerJournalFolder = new DirectoryInfo(
$@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous");

EliteDangerousAPI EliteAPI = new EliteDangerousAPI( playerJournalFolder );

EliteAPI.Events.DockingGrantedEvent += EliteAPI_DockingGrantedEvent;

EliteAPI.Start();
