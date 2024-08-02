
using JournalEntryTask.Application;
using JournalEntryTask.Infrastructure;

namespace JournalEntryTask.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services
                        .AddApi()
                        .AddApplication()
                        .AddInfrastructure(builder.Configuration);

                //CORS
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAnyOrigin",builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
                    
                });
            }
           

            var app = builder.Build();
            {
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseCors("AllowAnyOrigin"); // Apply CORS policy

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
            
        }
    }
}
