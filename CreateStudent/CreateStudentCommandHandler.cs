using Common;
using CreateStudent;
using MediatR;
using Microsoft.VisualBasic;
using Persistence;
using StudentDto;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Text;

namespace Commands
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentResponseModel<Guid>>
    {
        private readonly ApplicationDbContext _dbcontext;

        public CreateStudentCommandHandler(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<StudentResponseModel<Guid>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student { FullName = request.FullName, Age = request.Age, Class = request.Class };

            try
            {
                await _dbcontext.students.AddAsync(student);
                var row = await _dbcontext.SaveChangesAsync();
                if (row > 0)
                    return StudentResponseModel<Guid>.Ok($"Student create succesfully",student.Id);
                return StudentResponseModel<Guid>.Fail("Failed to create student");

            }
            catch (Exception ex)
            {
                return StudentResponseModel<Guid>.Fail( ex.Message);
            }

        }
    }

}
