using CourseMagagementSystem.Abstractions.Services;
using CourseMagagementSystem.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CourseMagagementSystem.HostedService
{
    internal class ProcessHandler : IHostedService
    {
        private readonly IHostApplicationLifetime _lifeTime;
        private readonly ICourseService _courseService;
        private readonly ILogger<ProcessHandler> _logger;

        public ProcessHandler(IHostApplicationLifetime lifetime, ICourseService courseService, ILogger<ProcessHandler> logger)
        {
            _lifeTime = lifetime;
            _courseService = courseService;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                var courseById = await _courseService.GetCourseById("C001");
                var allCourses = await _courseService.GetAllCourses();
                await _courseService.AddCourse(new Course());
                await _courseService.AddStudentToCourse(new Student("Jane Hill"), new Course());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during the process.");
                _lifeTime.StopApplication();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
