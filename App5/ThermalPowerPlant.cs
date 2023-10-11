using System;
using App5.Properties;

namespace App5
{
    public class ThermalPowerPlant : Stations
    {
        private string _stationLocation;
        private double _vaporGeneration;
        private double _operatingPressure;
        
        public static readonly double THERMAL_PRESSURE_LIMIT = 100; // Лимит рабочего давления (Бар);
        private readonly double VAPOR_MAXIMUM = 8000;               // Безопасный лимит производимого пара (кг/час);
        
        /// <summary>
        /// Генерация пара электростанцией для турбины;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double VaporGeneration
        {
            get => _vaporGeneration;
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Генерация пара не может быть отрицательной.");
                }
                if (value >= VAPOR_MAXIMUM)
                {
                    throw new IndexOutOfRangeException("Превышение генерации пара, это может навредить турбине станции.");
                }
                _vaporGeneration = value;
            }
        }
        
        /// <summary>
        /// Расположение станции;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public string Location
        {
            get => _stationLocation;
            set
            {
                // проверки корректность ввода данных о локации;
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Локация не может быть пустой строкой или null.");
                }
                _stationLocation = value.Trim();
            }
        }

        /// <summary>
        /// Рабочее давление станции;
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public double OperatingPressure
        {
            get => _operatingPressure;
            set
            {
                if (value > THERMAL_PRESSURE_LIMIT)
                {
                    throw new IndexOutOfRangeException("Превышение рабочего давления.");
                }

                _operatingPressure = value;
            }
        }
        
        public ThermalPowerPlant(string name, double performanceKilowatt, double currentGeneration, int employeesCount, string stationLocation, int vaporGeneration, double stationPrice, double operatingPressure, string owner) : base(name, performanceKilowatt, currentGeneration, employeesCount, stationPrice, owner)
        {
            Location = stationLocation;
            VaporGeneration = vaporGeneration;
            OperatingPressure = operatingPressure;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Location: {Location}, Vapor Generation: {VaporGeneration}, Operating Pressure: {OperatingPressure}(Бар)";
        }
    }
}