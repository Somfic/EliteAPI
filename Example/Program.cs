using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using EliteAPI;
using EliteAPI.Events;

using InputManager;

using Microsoft.Extensions.DependencyInjection;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteAPI.VoiceAttack.EliteVA.VAPlugin.VA_Init1(null);
        }
    }
}
