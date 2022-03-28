//*Для реализованного класса создать новый класс Creator, который будет являться фабрикой объектов класса 
//здания. Для этого изменить модификатор доступа к конструкторам класса, в новый созданный класс добавить 
//перегруженные фабричные методы CreateBuild для создания объектов класса здания. В классе Creator все методы 
//сделать статическими, конструктор класса сделать закрытым. Для хранения объектов класса здания в классе 
//Creator использовать хеш-таблицу. Предусмотреть возможность удаления объекта здания по его уникальному 
//номеру из хеш-таблицы. Создать тестовый пример, работающий с созданными классами.

Building b1 = Creator.CreateBuild(12, 2, 4, 2);
b1.Info();

Building b2 = Creator.CreateBuild(122, 2, 5, 2);
b2.Info();

Creator.Crush(b1);

Console.ReadKey();


class Creator: Building
{
    static System.Collections.Hashtable buildings = new System.Collections.Hashtable();

    /// <summary>
    /// Создание объектов класса здания
    /// </summary>
    static public Building CreateBuild(int heig, int floors, int apart, int entran) 
    {
        Building build = new Building();
        build.BuildHeig = heig;
        build.Floors = floors;
        build.AllApart = apart;
        build.Entrance = entran;
        buildings.Add(build.BuildNumber, build);
        Console.WriteLine("Здание создано");
        return build;
    }

    /// <summary>
    /// Удаление объектов здания
    /// </summary>
    static public void Crush(Building b)
    {
        if (buildings.ContainsValue(b))
        {
            Console.WriteLine("Дом разрушен");
            buildings.Remove(b);
        }
        else
        {
            Console.WriteLine("Дома с таким номером в таблице нет");
        }
    }
}

class Building
{
    static private int buildNumber = 0;
    private int buildHeig;
    private int floors;
    private int allApart;
    private int entrance;

    internal int BuildNumber
    {
        get { return buildNumber++; }
    }
    //6 - минимальная высота дома
    internal int BuildHeig
    {
        set
        {
            if (value <= 6)
                Console.WriteLine("Здание слишком низкое");
            else
                buildHeig = value;
        }
        get { return buildHeig; }
    }
    internal int Floors
    {
        set
        {
            if (value < 1)
                Console.WriteLine("Не может быть меньше 1 этажа");
            else if (buildHeig / value < 6)
                Console.WriteLine("Здание слишком низкое для такого количества этажей");
            else
                floors = value;
        }
        get { return floors; }
    }
    internal int AllApart
    {
        set
        {
            if (value < 1)
                Console.WriteLine("Не может быть меньше 1 квартиры");
            else
                allApart = value;
        }
        get { return allApart; }
    }
    internal int Entrance
    {
        set
        {
            if (value < 1)
                Console.WriteLine("У дома должен быть минимум 1 вход");
            else
                entrance = value;
        }
        get { return entrance; }
    }
    /// <summary>
    /// Информация о полях
    /// </summary>
    public void Info()
    {
        Console.WriteLine($"Номер дома: {buildNumber}");
        Console.WriteLine($"Высота: {buildHeig}");
        Console.WriteLine($"Количество этажей: {floors}");
        Console.WriteLine($"Количество квартир: {allApart}");
        Console.WriteLine($"Колличество подъездов: {entrance}");
        Console.WriteLine($"Высота этажа: {HeightCalc()}");
        Console.WriteLine($"Количество квартир в подъезде: {ApartInEntra()}");
        Console.WriteLine($"Количество квартир на этаже: {ApartInFloor()}");
    }
    /// <summary>
    /// Вычисление высоты этажа
    /// </summary>
    /// <returns></returns>
    private protected int HeightCalc()
    {
        return (buildHeig / floors);
    }
    /// <summary>
    /// Вычисление квартир в подъезде
    /// </summary>
    /// <returns></returns>
    private protected int ApartInEntra()
    {
        return  allApart / entrance;
    }
    /// <summary>
    /// Вычисление количества квартир на этаже
    /// </summary>
    /// <returns></returns>
    private protected int ApartInFloor()
    {
        int apartmens = ApartInEntra();
        apartmens /= floors;
        return apartmens;
    }
}