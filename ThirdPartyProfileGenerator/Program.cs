using Code2Profile.VoiceMacro;
using EliteAPI;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ThirdPartyProfileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory, true);
            EliteAPI.Logger.UseConsole();
            EliteAPI.Start();

            VoiceMacroBuilder v = new VoiceMacroBuilder();
            v.CreateProfile("EliteAPI VMP (auto-gen)");

            //Landing gear.
            v.AddCommand(new CommandBuilder()
                .UsePhrase("lower landing gear")
                .AddAction(new ConditionAction()
                {
                    Condition = "EliteAPI.Gear_p = False",
                    ActionsIfTrue = new List<IAction>() { new KeyboardAction() { Key = Keys.L } }
                })
                );
            v.AddCommand(new CommandBuilder()
                .UsePhrase("raise landing gear")
                .AddAction(new ConditionAction()
                {
                    Condition = "EliteAPI.Gear_p = True",
                    ActionsIfTrue = new List<IAction>() { new KeyboardAction() { Key = Keys.L } }
                }));
            v.AddCommand(new CommandBuilder()
                .UsePhrase("landing gear")
                .AddAction(new KeyboardAction() { Key = Keys.L }));

            v.BuildProfile(new DirectoryInfo(Directory.GetCurrentDirectory()));
        }
    }
}
