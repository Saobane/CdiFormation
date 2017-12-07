using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace CallBackWcfService
{
    [ServiceBehavior(ConcurrencyMode =ConcurrencyMode.Multiple,InstanceContextMode =InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        public void Process(int value)
        {
            for (int i = 0; i < value*100; i++)
            {
                Thread.Sleep(50 * value);
                OperationContext.Current.GetCallbackChannel<ITestCallBack>().progress(i);
            }
           
            // return string.Format("You entered: {0}", value);
        }

    }
}
