using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaLibraryV3._0
{
    /// <summary>
    /// Класс Фабрики
    /// </summary>
    public static class ShapeFactory
    {
        /// <summary>
        /// Фабричный метод создания фигуры на основе входных параметров
        /// </summary>
        /// <param name="parameters">Входные параметры</param>
        /// <returns>Возвращает экземпляр класса фигуры, в зависимости от количества входных данных</returns>
        /// <exception cref="ArgumentException">Нет фигуры с таким количеством параметров</exception>
        public static IShape CreateShape(params double[] parameters)
        {
            // Не проверяем входные параметры на > 0, т.к эта проверка реализована в классах фигур
            switch (parameters.Length)
            {
                case 1:
                    {
                        return new Circle(parameters[0]);
                    }
                case 2:
                    {
                        return new Rectangle(parameters[0], parameters[1]);
                    }
                case 3:
                    {
                        return new Triangle(parameters[0], parameters[1], parameters[2]);
                    }
                    // Новые фигуры здесь
                    
                    // Если такой фигуры нет выбросить исключение
                default:
                    {
                        throw new ArgumentException($"К сожалению, нет возможности создать фигуры с {parameters.Length} параметрами");
                    }
            }
        }
    }
}
