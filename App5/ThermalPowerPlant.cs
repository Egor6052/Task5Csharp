using System;
using App5.Properties;

namespace App5
{
    public class ThermalPowerPlant : Stations
    {
        private string _stationLocation;
        private int _yearOfWork;
        private double _operatingPressure;
        
        public static readonly double THERMAL_PRESSURE_LIMIT = 100; // Лимит рабочего давления (Бар);
        /// <summary>
        /// Срок службыстанции;
        /// </summary>
        /// <exception cref="AggregateException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public int YearOfWork
        {
            get => _yearOfWork;
            set
            {
                if (value < 0)
                {
                    throw new AggregateException("Срок службы не может быть отрицательным.");
                }
                if (value >= PowerStationInfo.MAXIMUM_YEAR_NuclearPowerPlant)
                {
                    throw new ArgumentException("Период эксплуатации станции 40 или более лет.");
                }
                _yearOfWork = value;
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
        /// <exception cref="AggregateException"></exception>
        public double OperatingPressure
        {
            get => _operatingPressure;
            set
            {
                if (value >= THERMAL_PRESSURE_LIMIT)
                {
                    throw new AggregateException("Превышение рабочего давления.");
                }

                _operatingPressure = value;
            }
        }
        
        public ThermalPowerPlant(string name, double performanceKilowatt, double currentGeneration, int employeesCount, string stationLocation, int yearOfWork, double stationPrice, double operatingPressure, string owner) : base(name, performanceKilowatt, currentGeneration, employeesCount, stationPrice, owner)
        {
            Location = stationLocation;
            YearOfWork = yearOfWork;
            OperatingPressure = operatingPressure;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Location: {Location}, YearOfWork: {YearOfWork}, Operating Pressure: {OperatingPressure}(Бар)";
        }
    }
}