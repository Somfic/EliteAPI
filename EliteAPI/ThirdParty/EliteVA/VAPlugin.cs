using System;
using System.Collections.Generic;
using System.IO;
using Somfic.Logging;
using Somfic.Logging.Handlers;

namespace EliteAPI.ThirdParty.EliteVA
{
    public class VAPlugin
    {
        public static string VA_DisplayName() => "EliteVA";
        public static string VA_DisplayInfo() => "EliteVA by Somfic.";
        public static Guid VA_Id() => new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB66}");

        public static void VA_Init1(dynamic vaProxy)
        {

        }

        public static void VA_Invoke1(dynamic vaProxy)
        {

        }

        public static void VA_StopCommand()
        {

        }

        public static void VA_Exit1(dynamic vaProxy)
        {
        }
    }
}