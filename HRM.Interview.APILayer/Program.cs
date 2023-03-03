using HRM.Interview.ApplicationCore.Contract.Repository;
using HRM.Interview.ApplicationCore.Contract.Service;
using HRM.Interview.Infrastructure.Data;
using HRM.Interview.Infrastructure.Repository;
using HRM.Interview.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<InterviewDbContext>(options =>
{
    options.UseSqlServer(Environment.GetEnvironmentVariable("InterviewAPIDocker"));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewDb"));
});

//DI for repositories
builder.Services.AddScoped<IInterviewEntityRepositoryAsync, InterviewEntityRepositoryAsync>();
builder.Services.AddScoped<IFeedbackRepositoryAsync, FeedbackRepositoryAsync>();
builder.Services.AddScoped<IInterviewerRepositoryAsync, InterviewerRepositoryAsync>();
builder.Services.AddScoped<IRecruiterRepositoryAsync, RecruiterRepositoryAsync>();
builder.Services.AddScoped<IInterviewTypeRepositoryAsync, InterviewTypeRepositoryAsync>();

//DI for Services
builder.Services.AddScoped<IInterviewEntityServiceAsync, InterviewEntityServiceAsync>();
builder.Services.AddScoped<IFeedbackServiceAsync, FeedbackServiceAsync>();
builder.Services.AddScoped<IInterviewerServiceAsync, InterviewerServiceAsync>();
builder.Services.AddScoped<IRecruiterServiceAsync, RecruiterServiceAsync>();
builder.Services.AddScoped<IInterviewTypeServiceAsync, InterviewTypeServiceAsync>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseRouting();   //middleWare allows to use routing
app.UseCors();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); }); //this will map the request to the particular controller


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
