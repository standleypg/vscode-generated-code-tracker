using Api;
using Infrastructure;
using Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
      .AddApi()
      .AddApplication()
      .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseExceptionHandler(_ => { });
    
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
}
