using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CallBackWcfService
{
    [ServiceContract(CallbackContract =typeof(ITestCallBack))]
    public interface IService1
    {
        [OperationContract(IsOneWay =true)]
        void Process(int value);
        
        
    }


}
