using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities.Identity
{
    public class UserRefreshToken
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? JwtSecurityTokenId { get; set; }
        public string? RefreshTokenString { get; set; }
        public string? AccessToken { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime ExpireAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsRevoked { get; set; }
        public User? User { get; set; }


    }
}
