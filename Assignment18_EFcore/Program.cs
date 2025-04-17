using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment18_EFcore
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
       
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<School> Schools { get; set; }
    }

    public class School
    {
        public int Id { get; set; }
        public int deptId { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public Department dept { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TeacherTransfer> FromTransfers { get; set; }
        public List<TeacherTransfer> ToTransfers { get; set; }  
    }


    public class Teacher
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int NationalID { get; set; }
        public string Code { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }
        public string Qualification { get; set; }
        public DateTime QualificationDate { get; set; }
        public DateTime HiringDate { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }

        public School School { get; set; }
        public List<TeacherTransfer> TeacherTransfers { get; set; }
    }

    public class TeacherTransfer
    {
        public int Id { get; set; }
        public int TeacherID { get; set; }
        public int FromSchoolID { get; set; }
        public int ToSchoolID { get; set; }
        public DateTime Date { get; set; }

        public Teacher Teacher { get; set; }
        public School FromSchool { get; set; }
        public School ToSchool { get; set; }
    }

}
