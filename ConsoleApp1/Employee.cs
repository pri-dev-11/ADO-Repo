using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Employee
    {
        public int eid;
        public int Empid { get { return eid; } set { eid = value; } }
        public string Empname { get; set; }
        public DateTime Doj { get; set; }
        public float Salary { get; set; }

        public virtual void Accept()
        {
            Console.WriteLine("Enter Empid,Empname,Doj,Salary");
            Empid = Convert.ToInt32(Console.ReadLine());
            Empname = Console.ReadLine();
            
            Doj = DateTime.Parse(Console.ReadLine());
            Salary = float.Parse(Console.ReadLine());
           
    }

        public void Display()
        {
            Console.WriteLine(Empid + " " + Empname + " " + Doj.ToShortDateString() + " " + Salary);
        }



        public void CalculateSal()
        {
            Console.WriteLine("Calculate Salary");
            Console.WriteLine(Salary);
        }
    }

    class PermanentEmp : Employee
    {
        public int hra { get; set; }
        public int da { get; set; }
        public float pf { get; set; }
        public override void Accept()
        {
            //base.Accept();  //for accessing base class if
            Console.WriteLine("Enter HRA,DA,PF");
            hra = Convert.ToInt32(Console.ReadLine());
            da = Convert.ToInt32(Console.ReadLine());
            pf = float.Parse(Console.ReadLine());
        }

        public void DispPermDetails()
        {
            Display();
            Console.WriteLine("HRA:" + hra);
            Console.WriteLine("DA:" + da);
            Console.WriteLine("PF:" + pf);
        }

        public void CalculatePermSal()
        {
            Salary = Salary + da + hra - pf;    
        }
    }



    class Contractors:Employee
    {
        public int numDays { get; set; }
        public int salDay { get; set; }
        public float taxPer { get; set; }
        public void GetContractorDetails()
        {
            Accept();
            Console.WriteLine("Enter numDays,salDay,taxPer");
            numDays = Convert.ToInt32(Console.ReadLine());
            salDay = Convert.ToInt32(Console.ReadLine());
            taxPer = float.Parse(Console.ReadLine());
        }
        public void CalculateContractorSal()
        {
            Salary =  Salary + numDays * salDay * ((100 - taxPer) / 100);
        }
        public void DispContractorDetails()
        {
            Display();
            Console.WriteLine("Number of Days worked:" + numDays);
            Console.WriteLine("Salary to be acquired per day:" + salDay);
            Console.WriteLine("Taxation:" + taxPer);
        }

    }
}