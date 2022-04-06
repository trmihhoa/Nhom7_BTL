using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom7_BTL.Dto
{
    public class Cart
    {
        public CustomerDto customerDto;
        public List<CartItem> cartLines;

        public Cart() {
            cartLines = new List<CartItem>();
        }

    }
}