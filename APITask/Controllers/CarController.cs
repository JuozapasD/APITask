using APITask.DAL;
using APITask.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarsList _carsList;

        public CarController(ICarsList carsList)
        {
            _carsList = carsList;
        }

        [HttpGet]
        public List<Car> GetAllCars()
        {
            return _carsList.GetALLCars();
        }

        [HttpGet]
        [Route("Color")]
        public List<Car> GetCarsByColor( [FromQuery]string color)
        {
            return _carsList.GetCarsByColor(color);
        }

        [HttpPost]
        public void PostItem(CarDto carToAdd)
        {
            _carsList.AddNewCarToList(carToAdd);
        }

        [HttpPut]
        public void UpdateCar([FromQuery] int id, [FromBody] CarDto car)
        {
            _carsList.UpdateCarById(id, car.Color, car.Brand);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _carsList.DeleteCarById(id);
        }


    }
}
