using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teledonNet.Model
{
       [Serializable]
       public  class Donatie : Entity<int>
       {



        public Donatie()
        {
        
        }
        public Donatie(int ID_caz_caritabil, String nume_donator, String numar_telefon, Double suma) 
        {
            
            this.ID_caz_caritabil = ID_caz_caritabil;
            this.nume_donator = nume_donator;
            this.numar_telefon = numar_telefon;
            this.suma = suma;
        }

        public int ID_caz_caritabil { get; set; }
        public String nume_donator { get; set; }
        public String numar_telefon { get; set; }
        public Double suma { get; set; }

        public override string ToString()
        {
            return "{" +base.ToString() +  " " + nume_donator + " -> " + ID_caz_caritabil + " suma: " + suma + "}"; 
        }



    }
}
