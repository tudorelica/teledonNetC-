using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teledonNet.Model
{
    [Serializable]
    public class Entity<ID>
    {
     
        public ID Id { get; set; }

        public override string ToString()
        {
            return Id.ToString();

        }

    }
}
