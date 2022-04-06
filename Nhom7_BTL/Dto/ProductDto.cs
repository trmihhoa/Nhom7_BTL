using Nhom7_BTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom7_BTL.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public string Avatar { get; set; }

        public ProductDto()
        {
        }

        public ProductDto(Product product)
        {
            this.Id = product.Product_Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Avatar = product.Avatar;
        }
    }
}