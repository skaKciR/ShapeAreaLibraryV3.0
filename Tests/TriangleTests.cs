using ShapeAreaLibraryV3._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TriangleTests
    {
        // Погрешность
        double accuracy = 0.01;

        // Положительные тесты
        [TestCase(3, 4, 5, 6)]
        [TestCase(19, 12, 12, 69.64867191842211)]
        [TestCase(5, 5, 6, 12)]
        [TestCase(15, 13, 4, 24)]
        [TestCase(6, 7, 9, 20.97617696340303)]
        [TestCase(18, 18, 35, 73.72881051529313)]
        [TestCase(5.8, 4.2, 1.9, 2.515073)]
        [TestCase(5, 5, 6, 12)]
        [Test]
        public void TrianglePositiveTests(double a, double b, double c, double exp)
        {
            IShape figure = ShapeFactory.CreateShape(a, b, c);
            Assert.AreEqual(figure.Area, exp, accuracy);
            Assert.AreEqual(figure.FigureType, "Triangle");
        }

        // Отрицательные тесты
        [TestCase(5, 2, 7)]
        [TestCase(14, 2, 8)]
        [TestCase(2, 14, 8)]
        [TestCase(0, 4, 5)]
        [TestCase(3, 0, 5)]
        [TestCase(3, 4, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, 4, 5)]
        [TestCase(4, -1, 5)]
        [TestCase(4, 1, -5)]
        [TestCase(-4, -1, -5)]
        [TestCase(5.8, 4.2, 1.6)]
        [Test]
        public void TriangleNegativeTests(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        }

        // Проверка, является ли треугольник прямоугольным
        [TestCase(5, 4, 3, true)]
        [TestCase(3, 4, 5, true)]
        [TestCase(5, 12, 13, true)]
        [TestCase(6, 8, 10, true)]
        [Test]
        public void ChecikngRightTriangle(double a, double b, double c, bool exp)
        {
            IShape figure = ShapeFactory.CreateShape(a, b, c);
            Assert.AreEqual(figure.FigureType, "Triangle");
            Assert.AreEqual(((Triangle)figure).IsRight, exp);
        }

        // Проверка,треугольник не является  прямоугольным
        [TestCase(6, 4, 3, false)]
        [TestCase(4, 5, 8, false)]
        [TestCase(4, 7, 5, false)]
        [TestCase(5, 12, 14, false)]
        [Test]
        public void ChecikngNotRightTriangle(double a, double b, double c, bool exp)
        {
            IShape figure = ShapeFactory.CreateShape(a, b, c);
            Assert.AreEqual(figure.FigureType, "Triangle");
            Assert.AreEqual(((Triangle)figure).IsRight, exp);
        }
    }
}
