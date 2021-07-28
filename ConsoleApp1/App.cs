using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace ConsoleApp1
{
    
    class App
    {
        
       
        static void Main(string[] args)
        {

            /*InMemoryAppEngine imae2 = new InMemoryAppEngine();
            Student s1 = new Student();
            Course c1 = new Course();
            c1.CalculateMonthlyFee();
            imae2.register(s1);
            imae2.introduce(c1);
            imae2.enroll(s1, c1);
            List<Student> los = imae2.listOfStudents();
            List<Enroll> loe = imae2.listOfEnrollments();
            foreach (Student stud in los)
            {
                   Console.WriteLine(stud.Name);
            }
            foreach (Enroll e1 in loe)
            {
                e1.display();
            }
            Student[] stud = new Student[5];
            for(int i=0;i<5;i++)
            {
                stud[i] = new Student();
                stud[i].Display();
            }
            InMemoryAppEngine iae1 = new InMemoryAppEngine();
            Course c1 = new DegCourse();
            c1.cid = 2;
            c1.cname = "cour2";
            c1.cfees = 24000;
            c1.cduration = 2;
            c1.CalculateMonthlyFee();
            iae1.introduce(c1);
            iae1.register(new Student());
            Student s2 = new Student("stud2", d1, 2900);
            Console.WriteLine(s2.Id);
            s2.Id = 3;
            

            InMemoryAppEngine iae1 = new InMemoryAppEngine();
            
            List<Student> ls1 = iae1.listOfStudents();
            foreach(Student stud in ls1)
            {
                stud.Display();
            }
            */

            InMemoryAppEngine iae1 = new InMemoryAppEngine();
            iae1.enroll(new Student(), new Course());
        }

    }
}


