using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FusionLibrary;
using static FusionLibrary.Enums;
using FusionLibrary.Extensions;
using HerbieV.Utility;
using GTA;
using GTA.Native;
using GTA.UI;
using LemonUI.Menus;
using HerbieV.Vehicles.Herbie;

namespace HerbieV.Menu
{
    public class MainMenu : CustomNativeMenu
    {
        private NativeItem spawnHerbie;

        public MainMenu() : base("HerbieV")
        {
            Add(spawnHerbie = new NativeItem("Spawn Herbie"));

            OnItemActivated += MainMenu_OnItemActivated;
        }

        private void MainMenu_OnItemActivated(NativeItem sender, EventArgs e)
        {
            if (sender == spawnHerbie)
                HerbieHandler.CreateHerbie(Utils.PlayerPed.Position, Utils.PlayerPed.Heading, true);
        }

        public override void Tick()
        {
            
        }
    }
}
