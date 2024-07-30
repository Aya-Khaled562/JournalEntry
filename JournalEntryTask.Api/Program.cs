
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
                        .AddPresentation()
                        .AddApplication()
                        .AddInfrastructure(builder.Configuration);
            }
           

            var app = builder.Build();
            {
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
            
        }
    }
}
