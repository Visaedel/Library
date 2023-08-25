using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class RollRepository : RepositoryBase<Roll>
    {
        public RollRepository(RepositoryContext context) : base(context)
        {

        }
        public void RollSil(int rollId)
        {
            RepositoryContext.Rolller.Where(r => r.RollId == rollId).ExecuteDelete();
            
        }
    }
}
