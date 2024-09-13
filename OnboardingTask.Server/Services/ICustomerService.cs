using OnboardingTask.Server.Models;
using OnboardingTask.Server.ViewModels;

namespace OnboardingTask.Server.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetCustomers();
        Task<CustomerViewModel> GetCustomer(int Id);

        Task<CustomerViewModel> CreateCustomer(AddCustomerRequest request);
        Task<CustomerViewModel> UpdateCustomer(int Id, UpdateCustomerRequest request);
        Task DeleteCustomer(int Id);

    }
}
