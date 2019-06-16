using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Northwind.WCF
{
    [ServiceContract]
    public interface IService<DTO> where DTO:class
    {
        //Service katmanı client'tan talebi alıp, Repository katmanına iletir.
        //IService interface i ve içerisinde tanımlı metotlar client ile iletişime geçeceği için Contract yani sözleşme içerisine dahil edilmesi gerekir

        //Bu katmanın olmasının sebebi,Client'ların direk olarak entity ve facade lara ulaşmaması içindir
        //Service katmanına client tarafından gelen nesneler DTO nesneleridir.(Entity nesneleri gelmez)

        //DTO katmanı Entity'lerin aynısı olacaktır,sadece DTO içinde serilize edilebilir nesneler barındırılır.
        //Client ile service arasında gidip/gelen nesnelerin serilize edilebilir olması gerekir.
        [OperationContract]
        List<DTO> Listing();
        [OperationContract]
        bool Adding(DTO dto);
        [OperationContract]
        bool Updating(DTO dto);
        [OperationContract]
        bool Deleting(DTO dto);


    }
}