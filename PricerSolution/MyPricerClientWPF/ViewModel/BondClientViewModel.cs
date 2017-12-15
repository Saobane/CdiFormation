using MyPricerClientWPF.Model;
using MyPricerClientWPF.MyPricerService;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyPricerClientWPF.ViewModel
{
    public class BondClientViewModel : INotifyPropertyChanged
    {
        MyPricerService.MyPricerServiceClient client;


        public BondClientViewModel()
        {
            client =new  MyPricerService.MyPricerServiceClient();
            
            BondCLient = GetDefaultBond();
            SetMyView(BondCLient);


        }

        private void SetMyView(BondClient bondClient)
        {
            var bondDateAndPrices = client.ComputeToBondLastDate(MapClientFixBondWithLibraryFixBond(BondCLient));
            var bondPrices = bondDateAndPrices.Values.ToArray();
            var bondDates = bondDateAndPrices.Keys.ToArray();



            Model = new PlotModel { Title = "Pricer" };

            Model.Title = "Pricer";
            Model.Subtitle = "using OxyPlot ";

            var series1 = new LineSeries();
            series1.Title = "Series 1";
            series1.MarkerType = MarkerType.Circle;

            for (int i = 0; i < bondDateAndPrices.Count; i++)
            {
                series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(bondDates[i]), bondPrices[i]));
            }


            Model.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "dd/MM/yyyy" });
            Model.Series.Add(series1);
        }

        private PlotModel model;

        public PlotModel Model { get { return model; } set { model = value; NotifyPropertyChanged("Model"); } }
        

        private BondClient _bondClient;

        public BondClient BondCLient
        {
            get {  return _bondClient;  }
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
            bond.Maturity = 2;
            bond.Periodicity = 6;
            bond.IssueDate = DateTime.Parse("01/01/1993");
            bond.Rate = 0.05;
            bond.Nominal = 100;
            return bond;
        }

        //private List<double> GetBondPrices(BondClient bond)
        //{
        //    var libraryBond = MapClientFixBondWithLibraryFixBond(bond);

        //    var dates = GetPricingDates(libraryBond);
        //    List<double> prices = new List<double>();
        //    double bondPrice;
        //    int i = 0;

        //    foreach (var item in dates)
        //    {
        //        bondPrice = client.Compute(libraryBond, item);
        //        prices.Add(bondPrice);
        //        i++;
        //        if (i==30)
        //        {

        //        }

        //    }

        //    return prices;
        //}
        private BondWcf MapClientFixBondWithLibraryFixBond(BondClient clientBond)
        {
            // A revoir !!!
            var bond = new BondWcf();
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


        //private List<DateTime> GetPricingDates(BondWcf bond)
        //{
        //    List<DateTime> dates = new List<DateTime>();
        //    DateTime firstPricingDate = GetFirstPricingDate();


        //    var lastDate = client.GetLastDate(bond);


        //    while (firstPricingDate != lastDate.AddDays(1))
        //    {
        //        dates.Add(firstPricingDate);
        //        firstPricingDate = firstPricingDate.AddDays(1);

        //    }
        //    return dates;

        //}

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null) { 
                    mUpdater = new Updater();
                    mUpdater.CanExecuteChanged += MUpdater_CanExecuteChanged;
                }
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private void MUpdater_CanExecuteChanged(object sender, EventArgs e)
        {
            SetMyView(BondCLient);
            Model.InvalidatePlot(true);
        }

        private class Updater : ICommand
        {
            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {
                CanExecuteChanged(this, new EventArgs());
            }
            #endregion
        }



    }
}
