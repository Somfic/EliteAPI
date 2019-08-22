using EliteAPI.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EliteAPI
{
    /// <summary>
    /// The main EliteAPI class. This class contains items and services that are able to tell you more
    /// about the current state of the game.
    /// </summary>
    public class EliteDangerousAPI
    {
        /// <summary>
        /// The constructor for the the EliteDangerousAPI class.
        /// </summary>
        public EliteDangerousAPI()
        {
        }

        /// <summary>
        /// Start processing Journal files and enable the events.
        /// </summary>
        public void Start( )
        {
            //Create a stopwatch object to keep track of the process.
            Stopwatch bootStopwatch = new Stopwatch();
            bootStopwatch.Start();

            //Get the Journal directory from the configuration file.
            string journalsPath = Path.GetFullPath(new ConfigurationReader("EliteAPI.ini").GetEntry("Startup", "DirectoryPath"));

            //Check if the Journal directory exists.

            //If it does not exist, try again with the default location.

            //If the default location directory does not exist, throw an error and return.

            //Look for a newer version via GitHub.

            //If there's a newer version available, let the user know, but continue.

            //Grab the appropiate Journal file.

            //Grab the Status, Cargo, Shipyard, Outfitting, Market and ModulesInfo files.

            //Pre-process the Journal file to get the API up-to-date.

            //Mark the API as running.

            //Stop the stopwatch.

            //Start an infinite Async loop that reads the Journal file and processes when needed.
        }
    }
}
