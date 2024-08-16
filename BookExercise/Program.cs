using BookDomain;
using BookDomain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(BookAutoMapper));

builder.Services.AddScoped<IBookService, BookService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    // Do work that can write to the Response.
    const string authHeader = "xAuth";

    if (!context.Request.Headers.ContainsKey(authHeader) ||
        string.IsNullOrEmpty(context.Request.Headers[authHeader].ToString()))
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsync("Unauthorized");
        return;
    }

    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
