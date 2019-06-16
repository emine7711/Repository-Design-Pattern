using Northwind.DTO;
using Northwind.Entity;
using Northwind.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Northwind.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : ServiceBase<ProductRepository,Product,ProductDTO>
    {
       //ProductService isimli bir service oluşturunca, arka planda IProductService isimli interface oluşturur.ProductService servisimiz IProductService isimli interfaceden türetirsek yani Hiyerarşiyi bu şekilde bırakırsak,IService ve ServiceBase içindeki metotlar kullanılamayacak.Oysaki biz IService ve ServiceBase içindeki metotların tüm serviceler(Product,Category,Supplier için yazılacak) tekrar yazılmaması için oluşturmuştuk.
    }
}
