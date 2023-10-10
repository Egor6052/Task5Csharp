using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace App5.Properties
{
    public class PowerStationInfo
    {
        private string _name;
        private double _performanceKilowatt;
        private double _currentGeneration;

        public static readonly long MAX_VALUE_PERFORMANCE = 14000000000;    // Ед. измерений: КВт;
        public static readonly long MAX_VALUE_CURRENT = 10000;              // Ед. измерений: Ампер;
        public static readonly int MAXIMUM_YEAR_NuclearPowerPlant = 40;     // Максимальный период службы (годы); 
        public string Name
        {
            get => _name;
            set
            {
                // проверка на нулевую строку или null;
                if (value == null && value == "")
                {
                    throw new ArgumentException("Имя не может быть пустой строкой или null.");
                }
                _name = value.Trim();
            }
        }

        /// <summary>
        /// Производительность станции;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double Performance
        {
            get => _performanceKilowatt;
            set
            {
                // проверка на нулевую производительность;
                if (value < 0)
                {
                    throw new ArgumentException("Производительноть не может быть отрицательной.");
                }

                // превышение рекомендуемой производительности;
                if (value > MAX_VALUE_PERFORMANCE)
                {
                    throw new ArgumentException("Производительность больше максимальной, что-то не так или у нас новый рекорд.");

                }
                _performanceKilowatt = value;
            }
            
        }

        /// <summary>
        /// Сколько станция генерирует тока;
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double CurrentGeneration
        {
            get => _currentGeneration;
            set
            {
                // проверка на нулевую генерацию тока;
                if (value < 0)
                {
                    throw new ArgumentException("Генерация тока не может быть отрицательной.");
                }

                if (value > MAX_VALUE_CURRENT)
                {
                    throw new ArgumentException("Генерация тока выше допустимого значения.");
                }

                _currentGeneration = value;
            }
            
        }

        public PowerStationInfo(string name, double performanceKilowatt, double currentGeneration)
        {
            Name = name;
            Performance = performanceKilowatt;
            CurrentGeneration = currentGeneration;
        }
        
        public override string ToString()
        {
            return $"Name: {Name}, Performance: {Performance}, Current Generation: {CurrentGeneration}";
        }
    }
   
}