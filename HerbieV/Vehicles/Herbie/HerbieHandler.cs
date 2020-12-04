using GTA;
using GTA.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FusionLibrary;
using static FusionLibrary.Enums;
using FusionLibrary.Extensions;
using HerbieV.Utility;

namespace HerbieV.Vehicles.Herbie
{
    public static class HerbieHandler
    {
        public static List<Herbie> Herbies = new List<Herbie>();
        private static List<Herbie> herbiesToAdd = new List<Herbie>();
        private static List<Herbie> herbiesToRemove = new List<Herbie>();

        public static void Abort()
        {
            Herbies.ForEach(x => x.Abort());
        }

        public static Herbie CreateHerbie(Vector3 position, float heading = 0, bool warpInPlayer = false)
        {
            Vehicle vehicle = World.CreateVehicle(ModelHandler.VWBeetle, position, heading);

            if (warpInPlayer)
                Utils.PlayerPed.Task.WarpIntoVehicle(vehicle, VehicleSeat.Driver);

            return new Herbie(vehicle);
        }

        public static void AddHerbie(Herbie herbie)
        {
            if (!herbiesToAdd.Contains(herbie))
                if (!Herbies.Contains(herbie))
                    herbiesToAdd.Add(herbie);
        }

        public static void RemoveHerbie(Herbie herbie)
        {
            if (!herbiesToRemove.Contains(herbie))
                herbiesToRemove.Add(herbie);
        }

        public static void Tick()
        {
            if (herbiesToAdd.Count > 0)
            {
                herbiesToAdd.ForEach(x => Herbies.Add(x));
                herbiesToAdd.Clear();
            }

            if (herbiesToRemove.Count > 0)
            {
                herbiesToRemove.ForEach(x => Herbies.Remove(x));
                herbiesToRemove.Clear();
            }

            Herbies.ForEach(x => x.Tick());
        }
    }
}
