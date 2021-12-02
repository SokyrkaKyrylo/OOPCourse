namespace OOPCourse.Main.Utilities
{
    internal class MoneyConverter
    {
        public static string Convert(decimal reward)
        {
            if (reward < 1)
                return $"{reward * 100} pennies";
            return $"{reward} dollars";
        }
    }
}
