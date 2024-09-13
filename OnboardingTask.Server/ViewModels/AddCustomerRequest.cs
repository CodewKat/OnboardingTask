using System.ComponentModel.DataAnnotations;

namespace OnboardingTask.Server.ViewModels
{
    public class AddCustomerRequest
    {
        [Required]
        public string Name { get; set; }    

        [Required]
        public string Address { get; set; }
    }
}
