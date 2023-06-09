﻿using ShapeAreaLibraryV3._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class RectangleTests
    {
        // Погрешность
        double accuracy = 0.01;

        // Положительные тесты
        [TestCase(5, 5, 25)]
        [TestCase(5.5, 5.5, 30.25)]
        [TestCase(1, 1, 1)]
        [TestCase(2, 1, 2)]
        [Test]
        public void RectanglePositiveTests(double a, double b, double exp)
        {
            IShape figure = ShapeFactory.CreateShape(a, b);
            Assert.AreEqual(figure.Area, exp, accuracy);
            Assert.AreEqual(figure.FigureType, "Rectangle");
        }

        // Отрицательные
        [TestCase(-5, 5)]
        [TestCase(5, -5)]
        [TestCase(0, 5)]
        [TestCase(5, 0)]
        [TestCase(0, 0)]
        [TestCase(-5, -5)]
        [TestCase(-5, -5)]
        [Test]
        public void RectangleNegativeTests(double a, double b)
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(a, b));
        }
    }
}
