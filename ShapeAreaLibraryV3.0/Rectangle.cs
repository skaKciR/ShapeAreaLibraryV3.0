using System;
namespace ShapeAreaLibraryV3._0
{
    /// <summary>
    /// Представляет класс Прямоугольника
    /// </summary>
    public class Rectangle : IShape
    {
        private double[] _sides; // стороны
        private double _area; // площадь

        public string FigureType { get; } = "Rectangle"; // тип фигуры

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

        // Стороны прямуогольника
        public double[] Sides
        {
            get { return _sides; }
            private set
            {
                if (value.Any(side => side <= 0))
                {
                    throw new ArgumentException("Длины сторон прямоугольника должны быть числом положительным");
                }

                if (value == null || value.Length != 2)
                {
                    throw new ArgumentException("Некорректные длины сторон прямоугольника");
                }

                _sides = value;
                _area = 0;
            }
        }

        /// <summary>
        /// Создание экземпляра класса Прямоугольник
        /// </summary>
        /// <param name="side1">Длина первой стороны</param>
        /// <param name="side2">Длина второй стороны</param>
        public Rectangle(double side1, double side2)
        {
            Sides = new double[] { side1, side2 };
        }

        /// <summary>
        /// Вычисление площади фигуры
        /// </summary>
        public void CalculateArea()
        {
            _area = _sides[0] * _sides[1];
        }
    }
}