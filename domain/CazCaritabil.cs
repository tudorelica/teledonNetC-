using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teledonNet.Model
{
       [Serializable]
       public  class CazCaritabil : Entity<int>
       {



        public CazCaritabil()
        {
        
        }
        public CazCaritabil(String titlu, String descriere) 
        {
            
            this.titlu = titlu;
            this.descriere = descriere;
            this.sum = 0;

        }

        public CazCaritabil(int id,String titlu, String descriere) 
        {
            this.Id = id;
            this.titlu = titlu;
            this.descriere = descriere;
            this.sum = 0;

        }

        public String titlu { get; set; }
        public String descriere { get; set; }
        public Double sum { get; set; }

        public override string ToString()
        {
            return "{" +base.ToString() +  " " + titlu + ":\n" + descriere + "}"; 
        }



    }
}
