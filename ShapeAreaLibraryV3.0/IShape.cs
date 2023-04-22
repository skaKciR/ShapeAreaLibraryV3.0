namespace ShapeAreaLibraryV3._0
{
    public interface IShape
    {
        string FigureType { get; }
        double Area { get; }
        void CalculateArea();
        // Дополнительные методы и свойства
    }
}