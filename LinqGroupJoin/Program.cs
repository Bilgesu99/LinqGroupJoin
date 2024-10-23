using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 5 Öğrenci Verisi
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 1 },
            new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 2 },
            new Student { StudentId = 4, StudentName = "Elif", ClassId = 3 },
            new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 2 }
        };

        // 3 Sınıf Verisi
        List<Class> classes = new List<Class>
        {
            new Class { ClassId = 1, ClassName = "1-A" },
            new Class { ClassId = 2, ClassName = "2-B" },
            new Class { ClassId = 3, ClassName = "3-C" }
        };

        // Group Join ile öğrencileri sınıflarına göre gruplama
        var classGroups = from c in classes
                          join s in students on c.ClassId equals s.ClassId into studentGroup
                          select new
                          {
                              ClassName = c.ClassName,
                              Students = studentGroup.Select(s => s.StudentName).ToList()
                          };

        // Sonuçları ekrana yazdırma
        foreach (var group in classGroups)
        {
            Console.WriteLine($"Sınıf: {group.ClassName}");
            Console.WriteLine("Öğrenciler:");

            foreach (var student in group.Students)
            {
                Console.WriteLine($" - {student}");
            }
            Console.WriteLine(); // Boşluk bırakmak için
        }
    }
}

// Öğrenci Sınıfı
class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int ClassId { get; set; }
}

// Sınıf Sınıfı
class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
}

