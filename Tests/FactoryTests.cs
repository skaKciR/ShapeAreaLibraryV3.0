using ShapeAreaLibraryV3._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FactoryTests
    {
        public double accuracy = 0.001;

        // Checking creating Circle with Factory and standart Circle
        [TestCase(5)]
        [TestCase(2)]
        [TestCase(0.2)]
        public void CircleFactoryTest(double R)
        {
            Circle circle1 = new Circle(R);
            IShape circle2 = ShapeFactory.CreateShape(R);
            Assert.AreEqual(circle1.Area, circle2.Area, accuracy);
        }

        // Checking creating Triangle with Factory and standart Triangle
        [TestCase(3, 4, 5)]
        [TestCase(19, 12, 12)]
        [TestCase(5, 5, 6)]
        [Test]
        public void TriangleFactoryTest(double a, double b, double c)
        {
            Triangle triangle1 = new Triangle(a,b,c);
            IShape triangle2 = ShapeFactory.CreateShape(a, b, c);
            Assert.AreEqual(triangle1.Area, triangle2.Area, accuracy);
        }

        // Checking creating Rectangle with Factory and standart Rectangle
        [TestCase(5, 5)]
        [TestCase(4, 6)]
        [TestCase(25, 50)]
        [Test]
        public void RectangleFactoryTest(double a, double b)
        {
            Rectangle rectangle1 = new Rectangle(a, b);
            IShape rectangle2 = ShapeFactory.CreateShape(a, b);
            Assert.AreEqual(rectangle1.Area, rectangle2.Area, accuracy);
        }

    }
}
