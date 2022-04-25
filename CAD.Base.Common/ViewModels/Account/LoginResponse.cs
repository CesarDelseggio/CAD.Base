using System;
using System.Collections.Generic;
using System.Text;

namespace CAD.Base.Common.ViewModels.Account
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public TimeSpan ExpireIn { get; set; }
    }
}
