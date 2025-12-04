using Common;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Queries
{
    public record class GetStudentsListQuery() : IRequest<StudentResponseModel<List<Student>>>;
}
