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
        private double _sideA;
        private double _sideB;
        private double _sideC;
        private double _area; // площадь

        private const double Accuracy = 0.0001; // точность вычислений

        public string FigureType { get; } = "Triangle"; // тип фигуры
        public bool IsRight { get; private set; } // является ли треугольник прямоугольным

        // Площадь фигуры
        public double Area
        {
            get
            {
                return _area;
            }
        }

        // Стороны треугольника
        public double SideA
        {
            get { return _sideA; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Длина стороны треугольника должна быть положительным числом");
                }
                // Проверяем, может ли существовать такой треугольник
                if (!IsTriangle(value, _sideB, _sideC))
                {
                    throw new ArgumentException("Треугольник с такими сторонами не существует");
                }
                // Присваиваем новое значение и обновляем поля Area и IsRight , т.к длина стороны изменилась
                _sideA = value;
                UpdateInfo();

            }
        }

        public double SideB
        {
            get { return _sideB; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Длина стороны треугольника должна быть положительным числом");
                }
                // Проверяем, может ли существовать такой треугольник
                if (!IsTriangle(_sideA, value, _sideC))
                {
                    throw new ArgumentException("Треугольник с такими сторонами не существует");
                }
                // Присваиваем новое значение и обновляем поля, т.к длина стороны изменилась
                _sideB = value;
                UpdateInfo();
             
            }
        }

        public double SideC
        {
            get { return _sideC; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Длина стороны треугольника должна быть положительным числом");
                }
                // Проверяем, может ли существовать такой треугольник
                if (!IsTriangle(_sideA, _sideB, value))
                {
                    throw new ArgumentException("Треугольник с такими сторонами не существует");
                }
                // Присваиваем новое значение и обновляем поля, т.к длина стороны изменилась
                _sideC = value;
                UpdateInfo();

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
            if (!IsTriangle(side1, side2, side3))
            {
                throw new ArgumentException("Треугольник с такими сторонами не существует");
            }
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                throw new ArgumentException("Длины сторон фигуры должны быть положительным числом");
            }
            _sideA = side1;
            _sideB = side2;
            _sideC = side3;
            UpdateInfo();
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
            double p = (_sideA + _sideB + _sideC) / 2; // Выичсление полупериметра
            _area = Math.Sqrt(p * (p - _sideA) * (p - _sideB) * (p - _sideC)); // Вычисление площади по формуле Герона
        }

        /// <summary>
        /// Проверка,является ли треугольник прямоугольным
        /// </summary>
        /// <returns>Возвращает значение true, если треугольник прямоугольный и false в противоположном случае</returns>
        private bool IsRightTriangle()
        {
            double[] _sides = { _sideA, _sideB, _sideC };
            Array.Sort(_sides);
            return Math.Abs(_sides[2] * _sides[2] - (_sides[0] * _sides[0] + _sides[1] * _sides[1])) < Accuracy; // Проверка по теореме Пифагора, является ли треугольник прямоугольным
        }

        /// <summary>
        /// Метод, обновления полей Area и IsRight
        /// </summary>
        private void UpdateInfo()
        {
            CalculateArea();
            IsRight = IsRightTriangle();
        }
    }
}