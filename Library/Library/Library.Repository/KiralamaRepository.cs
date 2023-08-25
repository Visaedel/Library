using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Repository
{
    public class KiralamaRepository : RepositoryBase<Kiralama>
    {
        public KiralamaRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
