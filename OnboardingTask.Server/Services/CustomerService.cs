using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnboardingTask.Server.Models;
using OnboardingTask.Server.ViewModels;

namespace OnboardingTask.Server.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(CustomerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            return _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
        }


        public async Task<CustomerViewModel> GetCustomer(int Id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Customer_Id == Id);

            if (customer == null)
            {
                throw new Exception("Customer not found");

            }

            return _mapper.Map<CustomerViewModel>(customer);
        }

        public async Task<CustomerViewModel> CreateCustomer(AddCustomerRequest request)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Address = request.Address
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerViewModel>(customer);
        }


        public async Task<CustomerViewModel> UpdateCustomer(int Id, UpdateCustomerRequest request)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Customer_Id == Id);

            if (customer == null)
            {
                throw new Exception("Customer not found!");
            }

            customer = _mapper.Map(request, customer);
            customer.Updated = DateTime.Now;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerViewModel>(customer);
        }

        public async Task DeleteCustomer(int Id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Customer_Id == Id);

            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found!");
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

        }
    }
}
