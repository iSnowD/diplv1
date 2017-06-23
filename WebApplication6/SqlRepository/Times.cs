using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication6.Model
{
    public partial class SqlRepository
    {


        public IQueryable<Times> Times
        {
            get
            {
                return Db.Times;
            }
        }

        
    }
}
