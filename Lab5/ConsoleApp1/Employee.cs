using System;
using System.IO;
using System.Text;

namespace Lab5
{
    /* TODO: public class Employee */
    public class Employee : Person
    {
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public double Salary { get; set; }

        public Employee(string firstname, string lastname, string patronum, Gender gender,
            string Department, string JobTitle, double Salary) : base(gender, firstname, lastname, patronum)
        {
            this.Department = Department;
            this.JobTitle = JobTitle;
            this.Salary = Salary;
        }
        public Employee(Person p, string Department, string JobTitle, double Salary) :
            this(p.Firstname, p.Lastname, p.Patronim, p.Gender, Department, JobTitle, Salary)
        {}

        public static new Employee Read(TextReader input)
        {
            string str = input.ReadLine();
            StringReader reader = new StringReader(str);
            Person tempper = Person.Read(reader);
            string[] components = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] jobComponents = components[2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (jobComponents.Length < 3)
                throw new FormatException("Unaxpected lenght");
            string department = null;
            string jobTitle = null;
            double salary = 0;
            try
            {

                department = jobComponents[0];
                jobTitle = jobComponents[1];
                salary = double.Parse(jobComponents[2]);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Unaxpected format exception");
            }
            return new Employee(tempper, department,jobTitle,salary);
        }

        public new string FullName
        {
            get
            {
                return this.lastname + " " + this.firstname;
            }
        }

        public string GetJobInfo
        {
            get
            {
                return String.Join(" ", Department, JobTitle, Salary);
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}; {GetJobInfo}";
        }

    }
      
}
