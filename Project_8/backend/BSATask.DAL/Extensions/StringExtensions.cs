namespace BSATask.DAL.Extensions
{
    public static class StringExtensions
    {
        public static string ChangeNewLinesToTabs(this string text)
        {
            return text.Replace("\n", "\n\t");
        }
    }
}
