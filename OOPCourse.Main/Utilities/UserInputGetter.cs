using System;

namespace OOPCourse.Main.Utilities
{
    internal class UserInputGetter
    {
        public static bool GetUsersConfirm(string whatUserShouldConfirm)
        {
            string input = default;
            do
            {
                Console.WriteLine(whatUserShouldConfirm + " (Yes/No): ");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "yes":
                        return true;
                    case "no":
                        return false;
                    default:
                        Console.WriteLine("Try to answer again, please");
                        break;
                }
            } while (input.ToLower() != "yes" || input.ToLower() != "no");
            return false;
        }
    }
}
