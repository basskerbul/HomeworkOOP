//Реализовать класс для описания здания (уникальный номер здания, высота, этажность, количество квартир, 
//подъездов). Поля сделать закрытыми, предусмотреть методы для заполнения полей и получения значений полей 
//для печати. Добавить методы вычисления высоты этажа, количества квартир в подъезде, количества квартир 
//на этаже и т.д. Предусмотреть возможность, чтобы уникальный номер здания генерировался программно. 
//Для этого в классе предусмотреть статическое поле, которое бы хранило последний использованный номер 
//здания, и предусмотреть метод, который увеличивал бы значение этого поля.

Building myHome = new Building();
myHome.BuildHeig = 45;
myHome.Floors = 6;
myHome.AllApart = 30;
myHome.Entrance = 5;
myHome.Info();
Console.WriteLine($"Кол-во квартир в подьезде: {myHome.ApartInEntra()}");
Console.WriteLine($"Кол-во квартир на этаже: {myHome.ApartInFloor()}");
Console.WriteLine($"Высота одного этажа: {myHome.HeightCalc()}");
Console.WriteLine($"{myHome.BuildNumber}");

Building home1 = new Building();
home1.BuildHeig = 50;
home1.Floors = 5;
home1.AllApart = 38;
home1.Entrance = 2;
home1.Info();
Console.WriteLine($"Кол-во квартир в подьезде: {home1.ApartInEntra()}");
Console.WriteLine($"Кол-во квартир на этаже: {home1.ApartInFloor()}");
Console.WriteLine($"Высота одного этажа: {home1.HeightCalc()}");
Console.WriteLine($"{home1.BuildNumber}");

class Building
{
    static private int buildNumber = 1;
    private int buildHeig;
    private int floors;
    private int allApart;
    private int entrance;

    public int BuildNumber
    {
        get { return buildNumber++; }
    }
    //6 - минимальная высота дома
    public int BuildHeig
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
    public int Floors
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
    public int AllApart
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
    public int Entrance
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
    }
    /// <summary>
    /// Вычисление высоты этажа
    /// </summary>
    /// <returns></returns>
    public int HeightCalc()
    {
        return (buildHeig / floors);
    }
    /// <summary>
    /// Вычисление квартир в подъезде
    /// </summary>
    /// <returns></returns>
    public int ApartInEntra()
    {
        return  allApart / entrance;
    }
    /// <summary>
    /// Вычисление количества квартир на этаже
    /// </summary>
    /// <returns></returns>
    public int ApartInFloor()
    {
        int apartmens = ApartInEntra();
        apartmens /= floors;
        return apartmens;
    }
}