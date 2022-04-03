using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teledonNet.Model
{
       [Serializable]
       public  class Voluntar : Entity<int>
       {



        public Voluntar()
        {
        
        }
        public Voluntar(String user, String password, String nume) 
        {
            
            this.username = user;
            this.password = password;
            this.nume = nume;

        }

        public String username { get; set; }
        public String password { get; set; }
        public String nume { get; set; }

        public override string ToString()
        {
            return "{" +base.ToString() +  " " + username + " " + nume + "}"; 
        }



    }
}
