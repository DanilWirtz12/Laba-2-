using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public Dictionary<string, int> Grades { get; } = new Dictionary<string, int>();

    public double GetAverage() => Grades.Count > 0 ? Grades.Values.Average() : 0;

    public void Display()
    {
        Console.WriteLine($"\n{Name} | Средний: {GetAverage():F1}");
        foreach (var (subject, grade) in Grades)
            Console.WriteLine($"  {subject}: {grade}");
    }
}