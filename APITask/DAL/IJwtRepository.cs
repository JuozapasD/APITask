namespace APITask.DAL
{
    public interface IJwtRepository
    {
        void SaveCar(Car account);
        Car GetCar(string username);

        void SaveAccount(Account account);
        Account GetAccount(string username);
    }
}
