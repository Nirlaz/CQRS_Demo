using Common;
using MediatR;
using Persistence;
using StudentDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, StudentResponseModel<Student>>
    {
        private readonly ApplicationDbContext _context;
        public UpdateStudentCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<StudentResponseModel<Student>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existStudent = _context.students.FirstOrDefault(x => x.Id == request.studentId);
                if (existStudent == null)
                    return Task.FromResult(StudentResponseModel<Student>.Fail("Student not found"));
                existStudent.FullName = request.Fullname;
                existStudent.Age = request.Age;
                existStudent.Class = request.Class;
                _context.students.Update(existStudent);
                var row = _context.SaveChangesAsync();
                if (row.Result > 0)
                    return Task.FromResult(StudentResponseModel<Student>.Ok("Student updated successfully", existStudent));
                else
                    return Task.FromResult(StudentResponseModel<Student>.Fail("Failed to update student"));

            }
            catch (Exception ex)
            {
                return Task.FromResult(StudentResponseModel<Student>.Fail($"An error occurred: {ex.Message}"));
            }
        }
    }
}