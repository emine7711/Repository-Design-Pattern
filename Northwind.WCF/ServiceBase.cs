using Northwind.DTO;
using Northwind.Entity;
using Northwind.Extensions;
using Northwind.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Northwind.WCF
{
    public class ServiceBase<Rep, Entity, DTO> : IService<DTO> 
        where DTO : class
        where Entity:class
        where Rep:RepositoryBase<Entity>
    {
        //Rep:RepositoryBase<Entity> ServiceBase in Rep hareket tipi RepositoryBase tipinde olduğu belirtildiği için ServiceBase sınıfını kullandığımız yerlerde Rep hareket tipi iin ProductRepository,CategoryRepository Supp yazılabilir.

        //ServiceBase sınıfı repositorybase sınıfına talepleri gönderen ve repositorybase sınıfından response'ları alan bir sınıftır.ServiceBase sınıfının hangi RepositoryBase sınıfı(ProductRepository mi,CategoryRepository mi?) ile iletişimde olduğunu bilmek gerekir.Ayrıca ServiceBase sınıfı client'a DTO nesnesi yollamalı ve clienttn gelen DTO nesnesini RepositoryBase sınıfına gönderirken Entity'ye dönüştürmesi gerekir.

        //ServiceBase'in hem repository tipi hem entity tipi hem de DTO tipi argümanlarına ihtiyacı vardır.

        private Rep repository;

        public Rep Repository
        {
            get
            {
                //Generic tip için instance oluşturmak istediğimizde 
                //repositry=new Rep 
                //gibi bir işlem yapamıyoruz. Generic tip için instance oluşturmada kullanılacak classın adı Activator ve metodun adı CreateInstance isimli generic metottur.
                //CreateInstance<Rep>(): Rep dışarıdan alınan tiptir ve instance bu tip için üretilecektir
                repository = repository ?? Activator.CreateInstance<Rep>();
                return repository;
            }
            set
            {
                repository = value;
            }
        }
        public bool Adding(DTO dto)
        {
            //Repository.Adding(dto);

            return Repository.Adding(dto.Changer<Entity>());
        }

        public bool Deleting(DTO dto)
        {
            return Repository.Deleting(dto.Changer<Entity>());
        }

        public List<DTO> Listing()
        {
            //ServiceBase'den RepositoryBase'e talep gönderilecektir
            //throw new NotImplementedException();
            //return Repository.Listing()
            //Service katmanımız Repository den Entity alır. Öncelikle alınan entitylerin DTO nesnesine dönüştürlmesi gerekir.
            //Bizim DTO-to-Entity ve Entity-to-DTO çevrimine ihtiyacımız var.

            //d.Changer<Product>();: d.'nın anlamı Changer metoduna hangi kaynak üzerinden ulaştığınızı gösterir.Yani changer a ürünler DTO üzerinden ulaşıyorsunuz.Başka bir deyişle ProductDTO nesnesini Product nesnesine dönüştürüyorsunuz

            //<Product>(): Changer metodunun dışarıdan istediği argüman tipini gösterir. Changer hangi tipe dönüştürülecekse argüman tipi olarak o tip verilir.

            //Changer metodunun return tipini gösterir.

            //Deneme Kodları:
            //ProductDTO d = new ProductDTO();
            //Product prod = d.Changer<Product>();

            //Product p = new Product();
            //ProductDTO pdt = p.Changer<ProductDTO>();

            //Product p = new Product();
            //p.ProductName = "MyAvokado";
            //p.UnitPrice = 19;
            //p.UnitsInStock = 199;
            //ProductDTO dt = p.Changer<ProductDTO>();

            return Repository.Listing().Select(x => x.Changer<DTO>()).ToList();
            
        }

        public bool Updating(DTO dto)
        {
            //throw new NotImplementedException();
            return Repository.Updating(dto.Changer<Entity>());
        }
    }
}