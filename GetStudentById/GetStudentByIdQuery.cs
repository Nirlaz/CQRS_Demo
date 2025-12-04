using Common;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetStudentById
{
    public record GetStudentByIdQuery(Guid studentId) : IRequest<StudentResponseModel<Student>>;
 }
