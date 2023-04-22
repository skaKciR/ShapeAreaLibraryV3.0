using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaLibraryV3._0
{
    /// <summary>
    /// Представляет класс Треугольник
    /// </summary>
    public class Triangle : IShape
    {
        private double[] _sides; // стороны 
        private double _area; // площадь

        private const double Accuracy = 0.0001; // точность вычислений

        public string FigureType { get; } = "Triangle"; // тип фигуры
        public bool IsRight { get; } // является ли треугольник прямоугольным

        // Площадь фигуры
        public double Area
        {
            get
            {
                if (_area == 0)
                {
                    CalculateArea();
                }
                return _area;
            }
        }

        // Стороны треугольника
        public double[] Sides
        {
            get { return _sides; }
            private set
            {
                // Проверка на то, что все длины сторон положительны
                if (value.Any(side => side <= 0))
                {
                    throw new ArgumentException("Длины сторон треугольника должны быть числом положительным");
                }

                // Проверка существования треугольника
                if (value == null || value.Length != 3 || !IsTriangle(value[0], value[1], value[2]))
                {
                    throw new ArgumentException("Некорректные длины сторон треугольника");
                }

                _sides = value;
                _area = 0;
            }
        }

        /// <summary>
        /// Создание экземпляра класса Треугольник
        /// </summary>
        /// <param name="side1">Сторона 1</param>
        /// <param name="side2">Сторона 2</param>
        /// <param name="side3">Сторона 3</param>
        public Triangle(double side1, double side2, double side3)
        {
            Sides = new double[] { side1, side2, side3 }; 
            IsRight = IsRightTriangle();
        }

        /// <summary>
        /// Проверка существования треугольника
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>Возвращает true, если треугольник существует и false в противоположном случае</returns>
        private bool IsTriangle(double a, double b, double c)
        {
            return a + b > c + Accuracy && a + c > b + Accuracy && b + c > a + Accuracy; // Проверка условия, что длина каждой стороны меньше суммы длин двух других сторон
        }
       /// <summary>
       /// Вычисление площади фигуры
       /// </summary> 
        public void CalculateArea()
        {
            double p = (_sides[0] + _sides[1] + _sides[2]) / 2; // Выичсление полупериметра
            _area = Math.Sqrt(p * (p - _sides[0]) * (p - _sides[1]) * (p - _sides[2])); // Вычисление площади по формуле Герона
        }

        /// <summary>
        /// Проверка,является ли треугольник прямоугольным
        /// </summary>
        /// <returns>Возвращает значение true, если треугольник прямоугольный и false в противоположном случае</returns>
        public bool IsRightTriangle()
        {
            Array.Sort(_sides); // Сортировка сторон
            return Math.Abs(_sides[2] * _sides[2] - (_sides[0] * _sides[0] + _sides[1] * _sides[1])) < Accuracy; // Проверка по теореме Пифагора, является ли треугольник правильным
        }
    }
}