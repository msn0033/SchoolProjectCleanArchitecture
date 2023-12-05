using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Responses
{
    public class GetUsersPaginatedListResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

    }
}
