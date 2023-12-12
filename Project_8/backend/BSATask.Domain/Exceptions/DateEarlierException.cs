namespace BSATask.Domain.Exceptions
{
    public class DateEarlierException : Exception
    {
        public DateEarlierException(string firstDateName, string secondDateName)
            : base($"{firstDateName} cannot be earlier than {secondDateName}")
        {

        }
    }
}
