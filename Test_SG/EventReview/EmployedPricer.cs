namespace EventReview
{
    internal class EmployedPricer : IBankPricer
    {
        public double GetAgio()
        {
            return 3/100;
        }
    }
}