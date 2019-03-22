/*
 * Lab5 
 * Классы. Наследование
 * 
 * Часть 1. Реализовать наследника класса Person:
 *   - Сотрудник (Employee):
 *     - поле Отдел - название отдела, где работает сотрудник;
 *     - поле Должность - название должности, на которой работает сотрудник;
 *     - поле Зарплата - вещественное число;
 *     - метод ToString() - выводит должность, ФИО и отдел.
 *   Предусмотреть методы изменения данных сотрудника.
 * 
 * Часть 2. Заполнить массив Person[] случайными объектами (Person, Student, Employee). В этом массиве:
 *   - Найти сотрудника с минимальной зарплатой,
 *   - Вывести список студентов первого курса.
 */
using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab5
{
    class Program
    {
        /// <summary>
        /// Gets the random person.
        /// </summary>
        /// <returns>The random person.</returns>
        /// <param name="names">Names.</param>
        /// <param name="uid">Uid.</param>
        // TODO: static Person GetRandomPerson(string[][] names, uint uid);
        static Person GetRandomPerson(string[] names, uint uid)
        {
            Random rnd = new Random();
            Gender gender;
            int rndValue = rnd.Next(2);
            if (rndValue == 1)
                gender = Gender.Male;
            else
                gender = Gender.Female;
            string name = names[rnd.Next(names.Length)];
            string surname = names[rnd.Next(names.Length)];
            if (gender == Gender.Male)
            {
                surname += "ов";                
            }
            else
            {
                name += "а";
                surname += "ова";
            }
            Person person = new Person(gender, name, surname);
            Thread.Sleep(100);
            switch (rnd.Next(3))
            {
                case 0:
                    return person;
                case 1:
                    return new Student(person, "TRACK",(uint) rnd.Next(1, 5), (uint)rnd.Next(1, 6));
                case 2:
                    return new Employee(person, "DEPARTMENT", "JOBTITLE", rnd.Next(10000, 200001));
            }
            return person;
        }

        static Employee MinEmployee(List<Person> people)
        {
            Employee MinEmp = new Employee("","","",Gender.Male,"","",0);
            foreach (var man in people)
            {
                if (man is Employee employee)
                {
                    MinEmp = employee;
                    break;
                }
            }
            foreach (var man in people)
            {
                if (man is Employee employee)
                {
                    if (employee.Salary < MinEmp.Salary)
                        MinEmp = employee;
                }
            }
            return MinEmp;
        }
        static void OutFirstCourse(List<Person> people)
        {
            foreach (var man in people)
                if (man is Student std)
                    if (std.Course == 1)
                        Console.WriteLine(man);
        }
        static void Main(string[] args)
        {
            Student stud = new Student("Иван", "Иванов", "Иванович", Gender.Male, "ПОКС", 1, 2);

            // ToString() вызывается автоматически при преобразовании к строке
            Console.WriteLine(stud);
            // ToString() - виртуальная функция: будет позднее связывание
            Console.WriteLine(stud as Person);

            // FullName - не виртуальное свойство: будет раннее связывание
            Console.WriteLine(stud.FullName);
            Console.WriteLine((stud as Person).FullName);
            string[] names = { "Кирилл", "Денис", "Андрей", "Сергей", "Богдан", "Артем", "Гавриил" };
            List<Person> list = new List<Person>();
            for (int i = 0; i < 20; i++)
                list.Add(GetRandomPerson(names, (uint)new Random().Next()));
            Employee MinEmp = MinEmployee(list);

            Console.WriteLine("Список людей:");
            foreach(var man in list)
                Console.WriteLine(man);
            Console.WriteLine();
            Console.WriteLine($"{MinEmp.FullName} - работник с минимальной зп в {MinEmp.Salary}");
            Console.WriteLine();
            Console.WriteLine("Список студентов 1 курса:");
            OutFirstCourse(list);
            // Вызов статического метода
            //Person pers = Person.Read(Console.In);
            //Student std = Student.Read(Console.In);
            //Student stud2 = new Student(pers, "БТ", 3, 1);
            //Console.WriteLine((std as Person).FullName);
            //Console.WriteLine(std);
            //Employee emp = new Employee(pers, "ИТ", "Заведующий", 20000);
            //Employee emp1 = Employee.Read(Console.In);
            //Console.WriteLine(stud);
            //Console.WriteLine(emp1);
            Console.ReadKey();
        }
    }
}
