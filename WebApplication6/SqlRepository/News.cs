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

        public bool CreateNew(News instance)
        {
            if (instance.ID == 0)
            {
                instance.AddedDate = DateTime.Now;
              
                // Db = new DataClasses1DataContext();
                // instance.BirthDate = DateTime.Parse("1900-1-1");

                Db.News.InsertOnSubmit(instance);
                Db.News.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateNew(News instance)
        {
            News cache = Db.News.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {

                Db.News.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveNew(int idNews)
        {
            News instance = Db.News.Where(p => p.ID == idNews).FirstOrDefault();
            if (instance != null)
            {


                Db.News.DeleteOnSubmit(instance);
                Db.News.Context.SubmitChanges();
                return true;
            }

            return false;
        }



    }
}
