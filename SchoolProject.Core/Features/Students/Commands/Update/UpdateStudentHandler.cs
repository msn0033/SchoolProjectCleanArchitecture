using AutoMapper;
using LocalizationLanguage;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Features.Students.Commands.Create;
using SchoolProject.Core.Features.Students.Commands.Delete;
using SchoolProject.Data.Entities;

using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Update
{
    public class CreateCommandHandler : ApiResponseHandler,
        IRequestHandler<UpdateStudentCommand, ApiResponse<string>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CreateCommandHandler> _localizer;

        public CreateCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<CreateCommandHandler> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }
    
        //Handle edit
        public async Task<ApiResponse<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            // check item is exist
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            //return not found if not exist
            if (student == null) return NotFound<string>("item not Found");
            //mapping
            var studentMapping = _mapper.Map(request, student);
            //service Edit
            string result = await _studentService.EditStudentAsync(studentMapping);
            //return Success
            return Created(result);
        }
       
    }
}
