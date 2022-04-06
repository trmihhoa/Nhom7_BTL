using Nhom7_BTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom7_BTL.DAO
{

    public class CategoriesDAO
    {
        private Web_Tranh_Theu db = new Web_Tranh_Theu();
        public List<Category> GetAllCategoiries()
        {
            var listCate = db.Categories.ToList();
            return listCate;
        }

        public List<Product> GetProductsByCategoryId(int? id)
        {
            return db.Products.Where(p => p.Category_Id == id).ToList();

        }


    }
}