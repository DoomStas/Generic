namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileRepository<User> userRepository = new FileRepository<User>("users.txt");



            List<User> users = userRepository.GetAll();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            User newUser = new User
            {
                FirstName = "Alice",
                LastName = "Johnson",
                Age = 28
            };
            userRepository.Add(newUser);
            
            List<User> updatedUsers = userRepository.GetAll();
            foreach (var user in updatedUsers)
            {
                Console.WriteLine(user);
            }
        }
    }
}
