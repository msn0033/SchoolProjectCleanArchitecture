using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responses;

using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Service.Interface;


namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<StudentsListQuery, Response<IEnumerable<StudentsListQueryResponse>>>
        , IRequestHandler<StudentByIdQuery, Response<StudentsListQueryResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            this._studentService = studentService;
            this._mapper = mapper;
        }
        public async Task<Response<IEnumerable<StudentsListQueryResponse>>> Handle(StudentsListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsListwithIncludeAsync();
            var studentsResponseMapping = _mapper.Map<IEnumerable<StudentsListQueryResponse>>(students);

            return Success(studentsResponseMapping);
        }

        public async Task<Response<StudentsListQueryResponse>> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludeAsync(request.id);
            if (student == null)
                return NotFound<StudentsListQueryResponse>();
            var result = _mapper.Map<StudentsListQueryResponse>(student);
            return Success(result);
        }
    }
}
