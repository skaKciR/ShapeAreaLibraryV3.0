using ShapeAreaLibraryV3._0;
namespace Tests
{
    public class CircleTests
    {
        // Accuracy
        double accuracy = 0.01;

        // Positive Circle Tests
        [TestCase(4, 50.26)]
        [TestCase(10, 314.15)]
        [TestCase(5, 78.54)]
        [TestCase(1, 3.14)]
        [TestCase(2.5, 19.625)]
        [Test]
        public void CirclePositiveTests(double R, double exp)
        {
            IShape figure = ShapeFactory.CreateShape(R);

            Assert.AreEqual(figure.Area, exp, accuracy);
            Assert.AreEqual(figure.FigureType, "Circle");
        }

        // Negative Circle Testss
        [TestCase(0)]
        [TestCase(-1)]
        [Test]
        public void CircleNegativeTests(double R)
        {
            Assert.Throws<ArgumentException>(() => new Circle(R));

        }
    }
}