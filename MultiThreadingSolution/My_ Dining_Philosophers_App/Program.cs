using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My__Dining_Philosophers_App
{
    public  class Philosoph
    {
        private int id;
        int rightFuck;
        int leftFuck;
       private  Diner _diner;
        public Philosoph(int i , Diner diner)
        {
            id = i;
            rightFuck = id==4? 1:id+1;
            leftFuck = id == 0 ? 4 : id - 1;
            _diner = diner;

            

        }

        public void Run()

        {


            while (true)
            {

                try

                {
                    Console.WriteLine("Philosopher " + id + " is thinking...");
                    Thread.Sleep(1000);

                    _diner.GetFucks(leftFuck, rightFuck,id);


                    //Console.ReadLine();

                    Thread.Sleep(2000);
                    Console.WriteLine("Philosopher " + id + " stop eating and start thinking...");
                   _diner.PutFucks(leftFuck, rightFuck, id);

                }

                catch

                {

                    return;

                }

            }

        }
    

    }
    public class PhiloFuck
    {
        //false : dispo 
        private bool _philoFuckState=false;

        public bool PhiloFuckState
        {
            get { return _philoFuckState; }
            set { _philoFuckState = value; }
        }


    }
    public class Diner
    {
        PhiloFuck[] dinerFucks;

        public IList<Philosoph> diners;

        public Diner(int dinersNumber)
        {
            diners = new Philosoph[dinersNumber];
            dinerFucks = new PhiloFuck[dinersNumber];

            for (int i = 0; i < 5; i++)
            {
                dinerFucks[i] = new PhiloFuck();
                diners[i] = new Philosoph(i,this);
            }
        }

        public void Start()
        {
            foreach (var item in diners)
            {
                new Thread(new ThreadStart(item.Run)).Start();
            }
        }

        public void GetFucks(int left, int right, int id)
        {
            lock (this)

            {

                while (dinerFucks[left].PhiloFuckState || dinerFucks[right].PhiloFuckState) {

                    Console.WriteLine("Philosopher " + id + " is trying to get fucks "+left+" and "+right+" ...");
                    Monitor.Wait(this);
                }

                dinerFucks[left].PhiloFuckState = true; dinerFucks[right].PhiloFuckState = true;

                Console.WriteLine("Philosopher " + id + " is eating with fuck " + left + " and " + right + " ...");
            }
        }

        public void PutFucks(int left, int right,int id)
        {

            lock (this)

            {

                dinerFucks[left].PhiloFuckState = false; dinerFucks[right].PhiloFuckState = false;

                Monitor.PulseAll(this);

            }
        }
    }
   

    class Program
    {
        static void Main(string[] args)
        {
            Diner d = new Diner(5);
            d.Start();
        }
    }
}
