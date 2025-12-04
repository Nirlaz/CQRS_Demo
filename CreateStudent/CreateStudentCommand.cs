using Common;
using MediatR;


namespace CreateStudent
{
    public record CreateStudentCommand(string FullName,int Age,string Class): IRequest<StudentResponseModel<Guid>>;

}
