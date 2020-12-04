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

        public HerbieProps Props { get; }

        public Herbie(Vehicle vehicle)
        {
            Vehicle = vehicle;

            Vehicle.IsPersistent = true;

            Vehicle.Mods.InstallModKit();

            Props = new HerbieProps(this);

            HerbieHandler.AddHerbie(this);
        }

        public void Tick()
        {
            Props.Process();
        }

        public void Abort()
        {
            Props.Dispose();

            Vehicle.DeleteCompletely();

            HerbieHandler.RemoveHerbie(this);
        }
    }
}
