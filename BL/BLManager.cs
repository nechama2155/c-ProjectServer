using BL.Api;
using BL.Services;
using DAL;
using DAL.Api;
using Microsoft.Extensions.DependencyInjection;


namespace BL
{
    public class BLManager : Ibl
    {
        public IBLCustomer Customers { get; set; }
        public IBLAssessor Assessors { get; set; }
        public IBLAssessment Assessments { get; set; } 
        public IBLApartmentDetails ApartmentDetails { get; set; }
        public IBLApplications Applications { get; set; }
        public IBLChat Chats { get; set; }




        public BLManager()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton<IBLAssessor, BLAssessorService>();
            services.AddSingleton<IBLAssessment, BLAssessmentService>();
            services.AddSingleton<IBLCustomer, BLCustomersService>();
            services.AddSingleton<IBLApartmentDetails, BLApartmenetDetailsService>();
            services.AddSingleton<IBLApplications, BLApplicationsService>();
            services.AddSingleton<IBLChat, BLChatService>();


            ServiceProvider serviceProvider = services.BuildServiceProvider();

            Customers = serviceProvider.GetRequiredService<IBLCustomer>();

            Assessors = serviceProvider.GetRequiredService<IBLAssessor>();

            Assessments = serviceProvider.GetRequiredService<IBLAssessment>();

            ApartmentDetails = serviceProvider.GetRequiredService<IBLApartmentDetails>();

            Applications = serviceProvider.GetRequiredService<IBLApplications>();

            Chats = serviceProvider.GetRequiredService<IBLChat>();

        }

    }
}