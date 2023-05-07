using System;
using System.Collections;
interface IShape : IComparable<IShape>, ICloneable
{
    string GetName();
    float GetArea();
}

class Quadrilateral : IShape, ICloneable
{
    public string GetName()
    {
        return "Quadrilateral";
    }

    public float a { get; set; }
    public float b { get; set; }
    public float c { get; set; }
    public float d { get; set; }
    public float GetArea()
    {
        float perimeter = (a + b + c + d) / 2;
        return (float)Math.Sqrt((perimeter - a) * (perimeter - b) * (perimeter - c) * (perimeter - d));
    }

    public int CompareTo(IShape other)
    {
        return this.GetArea().CompareTo(other.GetArea());
    }

    public object Clone()
    {
        return new Quadrilateral { a = this.a, b = this.b, c = this.c, d = this.d };
    }

    public static bool operator <(Quadrilateral a, Quadrilateral b)
    {
        return a.GetArea() < b.GetArea();
    }

    public static bool operator >(Quadrilateral a, Quadrilateral b)
    {
        return a.GetArea() > b.GetArea();
    }
}

class Parallelogram : IShape, ICloneable
{
    public string GetName()
    {
        return "Parallelogram";
    }

    public float Base { get; set; }
    public float Height { get; set; }

    public float GetArea()
    {
        return Base * Height;
    }

    public int CompareTo(IShape other)
    {
        return this.GetArea().CompareTo(other.GetArea());
    }

    public object Clone()
    {
        return new Parallelogram { Base = this.Base, Height = this.Height };
    }

    public static bool operator <(Parallelogram a, Parallelogram b)
    {
        return a.GetArea() < b.GetArea();
    }

    public static bool operator >(Parallelogram a, Parallelogram b)
    {
        return a.GetArea() > b.GetArea();
    }
}

class Rhomb : IShape, ICloneable
{
    public string GetName()
    {
        return "Rhomb";
    }

    public float Diagonal1 { get; set; }
    public float Diagonal2 { get; set; }

    public float GetArea()
    {
        return (Diagonal1 * Diagonal2) / 2;
    }
    public int CompareTo(IShape other)
    {
        return this.GetArea().CompareTo(other.GetArea());
    }
    public object Clone()
    {
        return new Rhomb { Diagonal1 = this.Diagonal1, Diagonal2 = this.Diagonal2 };
    }
    public static bool operator <(Rhomb a, Rhomb b)
    {
        return a.GetArea() < b.GetArea();
    }

    public static bool operator >(Rhomb a, Rhomb b)
    {
        return a.GetArea() > b.GetArea();
    }
}
class Rectangle : IShape, ICloneable
{
    public string GetName()
    {
        return "Rectangle";
    }

    public float SideA { get; set; }
    public float SideB { get; set; }

    public float GetArea()
    {
        return SideA * SideB;
    }
    public int CompareTo(IShape other)
    {
        return this.GetArea().CompareTo(other.GetArea());
    }
    public object Clone()
    {
        return new Rectangle { SideA = this.SideA, SideB = this.SideB };
    }
    public static bool operator <(Rectangle a, Rectangle b)
    {
        return a.GetArea() < b.GetArea();
    }

    public static bool operator >(Rectangle a, Rectangle b)
    {
        return a.GetArea() > b.GetArea();
    }
}
class Square : IShape, ICloneable
{
    public string GetName()
    {
        return "Square";
    }

    public float Side { get; set; }

    public float GetArea()
    {
        return Side * Side;
    }
    public int CompareTo(IShape other)
    {
        return this.GetArea().CompareTo(other.GetArea());
    }
    public object Clone()
    {
        return new Square { Side = this.Side };
    }
    public static bool operator <(Square a, Square b)
    {
        return a.GetArea() < b.GetArea();
    }

    public static bool operator >(Square a, Square b)
    {
        return a.GetArea() > b.GetArea();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        try
        {
            IShape[] shapes = new IShape[10];

            // Додати об'єкти першої половини масиву
            shapes[0] = new Quadrilateral { a = 3, b = 4, c = 5, d = 6 };
            shapes[1] = new Parallelogram { Base = 10, Height = 5 };
            shapes[2] = new Rhomb { Diagonal1 = 8, Diagonal2 = 6 };
            shapes[3] = new Rectangle { SideA = 4, SideB = 8 };
            shapes[4] = new Square { Side = 7 };

            // Скопіювати об'єкти першої половини масиву та додати до другої половини
            for (int i = 0; i < 5; i++)
            {
                shapes[i + 5] = (IShape)((ICloneable)shapes[i]).Clone();
            }

            Console.WriteLine("\tMassive objects before sorting:");
            foreach (IShape shape in shapes)
            {
                Console.WriteLine("{0}: Area = {1}", shape.GetName(), shape.GetArea());
            }

            // Сортувати масив об'єктів за зростанням площі
            
            Console.WriteLine("\n\tMassive objects after sorting:");
            Array.Sort(shapes);
            foreach (IShape shape in shapes)
            {
                Console.WriteLine("{0}: Area = {1}", shape.GetName(), shape.GetArea());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occured! " + ex.Message);
        }
        Console.ReadLine();
    }   
}

