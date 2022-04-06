using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom7_BTL.Dto
{
    public class CartItem
    {
        public ProductDto productDto { get; set; }
        public int quantity { get; set; }
        public CartItem()
        {
            this.quantity = 0;
        }

        public CartItem(ProductDto dto, int qty)
        {
            this.productDto = dto;
            this.quantity += qty;
        }
        public double getAmount()
        {
            return this.productDto.Price * this.quantity;
        }

    }
}