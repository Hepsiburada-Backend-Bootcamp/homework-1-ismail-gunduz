using System;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI
{
    // Product modelindeki tum attributelar zorunlu kilinmistir
    public class Product
    {
        [Required]
        // IDnin negatif olmasi durumunu kontrol ediyoruz
        [Range(0, int.MaxValue, ErrorMessage = "ID cannot be negative")]
        public int Id { get; set; }

        [Required]
        // Marka ismini 20 karakterle sinirliyoruz
        [StringLength(20, ErrorMessage = "Brand name cannot be longer than 20 characters")]
        public String Brand { get; set; }

        [Required]
        // Urun ismini 100 karakterle sinirliyoruz
        [StringLength(100, ErrorMessage = "Product name cannot be longer than 100 characters")]
        public String Name { get; set; }

        [Required]
        // Kategoriyi 10 karakterle sinirliyoruz
        [StringLength(10, ErrorMessage = "Category cannot be longer than 10 characters")]
        public String Category { get; set; }

        [Required]
        // Fiyati minimum 1 ve maksimum 1000 USD olacak sekilde ayarliyoruz
        [Range(1, 1000, ErrorMessage = "Price must be between 1-1000 USD")]
        public double Price { get; set; }

        public Product(int id, string brand, string name, string category, double price)
        {
            this.Id = id;
            this.Brand = brand;
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }
    }
}
