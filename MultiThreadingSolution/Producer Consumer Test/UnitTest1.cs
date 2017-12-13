using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Producer_Consumer;
using System.Threading;

namespace Producer_Consumer_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PoducerConsumerProblem_Should_Succeed()
        {
            var producerConsumerProblem = new ProducerConsumerProblem();

            Thread.CurrentThread.Name = "Main Consumer Thread";
            var t1 = new Thread(
              () => producerConsumerProblem.Produce(1))
            { Name = "Producer Thread" };
            t1.Start();

            producerConsumerProblem.Consume();


            var t2 = new Thread(
                () =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        producerConsumerProblem.Produce(i);
                    }

                }
                )
            { Name = "Producer Thread 2" };

            t2.Start();
        }
    }
}
