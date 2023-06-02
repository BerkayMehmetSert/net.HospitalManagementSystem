using System.Reflection;
using Application.Contacts.Services;
using Application.Services;
using Infrastructure.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IEmergencyContactService, EmergencyContactService>();
        services.AddScoped<IHospitalDiagnosisListService, HospitalDiagnosisListService>();
        services.AddScoped<IPatientAdmissionService, PatientAdmissionService>();
        services.AddScoped<IPatientDiagnosisService, PatientDiagnosisService>();
        services.AddScoped<IPatientFollowUpService, PatientFollowUpService>();
        services.AddScoped<IPatientHistoryService, PatientHistoryService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddHttpContextAccessor();
    }
}