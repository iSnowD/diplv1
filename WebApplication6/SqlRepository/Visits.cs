using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication6.Model
{
    public partial class SqlRepository
    {


        public IQueryable<Visits> Visits
        {
            get
            {
                return Db.Visits;
            }
        }

        public bool CreateVisit(Visits instance)
        {
            if (instance.ID == 0)
            {
                 
               
                // Db = new DataClasses1DataContext();
                // instance.BirthDate = DateTime.Parse("1900-1-1");

                Db.Visits.InsertOnSubmit(instance);
                Db.Visits.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateVisit(Visits instance)
        {
            Visits cache = Db.Visits.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {

                Db.Visits.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveVisit(int idVisits)
        {
            Visits instance = Db.Visits.Where(p => p.ID == idVisits).FirstOrDefault();
            if (instance != null)
            {


                Db.Visits.DeleteOnSubmit(instance);
                Db.Visits.Context.SubmitChanges();
                return true;
            }

            return false;
        }


      


    
    }
}
