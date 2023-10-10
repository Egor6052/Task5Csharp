using System;
using App5.Properties;

namespace App5
{
    public class Stations
    {
        private PowerStationInfo _powerStationInfo;
        private int _employeesCount;

        /// <summary>
        /// Число сотрудников;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public int EmployeesCount
        {
            get => _employeesCount;
            // проверка на количество;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Количество электростанций не может быть отрицательное количество.");
                }
                _employeesCount = value;    
            }
            
        }

        public Stations(string name, double performanceKilowatt, double currentGeneration, int employeesCount)
        {
            _powerStationInfo = new PowerStationInfo(name, performanceKilowatt, currentGeneration);
            EmployeesCount = employeesCount;
        }
        
        public override string ToString()
        {
            return $"{_powerStationInfo}, Employees CountCount: {EmployeesCount}";
        }
    }
}