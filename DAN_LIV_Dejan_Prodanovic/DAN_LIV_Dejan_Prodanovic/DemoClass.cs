using DAN_LIV_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LIV_Dejan_Prodanovic
{
    class DemoClass
    {
        public static void CreateTractors(LinkedList<Tractor> tractors)
        {
            Tractor tractor = new Tractor(1.5, 2, "petrol", 40, 3000, "F", "CDI", "red", 98783);
            tractors.AddLast(tractor);

            tractor = new Tractor(2, 2, "petrol", 60, 3000, "F", "DDI", "blue", 42222);
            tractors.AddLast(tractor);

        }

        public static void CreateCars(List<Car> cars)
        {
            Car car = new Car("NS-202-CY", 4, 50, "manual", "Mercedes", 2834871, 20
               , 1000, "B", "petrol", "red", 1234, 2);
            car.CurrentAmountOfFuel = 40;

            cars.Add(car);

            car = new Car("NS-115-CF", 4, 60, "manual", "Audi", 5843871, 20
         , 1200, "B", "petrol", "red", 3212, 2);
            car.CurrentAmountOfFuel = 50;
            cars.Add(car);
        }

        public static void CreateTrucks(HashSet<Truck> trucks)
        {
            Truck truck = new Truck(10000, 5, 2, 80, 15000, "C", "CDTI", "gray", 43231);
            trucks.Add(truck);

            truck = new Truck(12000, 5, 3, 90, 18000, "C", "DTI", "yellow", 09876);
            trucks.Add(truck);

        }
    }
}
