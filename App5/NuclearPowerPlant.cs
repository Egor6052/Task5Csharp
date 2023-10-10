using System;
using App5.Properties;

namespace App5
{
    public class NuclearPowerPlant: Stations
    {
        private string _stationLocation;
        private int _yearOfWork;

        // Годы работы станции;
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

        /// Расположение станции;
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

        public NuclearPowerPlant(string name, double performanceKilowatt, double currentGeneration, int employeesCountCount, string stationLocation, int yearOfWork) : base(name, performanceKilowatt, currentGeneration, employeesCountCount)
        {
            Location = stationLocation;
            YearOfWork = yearOfWork;
        }
        
        public override string ToString()
        {
            return $"{base.ToString()}, Location: {Location}, YearOfWork: {YearOfWork}";
        }
    }
}