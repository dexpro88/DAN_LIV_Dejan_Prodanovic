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

        public Car()
        {

        }

        public Car(string registrationNumber, int numberOfDoors,
            int tankVolume, string transmissionType, string producer,
            int trafficNumber, double engineVolume, int weight,
            string category, string engineType, string color, int engineNumber)
            :base( engineVolume,  weight,  category,  engineType,  color,  engineNumber)
        {
            RegistrationNumber = registrationNumber;
            NumberOfDoors = numberOfDoors;
            TankVolume = tankVolume;
            TransmissionType = transmissionType;
            Producer = producer;
            TrafficNumber = trafficNumber;
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
