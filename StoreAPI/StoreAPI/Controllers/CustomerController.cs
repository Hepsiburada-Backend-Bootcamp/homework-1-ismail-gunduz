using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : Controller
    {
        // customers listemizi Mockaroo'dan elde ettigimiz rastgele verilerle olusturuyoruz
        private static List<Customer> _customers = new List<Customer>
        {
            new Customer(0, "Ismail",  "Gunduz",  "M", "ismailgunduz@mail.com"),
            new Customer(1, "Edward",  "Barnes",  "M", "edwardbarnes@mail.com"),
            new Customer(2, "Amy",     "Kelley",  "F", "amykelley@mail.com"),
            new Customer(3, "Henry",   "Mount",   "M", "henrymount@mail.com"),
            new Customer(4, "Luke",    "Sun",     "M", "lukesun@mail.com"),
            new Customer(5, "Michael", "Warren",  "M", "michaelwarren@mail.com"),
            new Customer(6, "Jessica", "Perez",   "F", "jessicaperez@mail.com"),
            new Customer(7, "Anna",    "Hammer",  "F", "annahammer@mail.com"),
            new Customer(8, "Daisy",   "Smith",   "F", "daisysmith@mail.com"),
            new Customer(9, "Jim",     "Harper",  "M", "jimharper@mail.com")
        };

        // HTTP GET metodumuz hicbir parametre almiyorsa listenin tamamini donduruyoruz
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customers);
        }

        // HTTP GET metodumuz icin request, id parametresi aliyorsa id'nin eslestigi musteriyi donduruyoruz
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                return Ok(customer);
            }
            // Herhangi bir id eslesmesi yoksa NotFound (404) donduruyoruz
            return NotFound();
        }

        // HTTP POST metodumuz icin requestin body icerisinde musteriye ait bilgileri icermesini bekliyoruz
        // Bu bilgilere sahip yeni musteriyi listemize ekliyoruz
        [HttpPost]
        public IActionResult NewCustomer([FromBody] Customer c)
        {
            _customers.Add(c);
            return Created("Customer created and added", c);
        }

        // HTTP PUT metodumuz icin requestin querysinde id, bodysinde ilgili musteriye ait yeni bilgileri icermesini bekliyoruz
        // Eslesen id'ye sahip musterinin bilgilerini bodyde yer alan degerlerle degistiriyoruz
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer c)
        {
            var customer = _customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                customer.Id = c.Id;
                customer.FirstName = c.FirstName;
                customer.LastName = c.LastName;
                customer.Gender = c.Gender;
                customer.Email = c.Email;
                return Ok();
            }
            // Herhangi bir id eslesmesi yoksa NotFound (404) donduruyoruz
            return NotFound();
        }

        // HTTP DELETE metodumuz pathten id parametresi aliyor ve bu id'ye sahip urunu listeden siliyor
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
                return Ok();
            }
            // Herhangi bir id eslesmesi yoksa NotFound (404) donduruyoruz
            return NotFound();
        }
    }
}
