using System.ServiceModel;

namespace CallBackWcfService
{
    public interface ITestCallBack
    {
        [OperationContract(IsOneWay = true)]
        void progress(int i);
    }
}