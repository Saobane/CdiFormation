    namespace EventReview
{
    public class UnEmployedPricer : IBankPricer
    {
        public double GetAgio()
        {
            return 2.5/100D;
        }
    }
}