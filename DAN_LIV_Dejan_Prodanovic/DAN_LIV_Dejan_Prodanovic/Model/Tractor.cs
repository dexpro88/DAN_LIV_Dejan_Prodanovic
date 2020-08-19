using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LIV_Dejan_Prodanovic.Model
{
    class Tractor:MotorVehicle
    {
        public double TireSize { get; set; }
        public int Wheelbase { get; set; }
        public string Propulsion { get; set; }

        public Tractor()
        {

        }

        public Tractor(double tireSize, int wheelbase, string propulsion,
            double engineVolume, int weight, string category, string engineType, 
            string color, int engineNumber) :base(engineVolume, weight,
                 category, engineType, color, engineNumber)
        {
            TireSize = tireSize;
            Wheelbase = wheelbase;
            Propulsion = propulsion;
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
