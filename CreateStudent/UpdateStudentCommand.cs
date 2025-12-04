using Common;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands
{
    public record UpdateStudentCommand(Guid studentId,string Fullname,int Age,string Class): IRequest<StudentResponseModel<Student>>;

}
