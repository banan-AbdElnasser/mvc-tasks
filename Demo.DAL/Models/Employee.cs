using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is required")]
        [MaxLength(50,ErrorMessage = "MaxLength Is 50 Chars")]
        [MinLength(3,ErrorMessage = "MinLength Is 3 Chars")]
        public string Name { get; set; }
        [Range(22,45,ErrorMessage ="Age Must Be In Range From 22 To 45")]
        public int?Age { get; set; }
        [RegularExpression(@"[0-9]{1-3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$")]
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set;}
        [Phone] 
        public string Phone { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
      
        [DisplayName("Hiring Date")]
        public DateTime HireDate { get; set; }
        [DisplayName("Date Of Creation")]
        public DateTime DateOfCreation { get; set; }=DateTime.Now;
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }



    }
}
