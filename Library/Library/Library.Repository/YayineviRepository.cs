using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Repository
{
    public class YayineviRepository : RepositoryBase<Yayinevi>
    {
        public YayineviRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
