# V4.0
## Изменено:
  1. Представление сторон треугольника и прямоугольника, теперь вместо массива сторон - отдельные стороны. 
  2. Добавлены проверки и обновление полей Area и IsRight при изменении длины стороны уже существующей фигуры.
  3. Убрана логика с выставлением _area в 0 при изменении стороны.


# ShapeAreaLibraryV3.0
## Задание №1 ( Библиотека классов )
**Используем фабрику для создания однотипных объектов со своими особенностями. В ней, определяем тип фигуры по количеству входных параметров. Для примера добавление новой фигуры добавлен Прямоугольник (Rectangle).**
## Задание №2 ( Выборка SQL )
## *Для начала создадим обе базовые таблицы*
____
**Таблица Products с полями id (автоинкремент) и Naming (названием продукта)**
```SQL
CREATE TABLE Products (
  id INT IDENTITY(1,1) PRIMARY KEY,
  Naming NVARCHAR(50) NOT NULL
);
```
____
**Таблица Catogories с полями id (автоинкремент) и Naming (названием категории)**
```SQL
CREATE TABLE Categories (
  id INT IDENTITY(1,1) PRIMARY KEY,
  Naming NVARCHAR(50) NOT NULL
);
```
____
**Теперь, необходимо создать связующую таблицу, в которой будут поля id_product и id_category, а также добавить внешний ключ на соответствующие им поля из таблиц Products и Categories.**
**Таблица Catogories с полями id (автоинкремент) и Naming (названием категории)**
```SQL
CREATE TABLE Prod_Linking_Cat (
  id INT IDENTITY(1,1) PRIMARY KEY,
  id_product INT NOT NULL,
  id_category INT NOT NULL,
  FOREIGN KEY (id_product) REFERENCES Products(id),
  FOREIGN KEY (id_category) REFERENCES Categories(id)
);
```
____
## *Теперь,когда все таблицы созданы, можно писать сам запрос*
**В запросе делаем выборку наименований продуктов и наименований категорий из таблицы продуктов,связанной с таблицей категорий через связующую таблицу. Благодаря LEFT JOIN , даже если в связующей таблице не будут найдены продукты с соответствующим id, продукт все равно будет добавлен в итоговую таблицу. Также, это значит,что даже если у продукта не будет категории в связующей таблице, то вместо категории будет по стандарту выведен "NULL".**
```SQL
SELECT Products.Naming as "Продукт", Categories.Naming as "Категория" FROM Products
LEFT JOIN Prod_Linking_Cat ON Products.id = Prod_Linking_Cat.id_product
LEFT JOIN Categories ON Categories.id = Prod_Linking_Cat.id_category
```
____
