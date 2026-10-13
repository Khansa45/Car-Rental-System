using Microsoft.AspNetCore.Mvc;
using Lab_04.Models;
namespace Lab_04.Controllers
{

    public class CarController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(availableCars);
        }

        [HttpPost]
        public IActionResult Book(int Id)
        {
            Car targetCar = null;
            foreach (var car in availableCars)
            {
                if (car.id == Id)
                {
                    targetCar = car;
                    break;
                }
            }
            if (targetCar != null)
            {
                availableCars.Remove(targetCar);
                bookedCars.Add(targetCar);
                return RedirectToAction("Booked");
            }
            return View(bookedCars);
        }

        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
        private static List<Car> availableCars = new List<Car>
        {
           new Car{id=1,name="Alto",pricePerDay=3000 },
           new Car{id=2,name="Corola",pricePerDay=6000 },
           new Car{id=3,name="Civic",pricePerDay=8000 },
        };

        private static List<Car> bookedCars = new List<Car>();
    }
}
