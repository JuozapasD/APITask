using APITask.DTO;

namespace APITask.DAL
{
    public class CarsListDbRepository : ICarsList
    {
        private readonly CarsListDbContext _context;
        public CarsListDbRepository(CarsListDbContext context)
        {
            _context = context;
        }
        public void AddNewCarToList(CarDto carDto)
        {
            _context.Cars.Add(new Car
            {
                Brand = carDto.Brand,
                Color = carDto.Color,
            });
            _context.SaveChanges();
        }

        public void DeleteCarById(int id)
        {
            _context.Cars.Remove(new Car { Id = id });
            _context.SaveChanges(true);
        }

        public List<Car> GetALLCars()
        {
            return _context.Cars.ToList();
        }

        public List<Car> GetCarsByColor(string color)
        {

            return _context.Cars.Where(i => i.Color == color).ToList();
        }

        public void UpdateCarById(int id, string color, string brand)
        {
            var carFromDb = _context.Cars.FirstOrDefault(i => i.Id == id);
            carFromDb.Color = color;
            carFromDb.Brand = brand;
            _context.SaveChanges();
        }
    }
}
