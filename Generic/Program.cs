namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileRepository<User> userRepository = new FileRepository<User>("users.txt");

            Console.WriteLine("All users:");
            PrintUsers(userRepository.GetAll());
            Console.WriteLine();

            Console.WriteLine("Add new user:");
            User newUser = new User { FirstName = "John", LastName = "Doe", Age = 30 };
            userRepository.Add(newUser);
            PrintUsers(userRepository.GetAll());
            Console.WriteLine();

            Console.WriteLine("Get Id user");
            User user2 = userRepository.GetById(2);
            if (user2 != null)
            {
                Console.WriteLine(user2);
                PrintUsers(userRepository.GetAll());
            }
            else
            {
                Console.WriteLine("User with Id 2 not found.");
            }
            Console.WriteLine();

            Console.WriteLine("Update");
            User user1 = userRepository.GetById(1);
            if (user1 != null)
            {
                user1.Age = 25;
                userRepository.Update(user1);
                PrintUsers(userRepository.GetAll());
            }
            else
            {
                Console.WriteLine("User with Id 1 not found.");
            }

            Console.WriteLine();

            Console.WriteLine("Remowe");
            User user3 = userRepository.GetById(3);
            if (user3 != null)
            {
                userRepository.Remove(user3);
                PrintUsers(userRepository.GetAll());
            }
            else
            {
                Console.WriteLine("User with Id 3 not found.");
            }
            static void PrintUsers(List<User> users)
            {
                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
            }
        }
    }
}
