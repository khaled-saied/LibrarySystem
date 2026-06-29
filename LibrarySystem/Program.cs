using LibrarySystem.Helper;
using LibrarySystem.Service;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Seed Data
            var branch = DataSeedind.Seed();

            var display = new DisplayService();
            var libraryService = new LibraryService(branch, display);

            bool isRunning = true;

            while (isRunning)
            {
                try
                {
                    ConsoleHelper.ShowMenu();

                    string? choice = Console.ReadLine()?.Trim();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
                            display.ShowBranchInfo(branch);
                            break;

                        case "2":
                            display.ShowAllUsers(branch);
                            break;

                        case "3":
                            display.ShowAllAvailableCopies(branch);
                            break;

                        case "4":
                            display.ShowAllCopies(branch);
                            break;

                        case "5":
                            libraryService.HandleBorrow();
                            break;

                        case "6":
                            libraryService.HandleReturn();
                            break;

                        case "7":
                            libraryService.HandleHistory();
                            break;

                        case "8":
                            libraryService.HandleRegisterMember();
                            break;

                        case "0":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Thank you for using the Library System.");
                            Console.WriteLine("Goodbye!");
                            Console.ResetColor();

                            isRunning = false;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }

                if (isRunning)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue...");
                    Console.ResetColor();

                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
