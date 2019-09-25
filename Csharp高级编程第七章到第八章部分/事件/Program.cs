using System;
using System.Windows;

namespace 事件
{
    public class CarInfoEventArgs:EventArgs
    {
        public CarInfoEventArgs(string car)
        {
            this.Car = car;
        }
        public string Car { get; set; }

    }
    public class Cardealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;
        public void NewCar(string car)
        {
            Console.WriteLine("CarDealer,new car{0}", car);
            RaiseNewCarInfo(car);
        }
        public virtual void RaiseNewCarInfo(string car)
        {
            EventHandler<CarInfoEventArgs> newCarInfo = NewCarInfo;
            if (NewCarInfo != null)
            {
                NewCarInfo(this, new CarInfoEventArgs(car));
            }
        }

        

    }
    //事件监听器
    public class Consumer
    {
        private string name;
        public Consumer(string name)
        {
            this.name = name;
        }
        public void NewCarIsHere(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine("{0}:car{1} is new", name, e.Car);
        }
        //这下面的弱事件接口依然因为未知原因无法引用
        public bool IweakEventListener.ReceiveWeakEvent(Type managerType,object sender,EventArgs e)
        {
            NewCarIsHere(sender, e as CarInfoEventArgs);
            return true;
        }
    }

    //弱事件管理器
    //WeakEventManager类因为未知原因无法调用
    public class WeakCarInfoEventManager : WeakEventManager
    {
        public static void AddListener(object source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }
        public static void RemoveListener(object source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }
        public static WeakCarIntoEventManager CurrentManager
        {
            get
            {
                var manager = GetCurrentManager(typeof(WeakCarInfoEventManager))

                    as WeakCarInfoEventManager;
                if (manager == null)
                {
                    manager = new WeakCarInfoEventManager();
                    SetCurrentManager(typeof(WeakCarInfoEventManager), manager);
                }
                return manager;
            }

        }
        protected override void StartListening(object source)
        {
            (source as Cardealer).NewCarInfo += Cardealer_NewCarInfo;
        }
        void CarDealer_NewCarInfo(object sender, CarInfoEventArgs e)
        {
            DeliverEvent(sender, e);
        }
        protected override void StopListening(object source)
        {
            (source as Cardealer).NewCarInfo = CarDealer_NewCarInfo;
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            var dealer = new Cardealer();
            var michael = new Consumer("michael");
            //WeakCarInfoEventManager.AddListener(dealer, michael);        p213

            dealer.NewCarInfo += michael.NewCarIsHere;

            dealer.NewCar ("Ferrari");
            var sebastian = new Consumer("Sebastian");
            dealer.NewCarInfo += sebastian.NewCarIsHere;

            dealer.NewCar("Mercedes");

            dealer.NewCarInfo -= michael.NewCarIsHere;

            dealer.NewCar("Red Bull Racing");

            

        }
    }
}
