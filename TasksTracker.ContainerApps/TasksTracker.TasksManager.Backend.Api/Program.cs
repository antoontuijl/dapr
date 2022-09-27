using TasksTracker.TasksManager.Backend.Api.Services;

namespace TasksTracker.ContainerApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ITasksManager, FakeTasksManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}