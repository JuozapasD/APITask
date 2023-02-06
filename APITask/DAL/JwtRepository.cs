namespace APITask.DAL
{
    public class JwtRepository : IJwtRepository
    {
        readonly CarsListDbContext _context;

        public JwtRepository(CarsListDbContext context)
        {
            _context = context;
        }

        public Car GetCar(string brand)
        {
            return _context.Cars.FirstOrDefault(A => A.Brand == brand);
        }

        public void SaveCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }
        public Account GetAccount(string username)
        {
            return _context.Accounts.FirstOrDefault(A => A.Username == username);
        }

        public void SaveAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}
