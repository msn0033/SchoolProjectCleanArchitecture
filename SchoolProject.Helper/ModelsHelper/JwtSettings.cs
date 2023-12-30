using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Helper.ModelsHelper
{
    public class Jwtsettings
    {
        public string? Secret { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateIssure { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; } 
        public int AccessTokenExpire { get; set; } 
        public int RefreshTokenExpire { get; set; }
    }
}
