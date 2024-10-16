using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Features.Students.Commands.Create;
using SchoolProject.Core.Features.Students.Commands.Delete;
using SchoolProject.Core.Features.Students.Commands.Update;
using SchoolProject.Data.Entities;


using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Delete
{
    public class CreateCommandHandler : ApiResponseHandler,
                 IRequestHandler<DeleteStudentCommand, ApiResponse<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CreateCommandHandler> _localizer;

        public CreateCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<CreateCommandHandler> localizer):base(localizer)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._localizer = localizer;
        }
     
        // Handle Delete
        public async Task<ApiResponse<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //check item if not found return Notfound
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null) return NotFound<string>("Student Not Found");
            //service remove and return Success
            string result = await _studentService.DeleteAsync(student);
            return Deleted<string>(result);



        }
    }
}
