using System;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI
{
    // Customer modelindeki tum attributelar zorunlu kilinmistir
    public class Customer
    {
        [Required]
        // IDnin negatif olmasi durumunu kontrol ediyoruz
        [Range(0, int.MaxValue, ErrorMessage = "ID cannot be negative")]
        public int Id { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        // Cinsiyetin uzun sekilde degil tek harfle gosterilmesini istiyoruz
        [StringLength(1, ErrorMessage = "Please enter gender as upper initial")]
        // Yalnizca F ve M karakterlerinin kullanilmasini zorluyoruz
        [RegularExpression("F|M", ErrorMessage = "Gender can be either 'F' (Female) or 'M' (Male)")]
        public String Gender { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public String Email { get; set; }

        public Customer(int id, String firstName, String lastName, String gender, String email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Email = email;
        }
    }
}
