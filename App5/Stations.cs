using System;
using App5.Properties;

namespace App5
{
    public class Stations
    {
        private PowerStationInfo _powerStationInfo;
        private int _employeesCountCount;

        /// <summary>
        /// Число сотрудников;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public int EmployeesCountCount
        {
            get => _employeesCountCount;
            // проверка на количество;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Количество электростанций не может быть отрицательное количество.");
                }
                _employeesCountCount = value;    
            }
            
        }

        public Stations(string name, double performanceKilowatt, double currentGeneration, int employeesCountCount)
        {
            _powerStationInfo = new PowerStationInfo(name, performanceKilowatt, currentGeneration);
            EmployeesCountCount = employeesCountCount;
        }
        
        public override string ToString()
        {
            return $"{_powerStationInfo}, Employees CountCount: {EmployeesCountCount}";
        }
    }
}