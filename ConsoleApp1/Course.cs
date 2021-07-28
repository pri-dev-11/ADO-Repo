using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Course
    {
        public int cid;
        public string cname;
        public float cduration;
        public double cfees;
        public double cMonthFee;

        public Course()
        {
            cid = 1;
            cname = "generic";
            cduration = 1;
            cfees = 10000;
        }

        public Course(int id, string name, float duration, double fees)
        {
            this.cid = id;
            this.cname = name;
            this.cduration = duration;
            this.cfees = fees;
        }

        public virtual void CalculateMonthlyFee()
        {
            cMonthFee = cfees / 12;
        }
        
        public void display()
        {
            Console.WriteLine("The name is {0}, the id is {1}, the duration is {2}, the fees is {3} and monthly fee is {4}.",cname, cid, cduration, cfees, cMonthFee);
        }
        
    }
    class DegCourse : Course
    {
        public enum level    // enums are constant
        {
            Bachelors = 10,
            Masters = 20
        };
        bool isPlacementAvailable;
        public double placeFees;

        public bool IsPlacementAvailable { get => isPlacementAvailable; set => isPlacementAvailable = value; }
        public DegCourse() : base()
        {
            isPlacementAvailable = false;
            placeFees = 0;
        }
        public DegCourse(int id, string name, float duration, double fees, bool isPlace) : base(id, name, duration, fees)
        {
            isPlacementAvailable = isPlace;

        }
        public override void CalculateMonthlyFee()
        {
            if (isPlacementAvailable)
            {
                placeFees = 0.1 * cfees;
                cfees += placeFees;
                cMonthFee = cfees / 12;
            }
            else
                cMonthFee = cfees / 12;
        }
        
    }

   class DipCourse : Course
    {
        public double processingFees;
        public int ct;
        enum type
        {
            professional = 1,
            academic = 0
        }
        public DipCourse() : base()
        {
            ct = 0;
            processingFees = 0.05 * cfees;
        }
        public DipCourse(int ct, int id, string name, float duration, double fees) : base(id, name, duration, fees)
        {
            if ((int)type.professional == ct)
            {
                processingFees = 0.1 * fees;
            }
            else
                processingFees = 0.05 * fees;
        }
        public override void CalculateMonthlyFee()
        {
            cfees += processingFees;
            cMonthFee = cfees / 12;
        }
        
        
    }
  public class Enroll  // class to show "has a" relationship
     {
        private Student stud;
        private Course cour;
        private LocalDate enrollmentDate;
        
        internal LocalDate EnrollmentDate { get => enrollmentDate; set => enrollmentDate = value; }
        public Student Stud { get => stud; set => stud = value; }
        public Course Cour { get => cour; set => cour = value; }

        public Enroll()
        {
            Student s1 = new Student();
            Stud = s1;
            Course c1 = new Course();
            Cour = c1;
            LocalDate ld1 = new LocalDate();
            EnrollmentDate = ld1;
        }
        public Enroll(Student s1,Course c1, LocalDate ld1)
        {
            Stud = s1;
            Cour = c1;
            EnrollmentDate = ld1;
        }
        public void display()
        {
            Console.WriteLine("The name is {0}, the id is {1}, the date of birth is {2}, the fees is {3} and college name is {4}.", Stud.Name, Stud.Id, Stud.DateOfBirth, Stud.Fees, Student.collegeName);
            Console.WriteLine("The course name is {0}, the course id is {1}, the duration is {2}, the fees is {3} and monthly fee is {4}.", Cour.cname, Cour.cid, Cour.cduration, Cour.cfees, Cour.cMonthFee);
            Console.WriteLine("The enroll date is {0} ", EnrollmentDate.EnrollD);
        }
    }

    public class LocalDate
    {
        DateTime enrollD;

        public DateTime EnrollD { get => enrollD; set => enrollD = value; }
       public LocalDate()
        {
            EnrollD = DateTime.UtcNow;
        }
        public LocalDate (DateTime enroll)
        {
            this.EnrollD = enroll;
        }
    }
}
