using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShopWeb.Models;

namespace CoreMode.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }


        public string Title
        {
            get
            {
                if (Product.Id == 0) //
                {
                    return "新增產品";
                }

                return "編輯產品";
            }
        }
    }
}
