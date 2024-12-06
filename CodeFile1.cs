using System;

// Абстрактна база для трансформацій
abstract class Transformation
{
    public abstract void SetNumbers(int a11, int a12, int a13, int a21, int a22, int a23);
    public abstract void Math(int x, int y, int z = 0);
}

// Будівельник для 3D трансформацій
class TransformationBuilder
{
    private int a11, a12, a13, a21, a22, a23;
    private int a14, a24, a31, a32, a33, a34;

    public TransformationBuilder Set2DNumbers(int a11, int a12, int a13, int a21, int a22, int a23)
    {
        this.a11 = a11;
        this.a12 = a12;
        this.a13 = a13;
        this.a21 = a21;
        this.a22 = a22;
        this.a23 = a23;
        return this;
    }

    public TransformationBuilder Set3DNumbers(int a14, int a24, int a31, int a32, int a33, int a34)
    {
        this.a14 = a14;
        this.a24 = a24;
        this.a31 = a31;
        this.a32 = a32;
        this.a33 = a33;
        this.a34 = a34;
        return this;
    }

    public Transformation Build()
    {
        return new T3D(a11, a12, a13, a21, a22, a23, a14, a24, a31, a32, a33, a34);
    }
}

// Реалізація 2D трансформації
class T2D : Transformation
{
    protected int a11, a12, a13, a21, a22, a23;

    public override void SetNumbers(int a11, int a12, int a13, int a21, int a22, int a23)
    {
        this.a11 = a11;
        this.a12 = a12;
        this.a13 = a13;
        this.a21 = a21;
        this.a22 = a22;
        this.a23 = a23;
    }

    public override void Math(int x, int y, int z = 0)
    {
        int tempx = a11 * x + a12 * y + a13;
        int tempy = a21 * x + a22 * y + a23;
        Console.WriteLine($"Результат 2D: x = {tempx}, y = {tempy}");
    }
}

// Реалізація 3D трансформації
class T3D : T2D
{
    private int a14, a24, a31, a32, a33, a34;

    public T3D(int a11, int a12, int a13, int a21, int a22, int a23, int a14, int a24, int a31, int a32, int a33, int a34)
    {
        SetNumbers(a11, a12, a13, a21, a22, a23);
        this.a14 = a14;
        this.a24 = a24;
        this.a31 = a31;
        this.a32 = a32;
        this.a33 = a33;
        this.a34 = a34;
    }

    public override void Math(int x, int y, int z = 0)
    {
        if (z == 0)
        {
            base.Math(x, y); // Викликаємо метод для 2D
        }
        else
        {
            int tempx = a11 * x + a12 * y + a13 * z + a14;
            int tempy = a21 * x + a22 * y + a23 * z + a24;
            int tempz = a31 * x + a32 * y + a33 * z + a34;
            Console.WriteLine($"Результат 3D: x = {tempx}, y = {tempy}, z = {tempz}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Перевірка остачі від ділення на 3 для варіанту 25
        int choice = 25;

        if (choice % 3 == 1) // Будівельник
        {
            Console.WriteLine("Будівельник трансформацій 3D");

            // Використовуємо будівельник
            TransformationBuilder builder = new TransformationBuilder();

            // Попросимо користувача ввести значення для 2D та 3D
            Console.WriteLine("Введіть параметри для 2D трансформації (a11, a12, a13, a21, a22, a23):");
            int a11 = int.Parse(Console.ReadLine());
            int a12 = int.Parse(Console.ReadLine());
            int a13 = int.Parse(Console.ReadLine());
            int a21 = int.Parse(Console.ReadLine());
            int a22 = int.Parse(Console.ReadLine());
            int a23 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введіть параметри для 3D трансформації (a14, a24, a31, a32, a33, a34):");
            int a14 = int.Parse(Console.ReadLine());
            int a24 = int.Parse(Console.ReadLine());
            int a31 = int.Parse(Console.ReadLine());
            int a32 = int.Parse(Console.ReadLine());
            int a33 = int.Parse(Console.ReadLine());
            int a34 = int.Parse(Console.ReadLine());

            builder.Set2DNumbers(a11, a12, a13, a21, a22, a23)
                   .Set3DNumbers(a14, a24, a31, a32, a33, a34);

            Transformation transformation = builder.Build();

            // Введення координат для Math
            Console.WriteLine("Введіть координати:");
            try
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                int z = int.Parse(Console.ReadLine());

                transformation.Math(x, y, z); // Виклик для 3D
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка вводу! Введіть числа.");
            }
        }
        else
        {
            Console.WriteLine("Невірний варіант для цього завдання.");
        }
    }
}
