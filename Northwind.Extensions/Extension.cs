using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Extensions
{
    //Extension metotlar ve bu metotların bulunduğu class'lar "static " olmalıdır.
    public static class Extension
    {
        //C# 'ta bulunan Object class'ının içine yeni bir metot ekleyeceğiz.
        //(this Object source):Object tipinin içerisine bu metot(Changer) eklenecektir.Bu yazım tarzı ile hali hazırda bulunan bir sınıfın içerisine dışarıdan bir metot eklemiş olacağız.Bundan sonra projenin içerisine herhangi bir sınıf eklendiğinde bu metot o sınıfın içinde otomatik olarak varmış gibi olacak.(Inheritance'dan dolayı).Kısacası bu gösterim extension metot gösterimidir.

        //T Changer<T>(this Object source): Source elemanı hangi instanec üzerinden . yazarak metoda ulaşıyorsa o instance'ı temsil eder.Biz changer metodu ile source elemanını T tipine dönüştüreceğiz.Ve geriye T tipinde eleman döndüreceğiz.

        //Product nesnesinin içindeki property'leri ProductDTO içerisine koyacağız, ProductDTO içerisindeki property'leri ise  Product nesnesinin içerisine koyacağız.

        /// <summary>
        /// Product nesnesinin içindeki property'leri ProductDTO içerisine koyacağız, ProductDTO içerisindeki property'leri ise  Product nesnesinin içerisine koyacağız.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Changer<T>(this object source)
        {
            //T Tipinde instance oluştur ve onu oluşan instance'ı yine T tipinde bir değişkene ata
            T target = Activator.CreateInstance<T>();

            Type targetType = target.GetType();
            PropertyInfo[] targetProperties = targetType.GetProperties();

            Type sourceType = source.GetType();
            PropertyInfo[] sourceProperties = sourceType.GetProperties();

            foreach (PropertyInfo pInf in sourceProperties)
            {
                object value = pInf.GetValue(source);
                PropertyInfo targetpInf = targetProperties.FirstOrDefault(x => x.Name == pInf.Name);
                if (targetpInf != null)
                {
                    targetpInf.SetValue(target, value);
                }
            }
            return target;
        }
    }
}
