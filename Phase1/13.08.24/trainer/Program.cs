using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class1
{
    internal class Trainer
    {
        public int id;
        public string name;
        public string skill;
        public string location;
        public float salary;
    }
    internal class TrainerV2
    {
        private int id;
        private string name;
        private string skill;
        private string location;
        private float salary;

        // NO ARGUMENT CONSTRUCTOR
        public TrainerV2()
        {
            this.Id = 0;
            this.Name = "";
            this.Skill = "";
            this.Location = "";
            this.Salary = 0;
        }

        // CONSTRUCTOR WITH ARGUMENTS
        public TrainerV2(int id, string name, string skill, string location, float salary)
        {
            this.Id = id;
            this.Name = name;
            this.Skill = skill;
            this.Location = location;
            this.Salary = salary;
        }

        // GENERATED ENCAPSULATED ATTRIBUTES
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Skill { get => skill; set => skill = value; }
        public string Location { get => location; set => location = value; }
        public float Salary { get => salary; set => salary = value; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Trainer Mahesh = new Trainer();      // MAHESH OBJECT OF CLASS TRAINER
                Mahesh.id = 1;
                Mahesh.name = "Mahesh";
                Mahesh.skill = "c#";
                Mahesh.location = "mysore";
                Mahesh.salary = 9000;

            Trainer Mishel = new Trainer();      // MISHEL OBJECT OF CLASS TRAINER
                Mishel.id = 2;
                Mishel.name = "Mishel";
                Mishel.skill = "wpf";
                Mishel.location = "idukki";
                Mishel.salary = 11000;

            Console.WriteLine($"Mahesh:{Mahesh.id} {Mahesh.name} {Mahesh.skill} {Mahesh.location} {Mahesh.salary}");
            Console.WriteLine($"Mishel:{Mishel.id} {Mishel.name} {Mishel.skill} {Mishel.location} {Mishel.salary}");

            TrainerV2 MaheshV2 = new TrainerV2();   // with plain constructor
            MaheshV2.Id = 1;
            MaheshV2.Name = "Mahesh";
            MaheshV2.Skill = "c#";
            MaheshV2.Location = "mysore";
            MaheshV2.Salary = 9000;

            TrainerV2 MishelV2 = new TrainerV2(2, "Mishel", "wpf", "idukki",11000);    // with argument constructor

            Console.WriteLine($"MaheshV2:{MaheshV2.Id} {MaheshV2.Name} {MaheshV2.Skill} {MaheshV2.Location} {MaheshV2.Salary}");
            Console.WriteLine($"MishelV2:{MishelV2.Id} {MishelV2.Name} {MishelV2.Skill} {MishelV2.Location} {MishelV2.Salary}");

        }
    }
    
}
