using System;
namespace ShapeAreaLibraryV3._0
{
    /// <summary>
    /// Представляет класс Прямоугольника
    /// </summary>
    public class Rectangle : IShape
    {
        private double _sideA;
        private double _sideB;
        private double _area; // площадь

        public string FigureType { get; } = "Rectangle"; // тип фигуры

        // Площадь фигуры
        public double Area
        {
            get
            {
                return _area;
            }
        }

        // Стороны прямуогольника
        public double SideA
        {
            get { return _sideA; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Длина стороны фигуры должна быть положительным числом");
                }
                // Присваиваем новое значение и обновляем поля, т.к длина стороны изменилась
                _sideA = value;
                CalculateArea();

            }
        }

        public double SideB
        {
            get { return _sideB; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Длины сторон фигуры должны быть положительным числом");
                }
                // Присваиваем новое значение и обновляем поля, т.к длина стороны изменилась
                _sideB = value;
                CalculateArea();

            }
        }

        /// <summary>
        /// Создание экземпляра класса Прямоугольник
        /// </summary>
        /// <param name="side1">Длина первой стороны</param>
        /// <param name="side2">Длина второй стороны</param>
        public Rectangle(double side1, double side2)
        {
            if (side1 <= 0 || side2 <= 0)
            {
                throw new ArgumentException("Длины сторон фигуры должны быть положительным числом");
            }
            _sideA = side1;
            _sideB = side2;
            CalculateArea();
        }

        /// <summary>
        /// Вычисление площади фигуры
        /// </summary>
        public void CalculateArea()
        {
            _area = _sideA*_sideB;
        }
    }
}