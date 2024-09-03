using System.Drawing;
using System.Net.Cache;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace Module5
{
    internal class Program
    {
       
        static void Main(string[] args)
        {

            (string Name, string LastName, double Age, string[] Pets, string[] favcolors) User;

            User = GetUser();

            ShowUserInformation(in User);

        }

        // Заполнение Данных
        static (string Name, string LastName, double Age, string[] Pets, string[] favcolors) GetUser()
        {

            (string Name, string LastName, double Age, string[] Pets, string[] favcolors) User;

            ShowMessage("Введите имя");
           
            User.Name = Console.ReadLine();

            ShowMessage("Введите фамилию");

            User.LastName = Console.ReadLine();
            User.Age      = GetNumber("Сколько Вам лет?");

            ShowMessage("У Вас есть питомец? (Да/Нет)");

            bool HasPet = false;

            switch (Console.ReadLine())
            {
                case "Да":
                    HasPet = true;
                    break;
                default:
                    HasPet = false;
                    break;
            }

            if (HasPet)
            {
                int Count = GetNumber("Сколько у вас питомцев?");

                User.Pets = CreateArray(Count,"Введите имена питомцев");

            }
            else 
            {
                User.Pets = new string[0];
            }

            int CollorCount = GetNumber("Сколько у Вас любимых цветов?");

            User.favcolors = CreateArray(CollorCount, "Введите название цветов");
            return User;
        }
    
        static bool CheckNum(string age, out int intage) 
        {

            if (int.TryParse(age,out int resage)) {

                if (resage > 0)
                {
                    intage = resage;
                    return false;
                }
                else {
                    intage = 0;
                    return true;
                }
            }
            else {
                intage = 0;
                return true;
            }
        }

        static int GetNumber(string message) {

            string str;
            int intStr;

            do
            {
                Console.WriteLine(message);
                str = Console.ReadLine();

            } while (CheckNum(str, out intStr));

            return intStr;

        }

        static void ShowMessage(string message) => Console.WriteLine(message);

        static string[] CreateArray(int num,string message)
        {
            string[] Arr = new string[num];

            ShowMessage(message);

            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = Console.ReadLine();
            }

            return Arr;

        }

        //Вывод данных

        static void ShowUserInformation(in (string Name, string LastName, double Age, string[] Pets, string[] favcolors) User) {

            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            Console.WriteLine("Имя: {0}",User.Name);
            Console.WriteLine("Фамилия: {0}", User.LastName);
            Console.WriteLine("Возраст: {0}", User.Age);

            if (User.Pets.Length > 0) 
            {       
                Console.WriteLine("Питомцы:");

                for (int i = 0; i < User.Pets.Length; i++)
                {
                    Console.WriteLine("{0}) - {1}", i, User.Pets[i]);
                }
            }

            if (User.favcolors.Length > 0)
            {
                Console.WriteLine("Цвета:");

                for (int i = 0; i < User.favcolors.Length; i++)
                {

                    if (User.favcolors[i] == "red")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;

                    }
                    else if (User.favcolors[i] == "green")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (User.favcolors[i] == "cyan")
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (User.favcolors[i] == "yellow")
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    
                    //иначе без цвета

                    Console.WriteLine("{0}) - {1}", i+1, User.favcolors[i]);
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("-----------------------------");
        }
    }
}
