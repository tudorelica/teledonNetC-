using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teledonNet.Model;

namespace teledonNet.Interfaces
{
    interface Repository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);
        IEnumerable<E> FindAll();
        E Add(E entity);
        E Delete(ID id);
        E Update(E entity);
    }
}
