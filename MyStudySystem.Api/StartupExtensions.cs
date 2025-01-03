﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyStudySystem.Api.Middleware;
using MyStudySystem.Persistence;
using MyStudySystem.Application;

namespace MyStudySystem.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureService(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();
            builder.Services.AddPersistanceServices(builder.Configuration);

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlobalTicket Ticket Management API");
                });
            }

            app.UseHttpsRedirection();
            //app.UseRouting();

            app.UseCustomExceptionsHandler();

            app.UseCors("Open");
            app.MapControllers();

            return app;
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "My Study System Management API",
                });
            });
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            } catch (Exception ex)
            {
                // logging
            }
        }
    }
}
