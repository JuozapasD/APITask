using APITask.DTO;

namespace APITask.DAL
{
    public interface ICarsList
    {
        List<Car> GetALLCars();
        List<Car> GetCarsByColor(string color);
        void AddNewCarToList(CarDto carDto);
        void UpdateCarById(int id, string color, string brand);
        void DeleteCarById(int id);


    }
}
