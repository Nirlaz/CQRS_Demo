using Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using StudentDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Queries
{
    public class GetStudentsListQueryHandler : IRequestHandler<GetStudentsListQuery, StudentResponseModel<List<Student>>>
    {
        private readonly ApplicationDbContext _context;

        public GetStudentsListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentResponseModel<List<Student>>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var student =await _context.students.AsNoTracking().ToListAsync();
                if (student is null)
                    return StudentResponseModel<List<Student>>.Fail("No Data Found");
                return StudentResponseModel<List<Student>>.Ok("Data Fetch Succesfully", student);
            }catch(Exception ex)
            {
                return StudentResponseModel<List<Student>>.Fail($"Exception Occure:{ex.Message}");

            }

        }
    }
}
