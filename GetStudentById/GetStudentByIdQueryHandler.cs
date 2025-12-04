using Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using StudentDto;

namespace GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentResponseModel<Student>>
    {
        private readonly ApplicationDbContext _context;
        public GetStudentByIdQueryHandler(ApplicationDbContext context) => _context = context;

        public async Task<StudentResponseModel<Student>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var student = await _context.students.FirstOrDefaultAsync(x => x.Id == request.studentId, cancellationToken);
                if (student is null)
                    return StudentResponseModel<Student>.Fail("No Data Found");

                return StudentResponseModel<Student>.Ok("Data Retrieve Succesfull", student); ;
            }
            catch (Exception ex)
            {
                return StudentResponseModel<Student>.Fail($"An error occurred while retrieving the student: {ex.Message}");
            }
        }
    }
}
