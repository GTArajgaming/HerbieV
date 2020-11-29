using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FusionLibrary;
using static FusionLibrary.Enums;
using FusionLibrary.Extensions;
using GTA;

namespace HerbieV.Vehicles.Herbie
{
    public class Herbie
    {
        public Vehicle Vehicle { get; }

        public Herbie(Vehicle vehicle)
        {
            Vehicle = vehicle;

            Vehicle.IsPersistent = true;

            Vehicle.Mods.InstallModKit();
        }

        public void Tick()
        {

        }

        public void Abort()
        {
            Vehicle.DeleteCompletely();

            HerbieHandler.RemoveHerbie(this);
        }
    }
}
