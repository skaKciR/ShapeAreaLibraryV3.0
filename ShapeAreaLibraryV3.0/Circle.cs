using System;

namespace ShapeAreaLibraryV3._0
{
    /// <summary>
    /// Представляет класс круга
    /// </summary>
    public class Circle : IShape
    {
        private double _radius; // радиус
        private double _area; // площади

        public string FigureType { get; } = "Circle"; // тип фигуры

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

        // Свойство Радиус
        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Радиус круга должен быть положительным числом");
                }

                _radius = value;
                _area = 0;
            }
        }

        /// <summary>
        /// Создание экземпляра класса Круга
        /// </summary>
        /// <param name="radius">Радиус</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Метод вычисления площади фигуры
        /// </summary>
        public void CalculateArea()
        {
            _area = Math.PI * Math.Pow(_radius, 2);
        }
    }
}