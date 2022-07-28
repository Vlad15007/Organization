using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee ia = new Employee("Черкис", "Владислав");
            Employee sotrydnic = new Employee("Владислав", "Черкис");


            Organization myOrganization = new Organization("Venus", 100.300);
            myOrganization.doljnosti = new Post[]
            {
                new Post() {sotrydnic = ia, NazvanieDoljnosti = "Генералисимус Директрус", Zarplata = 0 },
                new Post() {sotrydnic = sotrydnic, NazvanieDoljnosti = "Подчинёнус Директрус", Zarplata = 40 },
                new Post() {sotrydnic = new Employee("Человек", "Борис"), NazvanieDoljnosti = "Подчинёнус Директрус", Zarplata = 30 }
            };

            //myOrganization.Budjet += myOrganization.RabotaMesac("Mobile program");
            myOrganization.Budjet += myOrganization.RabotaMesac("Site");
            myOrganization.VuplataZarplat();

            Console.ReadKey();
        }
    }





    class Organization
    {
        public Post[] doljnosti { get; set; }
        public string NameOrganization { get; set; }
        public decimal Budjet { get; set; }

        public Organization(string name, double budjet)
        {
            NameOrganization = name;
            Budjet = (decimal)budjet;
        }

        public int RabotaMesac(string project)
        {
            int result = 0;
            if (project == "Site") result = 45;
            else if (project == "Mobile program") result = 70;

            return result;
        }

        public void VuplataZarplat()
        {
            Console.WriteLine("Бюджет организации : " + Budjet + "\n");
            foreach (Post kadr in doljnosti)
            {
                Budjet -= kadr.Zarplata;
                kadr.sotrydnic.ReturnInfo();
                Console.WriteLine("Должность : " + kadr.NazvanieDoljnosti);
                Console.WriteLine("Выплачено : " + kadr.Zarplata + "\n\n");
                
            }
            Console.WriteLine("Итого : " + Budjet + "\n");
        }
    }






    class Post
    {
        public Employee sotrydnic { get; set; }
        public string NazvanieDoljnosti { get; set; }
        public decimal Zarplata { get; set; }
    }





    class Employee
    {
        string familia;
        string imia;

        public Employee(string familia, string imia)
        {
            this.familia = familia;
            this.imia = imia;
        }

        public void ReturnInfo()
        {
            Console.WriteLine(familia);
            Console.WriteLine(imia);
        }
    }
}
