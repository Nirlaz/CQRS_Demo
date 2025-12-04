using Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using StudentDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, StudentResponseModel<Student>>
    {
        private readonly ApplicationDbContext _context;

        public DeleteStudentCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentResponseModel<Student>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProject = await _context.students.FirstOrDefaultAsync(x => x.Id == request.studentId);
                if (existingProject is null)
                    return StudentResponseModel<Student>.Fail("Student not found");
                _context.students.Remove(existingProject);
                var row = await _context.SaveChangesAsync(cancellationToken);
                if (row < 0)
                    return StudentResponseModel<Student>.Fail("Failed to delete student");
                return StudentResponseModel<Student>.Ok("Student deleted successfully", existingProject);

            }
            catch (Exception ex)
            {
                return StudentResponseModel<Student>.Fail($"An error occurred: {ex.Message}");
            }

        }


    }
}
