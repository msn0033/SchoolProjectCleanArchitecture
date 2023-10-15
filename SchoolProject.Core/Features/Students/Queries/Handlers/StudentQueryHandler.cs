using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responses;

using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Service.Interface;


namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<StudentsListQuery, Response<IEnumerable<StudentsQueryResponse>>>
        , IRequestHandler<StudentByIdQuery, Response<StudentsQueryResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            this._studentService = studentService;
            this._mapper = mapper;
        }
        public async Task<Response<IEnumerable<StudentsQueryResponse>>> Handle(StudentsListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsAsync();
            var studentsResponseMapping = _mapper.Map<IEnumerable<StudentsQueryResponse>>(students);

            return Success(studentsResponseMapping);
        }

        public async Task<Response<StudentsQueryResponse>> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.id);
            if (student == null)
                return NotFound<StudentsQueryResponse>();
            var result = _mapper.Map<StudentsQueryResponse>(student);
            return Success(result);
        }
    }
}
