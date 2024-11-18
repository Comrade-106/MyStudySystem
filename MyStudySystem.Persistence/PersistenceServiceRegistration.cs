
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Persistence.Repositories;

namespace MyStudySystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration
                .GetConnectionString("MyStudySystemConnectionString")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IControlQuestionRepository, ControlQuestionRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IGlossaryEntryRepository, GlossaryEntryRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();

            return services;
        }
    }
}
