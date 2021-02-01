using FusionLibrary;
using GTA;
using GTA.Math;
using HerbieV.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FusionLibrary.Enums;

namespace HerbieV.Vehicles.Herbie
{
    public class HerbieProps : FusionLibrary.Player
    {
        private Herbie Herbie { get; }
        private Vehicle Vehicle => Herbie.Vehicle;

        public AnimateProp EnginePulley { get; }
        public AnimateProp TimingPulley { get; }
        public AnimateProp FuelNeedle { get; }
        public AnimateProp SpeedNeedle { get; }

        public HerbieProps(Herbie herbie)
        {
            Herbie = herbie;
            Entity = herbie.Vehicle;

            EnginePulley = new AnimateProp(ModelHandler.EnginePulley, Entity, "engine_pulley_dummy", Vector3.Zero, Vector3.Zero);
            EnginePulley[AnimationType.Rotation][AnimationStep.First][Coordinate.Y].Setup(true, false, true, 0, 360, 1, 90, 1);
            EnginePulley[AnimationType.Rotation][AnimationStep.First][Coordinate.Y].DoNotInvert = true;

            TimingPulley = new AnimateProp(ModelHandler.TimingPulley, Entity, "timing_pulley_dummy", Vector3.Zero, Vector3.Zero);
            TimingPulley[AnimationType.Rotation][AnimationStep.First][Coordinate.Y].Setup(true, false, true, 0, 360, 1, 180, 1);
            TimingPulley[AnimationType.Rotation][AnimationStep.First][Coordinate.Y].DoNotInvert = true;

            FuelNeedle = new AnimateProp(ModelHandler.FuelNeedle, Entity, "1963beetle_fuel_needle_dummy", Vector3.Zero, Vector3.Zero);
            SpeedNeedle = new AnimateProp(ModelHandler.SpeedNeedle, Entity, "1963beetle_speed_needle_dummy", Vector3.Zero, Vector3.Zero);
        }

        if (Vehicle.IsEngineRunning)
            {
                // --- Speed ---
                float speed = Vehicle.GetMPHSpeed();
                SpeedNeedle = 270 * speed / 95 - 8;

                if (speedRotation > 270)
                    speedRotation = 270;

                FuelNeedle = Utils.Lerp(fuelRotation, -50f, Game.LastFrameTime * 10f);
            }
        else
            {
                FuelNeedle = Utils.Lerp(fuelRotation, 0, Game.LastFrameTime * 15f);
            }


        public override void Dispose()
        {
            EnginePulley.Dispose();
            TimingPulley.Dispose();
            FuelNeedle.Dispose();
            SpeedNeedle.Dispose();
        }

        public override void Play()
        {
            
        }

        public override void Process()
        {
            bool engine = Vehicle.IsEngineRunning;

            int rpm = (int)(Vehicle.CurrentRPM * 10);

            if (engine)
            {
                EnginePulley[AnimationType.Rotation][AnimationStep.First][Coordinate.Y].StepRatio = rpm;
                TimingPulley[AnimationType.Rotation][AnimationStep.First][Coordinate.Y].StepRatio = rpm;
            }

            if (EnginePulley.IsPlaying != engine)
            {
                if (engine)
                {
                    EnginePulley.Play();
                    TimingPulley.Play();
                }
                else
                {
                    EnginePulley.Stop();
                    TimingPulley.Stop();
                }                    
            }
        }

        public override void Stop()
        {
            
        }
    }
}
