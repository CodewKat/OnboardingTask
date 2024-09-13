using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingTask.Server.Models
{
    public class Customer
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Customer_Id { get; set; }

        [Required(ErrorMessage ="Please enter the customer's name")]
        public string  Name { get; set; }

        [Required(ErrorMessage = "Please enter the customer's address")]
        public string Address { get; set; }

        public DateTime Created { get; set; }   
        public DateTime Updated { get; set; }   

    }

}

