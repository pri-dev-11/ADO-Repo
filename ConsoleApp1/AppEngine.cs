using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{

    interface AppEngine
    {
        void introduce(Course course);
        void register(Student student);
        List<Student> listOfStudents();
        void enroll(Student student, Course course);
        List<Enroll> listOfEnrollments();
    }
    class InMemoryAppEngine : AppEngine
    {
        static string connStr = @"Data Source = DESKTOP-IGV8CBD; Database=assignment; integrated security=true;MultipleActiveResultSets=True";
        SqlConnection conn = new SqlConnection(connStr);
        public void introduce(Course course)
        {
            int cid = course.cid;
            string cname = course.cname;
            float cduration = course.cduration;
            float cfees = (float)course.cfees;
            float cMFee = (float)course.cMonthFee;
            string cquery = "Insert into Course Values(@cid,@cname,@cduration,@cfees,@cMFee)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(cquery, conn);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@cname", cname);
            cmd.Parameters.AddWithValue("@cduration", cduration);
            cmd.Parameters.AddWithValue("@cfees", cfees);
            cmd.Parameters.AddWithValue("@cMFee", cMFee);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Insertion was successful!!!!");
            }
            conn.Close();

        }
        public void register(Student student)
        {

            int id = student.Id;
            string name = student.Name;
            string dob = student.DateOfBirth.ToString("dd MMMM yyyy ");
            int fees = student.Fees;
            string CollegeName = Student.collegeName;
            string query = "Insert into Student Values(@id,@name,@dob,@fees,@ColName)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@fees", fees);
            cmd.Parameters.AddWithValue("@ColName", CollegeName);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Insertion was successful!!!!");
            }
            conn.Close();
        }
        public void enroll(Student student, Course course)
        {
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Select Count(*) from Enroll",conn);
            int count = (int)cmd2.ExecuteScalar();
            conn.Close();
            int id = student.Id;
            string name = student.Name;
            string dob = student.DateOfBirth.ToString("dd MMMM yyyy ");
            int fees = student.Fees;
            string CollegeName = Student.collegeName;
            int cid = course.cid;
            string cname = course.cname;
            float cduration = course.cduration;
            float cfees = (float)course.cfees;
            float cMFee = (float)course.cMonthFee;
            string query1 = "Select * From Enroll";
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                if((int)reader[0]==id && (int)reader[5] == cid)
                {
                    throw new AlreadyEnrolled("You are already enrolled in this course. Please enroll in a different course.");
                }
                else if(count>50)
                {
                    throw new LimitExceeded("Sorry. The course is full. Please enroll in a different course.");
                }
            }
            conn.Close();
            
            conn.Open();
            string query2 = "Insert into Enroll Values(@id,@name,@dob,@fees,@ColName,@cid,@cname,@cduration,@cfees,@cMFee)";
            SqlCommand cmd = new SqlCommand(query2, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@fees", fees);
            cmd.Parameters.AddWithValue("@ColName", CollegeName);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@cname", cname);
            cmd.Parameters.AddWithValue("@cduration", cduration);
            cmd.Parameters.AddWithValue("@cfees", cfees);
            cmd.Parameters.AddWithValue("@cMFee", cMFee);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Insertion was successful!!!!");
            }
            conn.Close();
        }
        public List<Student> listOfStudents()
        {
            List<Student> los = new List<Student>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Student", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student s1 = new Student();
                s1.Id = (int)reader[0];
                s1.Name = (string)reader[1];
                s1.DateOfBirth = Convert.ToDateTime(reader[2]);
                s1.Fees = (int)reader[3];
                los.Add(s1);
            }
            conn.Close();
            return los;

        }
        public List<Enroll> listOfEnrollments()
        {
            List<Enroll> loe = new List<Enroll>();
            // I will add a loop with lot of options to add later
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Enroll", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Student s1 = new Student();
               
                s1.Name = (string)reader[1];
                s1.DateOfBirth = Convert.ToDateTime(reader[2]);
                s1.Fees = (int)reader[3];
                Course c1 = new Course();
                c1.cid = (int)reader[5];
                c1.cname = (string)reader[6];
                c1.cduration = (float)(double)reader[7];
                c1.cfees = (double)reader[8];
                c1.cMonthFee = (double)reader[9];
                Enroll e1 = new Enroll(s1, c1, new LocalDate());
                loe.Add(e1);

            }
            conn.Close();
            return loe;

        }
    }
    public class AlreadyEnrolled : ApplicationException
    {
        public AlreadyEnrolled() { }
        public AlreadyEnrolled(string msg) : base(msg) { }
    }
    public class LimitExceeded : ApplicationException
    {
        public LimitExceeded() { }
        public LimitExceeded(string msg) : base(msg) { }
    }
}
