using MediatR;
using SchoolProject.Core.Base.ApiResponse;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
    public class AddUserCommand:IRequest<ApiResponse<string>>
    {
        public required  string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PasswordConfirm { get; set; }
        public  string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    }
}
