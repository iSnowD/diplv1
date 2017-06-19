using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication6.Model
{
    public partial class SqlRepository
    {


        public IQueryable<News> News
        {
            get
            {
                return Db.News;
            }
        }

      

       
 
    }
}
