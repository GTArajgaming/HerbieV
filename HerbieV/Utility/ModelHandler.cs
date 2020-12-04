using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using GTA.Native;
using GTA.UI;

namespace HerbieV.Utility
{
    public class ModelHandler
    {
        private static Dictionary<Model, int> modelsToBeFreed = new Dictionary<Model, int>();
        private static Dictionary<Model, string> modelsToStrings = new Dictionary<Model, string>();

        public static Model VWBeetle = new Model("1963beetle");
        public static Model FuelNeedle = new Model("1963beetle_fuel_needle");
        public static Model SpeedNeedle = new Model("1963beetle_speed_needle");
        public static Model TimingPulley = new Model("timing_pulley");
        public static Model EnginePulley = new Model("engine_pulley");

        public static Model PreloadModel(Model model)
        {
            LoadingPrompt.Show("Loading: " + GetName(model));

            RequestModel(model);

            return model;
        }

        public static Model RequestModel(Model model)
        {
            if(!model.IsLoaded)
            {
                if (!model.IsInCdImage || !model.IsValid) throw new Exception(GetName(model) + " not present!");

                model.Request();

                while (!model.IsLoaded)
                {
                    Script.Yield();
                }
            }

            return model;
        }

        public static void RequestModels()
        {
            GetAllModels().ForEach(x => PreloadModel(x));

            Function.Call(Hash.BUSYSPINNER_OFF);
        }

        public static List<Model> GetAllModels()
        {
            var fields = typeof(ModelHandler).GetFields();
            var models = new List<Model>();

            foreach (var field in fields)
            {
                var obj = field.GetValue(null);
                if (obj.GetType() == typeof(Model))
                {
                    var modelObj = (Model)obj;
                    models.Add(modelObj);
                }
                else if (obj.GetType() == typeof(Dictionary<int, Model>))
                {
                    var dict = (Dictionary<int, Model>)obj;
                    models.AddRange(dict.Values);
                }
            }

            return models;
        }

        public static string GetName(Model model)
        {
            var fields = typeof(ModelHandler).GetFields();

            foreach(var field in fields)
            {
                var obj = field.GetValue(null);
                if(obj.GetType() == typeof(Model))
                {
                    var modelObj = (Model)obj;
                    if (modelObj.Hash == model.Hash)
                        return field.Name;
                }
                else if(obj.GetType() == typeof(Dictionary<int, Model>))
                {
                    if(modelsToStrings.ContainsKey(model))
                        return modelsToStrings[model];
                }
            }

            return "";
        }
    }
}
