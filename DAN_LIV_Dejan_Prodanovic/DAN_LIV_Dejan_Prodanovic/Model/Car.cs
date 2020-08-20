using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LIV_Dejan_Prodanovic.Model
{
    class Car : MotorVehicle
    {
        public string RegistrationNumber { get; set; }
        public int NumberOfDoors { get; set; }
        public int TankVolume { get; set; }
        public string TransmissionType{ get; set; }
        public string Producer { get; set; }
        public int TrafficNumber { get; set; }
        public int CurrentAmountOfFuel { get; set; }
        public int AmountCousumedPerSec { get; set; }
        public bool FinishRace { get; set; }

        public Car()
        {

        }

        public Car(string registrationNumber, int numberOfDoors,
            int tankVolume, string transmissionType, string producer,
            int trafficNumber, double engineVolume, int weight,
            string category, string engineType, string color, int engineNumber,
            int AmountCousumedPerSec)
            :base( engineVolume,  weight,  category,  engineType,  color,  engineNumber)
        {
            RegistrationNumber = registrationNumber;
            NumberOfDoors = numberOfDoors;
            TankVolume = tankVolume;
            TransmissionType = transmissionType;
            Producer = producer;
            TrafficNumber = trafficNumber;
            this.AmountCousumedPerSec = AmountCousumedPerSec;
        }

        public override void Start()
        {
            Console.WriteLine("{0} je krenuo");
        }

        public override void Stop()
        {
            Console.WriteLine("{0} se zaustavio");
        }

        public void ChangeColor(string color, int trafficNumber)
        {
            this.Color = color;
            this.TrafficNumber = trafficNumber;
        }
    }
}
