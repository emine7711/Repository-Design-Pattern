using Northwind.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repository
{
    public class RepositoryBase<TT> : IRepository<TT> where TT:class
    {
        //RepositoryBase classında contexte ihtiyacımız var.Bu yüzden Northwind.Repository projemize Northwind.Entity projesini referans olarak eklememiz gerekir.

        //Singleton Pattern mimarisi uygulamanın tek context ya da tek connection üzerinden işlem yapmasının sağlandığı design pattern(tasarım deseni)dır.
        //Sık bağlantı açılıp kapatılan uygulamalarda bu işlemler SQL server agereksiz yük bindirir. Bunun yerine hazırda context nesnesi var mı bakılır, eğer yoksa yeniden oluşturulur.Varsa varolan kullanılır.

        private NorthwindEntities context;

        public NorthwindEntities Context
        {
            get
            {
                //if (context==null)
                //{
                //    context = new NorthwindEntities();
                //}
                
                return context ?? (context = new NorthwindEntities());//yukarıdaki ile aynı şey
            }
            set
            {
                context = value;
            }
        }

        public bool Adding(TT entity)
        {
            //Set<TT>: Context in TT tipini algılamasını sağlar
            Context.Set<TT>().Add(entity);
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool Deleting(TT entity)
        {
            Context.Set<TT>().Remove(entity);
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<TT> Listing()
        {
            //Product entity'si gelirse Product'lar, Category entity'si gelirse Categori'ler listelenecek.
            return Context.Set<TT>().ToList();
        }

        public bool Updating(TT entity)
        {
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
