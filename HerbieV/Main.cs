using System;
using GTA;
using GTA.Native;

namespace HerbieV
{
    public class Main : Script
    {
        private const int ChromeWheel = 50;
        private const int Category = 0;
        public Main()
        {
            Tick += OnTick;
        }

        public void OnTick(object sender, EventArgs e)
        {
            var vwbeetle = World.GetAllVehicles("1963beetle");
            // Install chrome wheel when chrome secondary paint is selected
            foreach (var h in vwbeetle)
            {
                h.Mods.InstallModKit();
                if (h.Mods.SecondaryColor == VehicleColor.Chrome &&h.Mods[VehicleModType.FrontWheel].Index == -1)
                {
                    //h.Mods.WheelType = VehicleWheelType.Sport;
                    Function.Call(Hash.SET_VEHICLE_WHEEL_TYPE, h, Category);
                    h.Mods[VehicleModType.FrontWheel].Index = ChromeWheel;
                }
                else if (h.Mods.SecondaryColor != VehicleColor.Chrome && h.Mods[VehicleModType.FrontWheel].Index == ChromeWheel)
                {
                    h.Mods[VehicleModType.FrontWheel].Index = -1;
                }
            }
        }
    }
}