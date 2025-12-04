using Commands;
using CreateStudent;
using GetStudentById;
using Microsoft.EntityFrameworkCore;
using Queries;
using StudentDto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin());
});

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase(databaseName:"Nirlaz"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
        typeof(GetStudentsListQuery).Assembly,
        typeof(GetStudentsListQueryHandler).Assembly,

        typeof(GetStudentByIdQuery).Assembly,
        typeof(GetStudentByIdQueryHandler).Assembly,

        typeof(DeleteStudentCommand).Assembly,
        typeof(DeleteStudentCommandHandler).Assembly,

        typeof(UpdateStudentCommand).Assembly,
        typeof(UpdateStudentCommandHandler).Assembly,

        typeof(CreateStudentCommand).Assembly,
        typeof(CreateStudentCommandHandler).Assembly,
        typeof(Program).Assembly)); // optional));

builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

        app.UseSwagger();
        app.UseSwaggerUI();


}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
