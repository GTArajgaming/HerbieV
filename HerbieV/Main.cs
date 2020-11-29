using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using HerbieV.Menu;
using HerbieV.Utility;
using HerbieV.Vehicles.Herbie;

namespace HerbieV
{
    public class Main : Script
    {
        //private const int ChromeWheel = 50;
        //private const int Category = 0;
        //private const int ChromeWheel2 = 51;
        //private const int ChromeWheel3 = 52;

        private bool _firstTick = true;

        public Main()
        {
            Tick += OnTick;
            KeyDown += Main_KeyDown;
        }

        private unsafe void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
                MenuHandler.MainMenu.Open();
        }

        public void OnTick(object sender, EventArgs e)
        {
            if (Game.IsLoading)
                return;

            if (_firstTick)
            {
                ModelHandler.RequestModels();

                _firstTick = false;
            }

            HerbieHandler.Tick();

            //// Install chrome wheel when chrome secondary paint is selected
            //foreach (var h in World.GetAllVehicles(ModelHandler.VWBeetle))
            //{
            //    h.Mods.InstallModKit();
            //    if (h.Mods.SecondaryColor == VehicleColor.Chrome &&h.Mods[VehicleModType.FrontWheel].Index == -1)
            //    {
            //        //h.Mods.WheelType = VehicleWheelType.Sport;
            //        Function.Call(Hash.SET_VEHICLE_WHEEL_TYPE, h, Category);
            //        h.Mods[VehicleModType.FrontWheel].Index = ChromeWheel;
            //    }
            //    else if (h.Mods.SecondaryColor != VehicleColor.Chrome && h.Mods[VehicleModType.FrontWheel].Index == ChromeWheel)
            //    {
            //        h.Mods[VehicleModType.FrontWheel].Index = -1;
            //    }
            //}
        }
    }
}