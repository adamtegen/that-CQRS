using CqrsDemo.DataAccess;
using CqrsDemo.Infrastructure;
using CqrsDemo.Queries;
using MediatR;
using MediatR.Pipeline;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<TextWriter>(Console.Out);

builder.Services.AddHttpContextAccessor();

//  builder.Services.AddScoped<Metadata>();

// Dependency inject the data access
builder.Services.AddSingleton<IDataAccess, DemoDataAccess>();

builder.Services.AddMediatR(typeof(GetAllProductsHandler).Assembly);

//services.AddScoped(typeof(IStreamRequestHandler<Sing, Song>), typeof(SingHandler));

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(GenericPipelineBehavior<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RetryPipelineBehavior<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuthBehavior<,>));

//builder.Services.AddScoped(typeof(IRequestPreProcessor<>), typeof(GenericRequestPreProcessor<>));
//builder.Services.AddScoped(typeof(IRequestPostProcessor<,>), typeof(GenericRequestPostProcessor<,>));
//builder.Services.AddScoped(typeof(IStreamPipelineBehavior<,>), typeof(GenericStreamPipelineBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
