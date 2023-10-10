using System;
namespace App5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            HydroelectricPowerlant station1 = new HydroelectricPowerlant("HydroStation1", 10, 5000, 60, "Location1", 9);
            HydroelectricPowerlant station2 = new HydroelectricPowerlant("HydroStation2", 8, 1000, 32, "Location2", 10);
            ThermalPowerPlant station3 = new ThermalPowerPlant("ThermalStation1", 11, 8000, 54, "Location3", 5);
            ThermalPowerPlant station4 = new ThermalPowerPlant("ThermalStation2", 9, 900, 38, "Location4", 12);
            NuclearPowerPlant station5 = new NuclearPowerPlant("NuclearStation1", 14, 9000, 70, "Location1", 12);
            NuclearPowerPlant station6 = new NuclearPowerPlant("NuclearStation2", 13,6000, 65,"Location2",9);
            
            // исходный массив stationsArray;
            StationsArray stationsArray = new StationsArray(station1, station2, station3, station4);
            
            Console.WriteLine("Исходный масив:");
            Console.WriteLine(stationsArray.ToString());

            stationsArray.AddStation(station5);
            Console.WriteLine("После добавления:");
            Console.WriteLine(stationsArray.ToString());

            Console.WriteLine("После редактирования:");
            stationsArray.EditStation(0, station6);
            Console.WriteLine(stationsArray.ToString());

            Console.WriteLine("После удаления:");
            stationsArray.RemoveStation(0);
            Console.WriteLine(stationsArray.ToString()) ;
        }
    }
}