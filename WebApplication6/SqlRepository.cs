using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace WebApplication6.Model
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public DataClasses1DataContext Db { get; set; }


    }
}