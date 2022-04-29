using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CAD.Base.Common.ViewModels.Account
{
    public class LoginUser
    {
        [Required()]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
