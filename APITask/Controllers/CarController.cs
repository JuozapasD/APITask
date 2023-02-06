using APITask.DAL;
using APITask.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CarController : ControllerBase
    {
        private readonly ICarsList _carsList;

        public CarController(ICarsList carsList)
        {
            _carsList = carsList;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User, Admin")]
        [HttpGet]
        public List<Car> GetAllCars()
        {
            return _carsList.GetALLCars();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User, Admin")]
        [HttpGet]
        [Route("Color")]
        public List<Car> GetCarsByColor( [FromQuery]string color)
        {
            return _carsList.GetCarsByColor(color);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public void PostItem(CarDto carToAdd)
        {
            _carsList.AddNewCarToList(carToAdd);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut]
        public void UpdateCar([FromQuery] int id, [FromBody] CarDto car)
        {
            _carsList.UpdateCarById(id, car.Color, car.Brand);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete]
        public void Delete(int id)
        {
            _carsList.DeleteCarById(id);
        }


    }
}
