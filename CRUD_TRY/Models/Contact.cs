using System.ComponentModel.DataAnnotations;

namespace CRUD_TRY.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public Contact() { }

        public Contact(int id, string fullname, string email, string phoneNumber)
        {
            Id = id;
            Fullname = fullname;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
