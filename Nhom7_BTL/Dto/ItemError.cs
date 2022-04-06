using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom7_BTL.Dto
{
    public class ItemError
    {
        public ProductDto productDto { get; set; }

        public int slt { get; set; }

        public int slOrder { get; set; }

        public ItemError() { }

        public ItemError(ProductDto dto, int slt, int Order) {
            this.productDto = dto;
            this.slOrder = Order;
            this.slt = slt;
        }

    }
}