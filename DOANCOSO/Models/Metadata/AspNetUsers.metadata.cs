using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DOANCOSO.Models
{
    [MetadataTypeAttribute(typeof(AspNetUsersMetadata))]
    public partial class AspNetUsers
    {
        internal sealed class AspNetUsersMetadata
        {
            [Display(Name = "Mã Khách Hàng")]

            public string Id { get; set; }
            [Required]
            [StringLength(256)]
            [Display(Name = "Tên Khách Hàng")]
            public string UserName { get; set; }
            [Display(Name = "Ngày Sinh")]

            public DateTime? Birthday { get; set; }
            [Display(Name = "Địa Chỉ")]

            public string Address { get; set; }

            [StringLength(256)]

            public string Email { get; set; }
           
           
        }
    }
}