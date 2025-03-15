using _0_Framework.Application;
using AccountManagement.Application.Contracts.role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contracts.Account
{
    public class RegisterAccount
    {
        [MaxLength(70, ErrorMessage = ValidationMessages.MaxLength)]

        public string FullName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(50, ErrorMessage = ValidationMessages.MaxLength)]

        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "ایمیل شما به درستی وارد نشده است")]
        public string Gmail { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(12, ErrorMessage = ValidationMessages.MaxLength)]
        [Phone(ErrorMessage = "شماره تماس به درستی وارد نشده است")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(16, ErrorMessage = ValidationMessages.MaxLength)]
        public string Password { get; set; }
        [MaxLength(4000, ErrorMessage = ValidationMessages.MaxLength)]

        public string ProfilePicture { get; set; }

        public List<RoleViewModel> Roles { get; set; }
        [Range(1,10000,ErrorMessage = ValidationMessages.IsRequired)]
        public long RoleId { get; set; }


    }

}
