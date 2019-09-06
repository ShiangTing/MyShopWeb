using CoreMode.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyShopWeb.Models
{
    [DataContract]
    public class ProductCategory
    {
        public ProductCategory()
        {
           
        }
        public ProductCategory(ICollection<Product> products)
        {
            Products = products;
        }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public  int Id { get; set; }
        public int? ParentId { get; set; }
        public virtual ProductCategory RootCategory { get; set; }

        public virtual ICollection<ProductCategory> SubCategories { get; set; }
        //ForeignKey
        public virtual ICollection<Product> Products { get; set; }


        



        public class Mapping : EntityTypeConfiguration<ProductCategory>
        {
            public Mapping()
            {

                HasOptional(m => m.RootCategory).WithMany(m => m.SubCategories);
                //.HasForeignKey(x => x.ParentId).WillCascadeOnDelete(false); 
            }
        }

        


    }
    
}