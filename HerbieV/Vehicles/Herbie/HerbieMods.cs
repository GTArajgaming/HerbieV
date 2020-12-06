using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HerbieV.Enums;

namespace HerbieV.Vehicles.Herbie
{
    public class HerbieMods : FusionLibrary.Player
    {
        private Herbie Herbie { get; }
        private Vehicle Vehicle => Herbie.Vehicle;

        public HerbieLivery Livery
        {
            get => (HerbieLivery)Vehicle.Mods.Livery;
            set => Vehicle.Mods.Livery = (int)value;
        }

        public HerbieMods(Herbie herbie)
        {
            Herbie = herbie;
            Entity = herbie.Vehicle;

            Vehicle.Wash();

            Vehicle.Mods.InstallModKit();

            Vehicle.Mods.PrimaryColor = VehicleColor.PureWhite;
            Vehicle.Mods.RimColor = VehicleColor.PureWhite;

            Livery = HerbieLivery.Stock;
        }

        public override void Dispose()
        {
            
        }

        public override void Play()
        {
            
        }

        public override void Process()
        {
            if (Vehicle.Mods.SecondaryColor == VehicleColor.Chrome && Vehicle.Mods[VehicleModType.FrontWheel].Index == -1)
            {                
                Function.Call(Hash.SET_VEHICLE_WHEEL_TYPE, Vehicle, 0);
                Vehicle.Mods[VehicleModType.FrontWheel].Index = 50;
                Vehicle.Mods.RimColor = VehicleColor.PureWhite;
            }
            else if (Vehicle.Mods.SecondaryColor != VehicleColor.Chrome && Vehicle.Mods[VehicleModType.FrontWheel].Index == 50)
            {
                Vehicle.Mods[VehicleModType.FrontWheel].Index = -1;
            }
        }

        public override void Stop()
        {
            
        }
    }
}
