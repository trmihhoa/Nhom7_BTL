using Nhom7_BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nhom7_BTL.Dto
{
    public class CustomerDto
    {
        public string Customer_Name { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }

        [Required]
        public string Telephone { get; set; }
        public string Email { get; set; }

        public CustomerDto() { }

        public CustomerDto(Account acc)
        {
            this.Customer_Name = acc.Customer_Name;
            this.Email = acc.Email;
        }
    }
}