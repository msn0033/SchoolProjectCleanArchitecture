using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data.ModelsHelper;

namespace SchoolProject.Data.Result
{
    public class JwtAuthResult
    {
        public string? AccessToken { get; set; }
        public RefreshToken? RefreshToken { get; set; }
        public string? message { get; set; }
    }
}
