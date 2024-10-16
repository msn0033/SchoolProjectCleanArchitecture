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

namespace SchoolProject.Core.Features.Students.Commands.Create
{
    public class CreateStudentHandler : ApiResponseHandler,
        IRequestHandler<CreateStudentCommand, ApiResponse<string>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CreateStudentHandler> _localizer;

        public CreateStudentHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<CreateStudentHandler> localizer):base(localizer)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            this._localizer = localizer;
        }
        // Handle add
        public async Task<ApiResponse<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            //maper
            var studentmapping = _mapper.Map<Student>(request);
            //add to database
            var result = await _studentService.AddStudentAsync(studentmapping);

            //check is Exist
            if (result.Equals("Exist")) return UnprocessableEntity<string>("Name is Exist");

            //check add is ok
            else if (result == "Success") return Created(result, "", _localizer[ShareResourcesKey.Add_Successfully]);


            return BadRequest<string>();
        }

      
    }
}
