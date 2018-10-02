using System;
using System.Collections.Generic;
using System.Linq;

class AverageStudentGrades
{
    static void Main(string[] args)
    {
        int studentsCount = int.Parse(Console.ReadLine());
        Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

        for (int counter = 0; counter < studentsCount; counter++)
        {
            string[] studentArgs = Console.ReadLine()
                .Split();

            string name = studentArgs[0];
            double grade = double.Parse(studentArgs[1]);

            if (students.ContainsKey(name) == false)
            {
                students.Add(name, new List<double>());
            }

            students[name].Add(grade);
        }

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => $"{x:F2}"))} (avg: {student.Value.Average():F2})");
        }
    }
}