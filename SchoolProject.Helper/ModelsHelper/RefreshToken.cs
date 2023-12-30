using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Helper.ModelsHelper
{
    public class RefreshToken
    {
        public string? UserName { get; set; }
        public string? RefreshTokenString { get; set; }
        public DateTime ExpaireAt { get; set; }
       
    }
}
