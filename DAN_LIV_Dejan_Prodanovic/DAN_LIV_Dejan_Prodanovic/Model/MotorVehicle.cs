using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LIV_Dejan_Prodanovic.Model
{
    abstract class MotorVehicle
    {
        public double EngineVolume { get; set; }
        public int Weight { get; set; }
        public string Category { get; set; }
        public string EngineType { get; set;}
        public string Color { get; set; }
        public int EngineNumber { get; set; }

        public MotorVehicle()
        {

        }

        protected MotorVehicle(double engineVolume, int weight, string category, string engineType, string color, int engineNumber)
        {
            EngineVolume = engineVolume;
            Weight = weight;
            Category = category;
            EngineType = engineType;
            Color = color;
            EngineNumber = engineNumber;
        }

        public abstract void Start();
        public abstract void Stop();

    }
}
