using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyPricerWCFLibrary
{
    [ServiceContract]
    public interface IMyPricerService
    {
        [OperationContract]
        double Compute(BondWcf bond, DateTime pricerDate);
        [OperationContract]
        Dictionary<DateTime, double> ComputeToBondLastDate(BondWcf bond);


    }


}
