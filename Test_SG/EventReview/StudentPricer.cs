namespace EventReview
{
    internal class StudentPricer : IBankPricer
    {
        public double GetAgio()
        {
            return 2/100D;
        }
    }
}