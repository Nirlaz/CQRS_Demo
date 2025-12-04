using Common;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands
{
    public record DeleteStudentCommand(Guid studentId) : IRequest<StudentResponseModel<Student>>;
}
