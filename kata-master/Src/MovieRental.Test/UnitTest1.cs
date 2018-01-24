using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRental_csharp.Completed;

namespace MovieRental.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStatement()
        {
            Movie movie = new Movie("Transformer", Movie.REGULAR);

            Rental rental = new Rental(movie, 3);

            Customer customer = new Customer("jpartogi");
            customer.AddRental(rental);

            String statement = customer.Statement();
            StringAssert.Contains(statement, "Transformer");
            
        }
    }
}
