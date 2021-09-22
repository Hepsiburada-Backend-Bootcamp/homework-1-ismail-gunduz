using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductController : Controller
    {
        // products listemizi olusturuyoruz
        private static List<Product> _products = new List<Product>
        {
            new Product( 0, "Apple",     "iPhone 13",    "Mobile",   1000),
            new Product( 1, "Lenovo",    "IdeaPad",      "Computer", 300),
            new Product( 2, "Versace",   "Perfume",      "Beauty",   80),
            new Product( 3, "Armani",    "Suit",         "Clothing", 600),
            new Product( 4, "NYX",       "Mascara",      "Beauty",   8.5),
            new Product( 5, "Puma",      "Jersey",       "Sports",   40),
            new Product( 6, "Samsung",   "Galaxy S21",   "Mobile",   850),
            new Product( 7, "Zara",      "Tshirt",       "Clothing", 15),
            new Product( 8, "Loreal",    "Face Mask",    "Beauty",   5.25),
            new Product( 9, "Samsung",   "Note 20",      "Mobile",   900),
            new Product(10, "Apple",     "MacBook Pro",  "Computer", 1000),
            new Product(11, "Jordan",    "Basketball",   "Sports",   37.5),
            new Product(12, "MAC",       "Lipstick",     "Beauty",   45),
            new Product(13, "HP",        "Pavilion",     "Computer", 770),
            new Product(14, "Nike",      "AirMax",       "Sports",   200),
            new Product(15, "Mango",     "Coat",         "Clothing", 150),
            new Product(16, "Adidas",    "Yeezy",        "Sports",   400),
            new Product(17, "Apple",     "MacBook Air",  "Computer", 925),
            new Product(18, "GAP",       "Hoodie",       "Clothing", 30),
            new Product(19, "Xiaomi",    "Mi 11",        "Mobile",   295)
        };

        // HTTP GET metodumuz hicbir parametre almiyorsa listenin tamamini oldugu gibi donduruyoruz
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_products);
        }

        // HTTP GET metodumuz icin request, id parametresi aliyorsa id'nin eslestigi urunu donduruyoruz
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return Ok(product);
            }
            // Herhangi bir id eslesmesi yoksa NotFound (404) donduruyoruz
            return NotFound();
        }

        // HTTP POST metodumuz icin requestin body icerisinde urune ait bilgileri icermesini bekliyoruz
        // Bu bilgilere yeni sahip urunu listemize ekliyoruz
        [HttpPost]
        public IActionResult NewProduct([FromBody] Product p)
        {
            _products.Add(p);
            return Created("Product created and added", p);
        }

        // HTTP PUT metodumuz icin requestin pathinde id, bodysinde ilgili urune ait yeni bilgileri icermesini bekliyoruz
        // Eslesen id'ye sahip urunun bilgilerini bodyde yer alan degerlerle degistiriyoruz
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product p)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.Id = p.Id;
                product.Brand = p.Brand;
                product.Name = p.Name;
                product.Category = p.Category;
                product.Price = p.Price;
                return Ok();
            }
            // Herhangi bir id eslesmesi yoksa NotFound (404) donduruyoruz
            return NotFound();
        }

        // Listemizde siralama yapmak icin /sort pathine sahip bir HTTP GET metodu daha olusturuyoruz
        // Bu metotta queryden alinan sortBy adli parametremiz listenin hangi ozellige gore siralanacagini belirliyor
        [HttpGet("sort")]
        public IActionResult SortProducts([FromQuery] String sortBy)
        {
            try
            {
                List<Product> Sorted = new List<Product>(_products);
                if (sortBy.ToLower().Equals("brand"))
                {
                    Sorted.Sort(delegate (Product p1, Product p2)
                    {
                        return p1.Brand.CompareTo(p2.Brand);
                    });
                }
                else if (sortBy.ToLower().Equals("name"))
                {
                    Sorted.Sort(delegate (Product p1, Product p2)
                    {
                        return p1.Name.CompareTo(p2.Name);
                    });
                }
                else if (sortBy.ToLower().Equals("category"))
                {
                    Sorted.Sort(delegate (Product p1, Product p2)
                    {
                        return p1.Category.CompareTo(p2.Category);
                    });
                }
                else if (sortBy.ToLower().Equals("price"))
                {
                    Sorted.Sort(delegate (Product p1, Product p2)
                    {
                        return p1.Price.CompareTo(p2.Price);
                    });
                }
                else
                {
                    // Gecersiz parametre girildiginde BadRequest (400) donduruyoruz
                    return BadRequest();
                }
                return Ok(Sorted);
            }
            catch (Exception e)
            {
                // Sort islemiyle ilgili bir hata meydana gelirse Internal Server Error donduruyoruz
                return StatusCode(500, e);
            }
        }

        // HTTP DELETE metodumuz pathten id parametresi aliyor ve bu id'ye sahip urunu listeden siliyor
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                return Ok();
            }
            // Herhangi bir id eslesmesi yoksa NotFound (404) donduruyoruz
            return NotFound();
        }
    }
}
