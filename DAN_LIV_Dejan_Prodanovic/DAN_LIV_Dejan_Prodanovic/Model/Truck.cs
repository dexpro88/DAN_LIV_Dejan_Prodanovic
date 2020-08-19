using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LIV_Dejan_Prodanovic.Model
{
    class Truck : MotorVehicle
    {
        public double Capacity { get; set; }
        public double Height { get; set; }
        public int NumberOfSeats { get; set; }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public Truck()
        {

        }

        public Truck(double capacity, double height, int numberOfSeats,
            double engineVolume, int weight, string category,
            string engineType, string color, int engineNumber):base(engineVolume, weight, 
                category, engineType, color, engineNumber)
        {
            Capacity = capacity;
            Height = height;
            NumberOfSeats = numberOfSeats;
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }

        void Load()
        {

        }

        void Unload()
        {

        }
    }
}
