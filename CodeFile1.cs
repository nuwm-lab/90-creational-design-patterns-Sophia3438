using System;

// Абстрактні класи для студентів і викладачів
abstract class Student
{
    public abstract void Study();
}

abstract class Teacher
{
    public abstract void Teach();
}

// Абстрактна фабрика для створення студентів та викладачів
abstract class EducationFactory
{
    public abstract Student CreateStudent();
    public abstract Teacher CreateTeacher();
}

// Конкретна фабрика для ВНЗ
class UniversityFactory : EducationFactory
{
    public override Student CreateStudent()
    {
        return new UniversityStudent();
    }

    public override Teacher CreateTeacher()
    {
        return new UniversityTeacher();
    }
}

// Конкретна фабрика для військової академії
class MilitaryAcademyFactory : EducationFactory
{
    public override Student CreateStudent()
    {
        return new MilitaryAcademyStudent();
    }

    public override Teacher CreateTeacher()
    {
        return new MilitaryAcademyTeacher();
    }
}

// Конкретний студент для ВНЗ
class UniversityStudent : Student
{
    public override void Study()
    {
        Console.WriteLine("Студент ВНЗ навчається теоретично.");
    }
}

// Конкретний студент для військової академії
class MilitaryAcademyStudent : Student
{
    public override void Study()
    {
        Console.WriteLine("Студент військової академії проходить практичні тренування та дисциплінарні навчання.");
    }
}

// Конкретний викладач для ВНЗ
class UniversityTeacher : Teacher
{
    public override void Teach()
    {
        Console.WriteLine("Викладач ВНЗ проводить лекції з теорії.");
    }
}

// Конкретний викладач для військової академії
class MilitaryAcademyTeacher : Teacher
{
    public override void Teach()
    {
        Console.WriteLine("Викладач військової академії проводить тренування та бойові підготовки.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Оберіть тип навчального закладу (1 - ВНЗ, 2 - Військова академія):");
        int choice = int.Parse(Console.ReadLine());

        EducationFactory factory;

        if (choice == 1)
        {
            factory = new UniversityFactory();
        }
        else if (choice == 2)
        {
            factory = new MilitaryAcademyFactory();
        }
        else
        {
            Console.WriteLine("Невірний вибір.");
            return;
        }

        // Створення студентів та викладачів
        Student student = factory.CreateStudent();
        Teacher teacher = factory.CreateTeacher();

        // Використовуємо створених студентів та викладачів
        student.Study();
        teacher.Teach();
    }
}
