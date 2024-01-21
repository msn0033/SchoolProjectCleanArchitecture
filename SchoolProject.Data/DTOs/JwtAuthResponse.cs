using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data.ModelsHelper;

namespace SchoolProject.Data.DTOs
{
    public class JwtAuthResponse
    {
        public string? AccessToken { get; set; }
        public RefreshToken? RefreshToken { get; set; }
        public string? message { get; set; }
    }
}
