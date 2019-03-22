
using System;
using System.IO;
using System.Text;

namespace Lab5
{
    /// <summary>
    /// Класс студент.
    /// </summary>
    public class Student : Person
    {
        protected uint course;
        protected uint group;
        protected string track;

        protected uint accessCardNum;

        public Student(string firstname, string lastname, string patronim, Gender gender,
                       string track, uint course, uint group) : base(gender, firstname, lastname, patronim)
        {
            this.track = track;
            this.course = course;
            this.group = group;

            // IAccessCardHolder
            this.accessCardNum = (uint) new Random().Next();
        }

        public Student(Person p, string track, uint course, uint group) : 
            this(p.Firstname, p.Lastname, p.Patronim, p.Gender, track, course, group)
        {}

        /// <summary>
        /// Read the specified input.
        /// </summary>
        // TODO: public static new Student Read(TextReader input);
        public static new Student Read(TextReader input)
        {
            string str = input.ReadLine();
            StringReader reader = new StringReader(str);
            Person tempper = Person.Read(reader);
            string[] components = str.Split(';');
            string[] trackComponents = components[2].Split('-');
            if (trackComponents.Length < 2)
                throw new FormatException("Unaxpected lenght");
            if (trackComponents[1].Length != 2)
                throw new FormatException("Unaxpected group or course");
            string group = trackComponents[1][1].ToString();
            string course = trackComponents[1][0].ToString();
            string track = trackComponents[0];
            return new Student(tempper, track, uint.Parse(course), uint.Parse(group));
        }
        /// <summary>
        /// Номер курса.
        /// </summary>
        public uint Course
        {
            get { return this.course; }
        }

        /// <summary>
        /// Номер группы.
        /// </summary>
        public uint Group
        {
            get { return this.group; }
        }

        /// <summary>
        /// Учебная программа.
        /// </summary>
        public string Track
        {
            get { return this.track; }
        }

        /// <summary>
        /// Название группы.
        /// </summary>
        public string GetGroupName()
        {
            // Пример работы со StringBuilder
            StringBuilder result = new StringBuilder();

            result.Append(track).Append("-").Append(course).Append(group);

            return result.ToString();
        }

        /// <summary>
        /// Полное имя студента.
        /// </summary>
        public new string FullName // закрывает метод базового класса Person
        {
            get
            {
                return this.lastname + " " + this.firstname;
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Lab5.Student"/>.
        /// </summary>
        public override string ToString()
        {
            return $"{base.ToString()}; {GetGroupName()}";
        }

    }
}
