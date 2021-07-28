using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student
    {
        static int count; 
        int id;
        string name;
        DateTime dateOfBirth;
        int fees;
        public static string collegeName;
        
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        
        public int Fees { get => fees; set => fees = value; }

        static Student()
        {
            collegeName = "IIIT Bhubaneswar ";
            count = 2;
        }
        public Student()
        {
            id = count++;
            Name = "generic";
            DateOfBirth = DateTime.Now;
            Fees = 10000;
        }
        public Student(string name1, DateTime dob, int fee)
        {
            id = count++;
            Name = name1;
            DateOfBirth = dob;
            
            Fees = fee;
        }
        public double calcMonthlyFees()
        {
            return Convert.ToDouble(this.Fees / 12);
        }

        public void Display()
        {
            Console.WriteLine("The name is {0}, the id is {1}, the date of birth is {2}, the fees is {3} and college name is {4}.", Name, id, DateOfBirth, Fees, Student.collegeName);
        }
    }
    public class Info
    {
        public void Display(Student S)
        {
            Console.WriteLine("Student Details:" + S.Name + " " + S.DateOfBirth);
           
            Console.WriteLine("Fees is: " + S.calcMonthlyFees());
        }
        public void Display(Enroll E)
        {
            E.display();
        }
    }
    
    
}
