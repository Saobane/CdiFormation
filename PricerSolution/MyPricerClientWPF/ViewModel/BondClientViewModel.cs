using MyPricerClientWPF.Model;
using MyPricerLibrary;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPricerClientWPF.ViewModel
{
    public class BondClientViewModel : INotifyPropertyChanged
    {
        IPricer pricer;

        public BondClientViewModel()


        {
            pricer = new Pricer();
            var defaultBond = GetDefaultBond();
            var bondPrices = GetBondPrices(defaultBond);
            var bondDates = GetPricingDates(MapClientFixBondWithLibraryFixBond(defaultBond)); ;



            Model = new PlotModel { Title = "Pricer" };

            Model.Title = "Pricer";
            Model.Subtitle = "using OxyPlot ";

        var series1 = new LineSeries();
            series1.Title = "Series 1";
            series1.MarkerType = MarkerType.Circle;

            for (int i = 0; i < bondPrices.Count; i++)
            {
                series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(bondDates[i]), bondPrices[i]));
            }


            Model.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "dd/MM/yyyy" });
            Model.Series.Add(series1);
        }

        

        public PlotModel Model { get; set; }
        

        private BondClient _bondClient;

        public BondClient BondCLient
        {
            get { return _bondClient; }
            set { _bondClient = value; NotifyPropertyChanged("BondClient"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }


        }

        private BondClient GetDefaultBond()
        {
            BondClient bond = new BondClient();
            bond.Maturity = 4;
            bond.Periodicity = 6;
            bond.IssueDate = DateTime.Parse("20/05/1993");
            bond.Rate = 0.06;
            bond.Nominal = 100;
            return bond;
        }

        private List<double> GetBondPrices(BondClient bond)
        {
            var libraryBond = MapClientFixBondWithLibraryFixBond(bond);

            var dates = GetPricingDates(libraryBond);
            List<double> prices = new List<double>();
            double bondPrice;


            foreach (var item in dates)
            {
                bondPrice = pricer.Compute(libraryBond, item);
                prices.Add(bondPrice);
            }

            return prices;
        }
        private Bond MapClientFixBondWithLibraryFixBond(BondClient clientBond)
        {
            // A revoir !!!
            var bond = new FixRateBond();
            bond.Maturity = clientBond.Maturity;
            bond.Periodicity = clientBond.Periodicity;
            bond.IssueDate = clientBond.IssueDate;
            bond.Rate = clientBond.Rate;
            bond.Nominal = clientBond.Nominal;
            
            return bond;

        }
        private DateTime GetFirstPricingDate()
        {

            return new DateTime(1993, 1, 1);
        }


        private List<DateTime> GetPricingDates(Bond bond)
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime firstPricingDate = GetFirstPricingDate();


            var lastDate = bond.GetLastDate();


            while (firstPricingDate != lastDate.AddDays(1))
            {
                dates.Add(firstPricingDate);
                firstPricingDate = firstPricingDate.AddDays(1);

            }
            return dates;

        }


    }
}
