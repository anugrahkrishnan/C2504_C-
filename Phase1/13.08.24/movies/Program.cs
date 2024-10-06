using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Movies
{

   

    class Movie
    {
        public int id;
        public string name;

        public Movie(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public Movie()
        {
            id = 0;
            name = "";
        }

    }

   
    }
    internal class Program
    {
        static void Main(string[] args)
        {


            Movie ManjummelBoys = new Movie(1001, "ManjummelBoys");

            Movie Aavesham = new Movie();
            Aavesham.id = 1002;
            Aavesham.name = "Aavesham";

            
            Console.WriteLine($"ManjummelBoys:{ManjummelBoys.id} {ManjummelBoys.name} ");
            Console.WriteLine($"Aavesham:{Aavesham.id} {Aavesham.name} ");
            


        }
    }

}
