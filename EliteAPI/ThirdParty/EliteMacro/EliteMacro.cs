using Somfic.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Somfic.Logging.Handlers;
using vmAPI;
namespace EliteAPI.ThirdParty.EliteMacro
{
    public class EliteMacro : vmInterface
    {
        public string DisplayName => "EliteMacro";
        public string Description => "EliteMacro by Somfic.";
        public string ID => new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB67}").ToString();

        void vmInterface.Init()
        {
           
        }

        void vmInterface.ReceiveParams(string Param1, string Param2, string Param3, bool Synchron)
        {

        }

        void vmInterface.ProfileSwitched(string ProfileGUID, string ProfileName)
        {

        }

        void vmInterface.Dispose()
        {

        }
    }
}
