using System;
using System.Linq;

class Program
{
    static Group group = new Group();

    static void Main()
    {
        Console.WriteLine("=== СИСТЕМА СТУДЕНТОВ ===\n");

        // Создаем группу
        Console.Write("Введите название группы: ");
        group.Name = Console.ReadLine();

        // Добавляем предметы
        Console.WriteLine("\nДобавьте предметы (пустая строка - закончить):");
        while (true)
        {
            Console.Write("Предмет: ");
            string subject = Console.ReadLine();
            if (string.IsNullOrEmpty(subject)) break;
            group.Subjects.Add(subject);
        }

        // Добавляем студентов
        Console.WriteLine("\nДобавьте студентов (пустая строка - закончить):");
        while (true)
        {
            Console.Write("Имя студента: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name)) break;

            var student = new Student { Name = name };

            // Добавляем оценки
            foreach (var subject in group.Subjects)
            {
                Console.Write($"  {subject}: ");
                if (int.TryParse(Console.ReadLine(), out int grade))
                    student.Grades[subject] = grade;
            }

            group.Students.Add(student);
        }

        // Показываем результаты
        Console.WriteLine($"\n=== ГРУППА {group.Name} ===");
        foreach (var student in group.Students)
            student.Display();

        // Статистика
        if (group.Students.Count > 0)
        {
            var avg = group.Students.Average(s => s.GetAverage());
            var best = group.Students.OrderByDescending(s => s.GetAverage()).First();

            Console.WriteLine($"\nСредний по группе: {avg:F1}");
            Console.WriteLine($"Лучший: {best.Name} ({best.GetAverage():F1})");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}