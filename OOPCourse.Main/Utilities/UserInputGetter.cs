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
                switch (input)
                {
                    case "Yes":
                        return true;
                    case "No":
                        return false;
                    default:
                        Console.WriteLine("Try to answer again, please");
                        break;
                }
            } while (input != "Yes" || input != "No");
            return false;
        }
    }
}
