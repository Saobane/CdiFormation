using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie = new Movie("Transformer", Movie.REGULAR);

            Rental rental = new Rental(movie, 3);

            Customer customer = new Customer("Sao");
            customer.AddRental(new Rental(new Movie("NARNIA", Movie.NEW_RELEASE), 5));

            customer.AddRental(rental);

            String statement = customer.Statement();
            System.Console.WriteLine(statement);
            Console.ReadLine();
        }
    }
}
