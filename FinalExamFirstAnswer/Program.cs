using System;

namespace FinalExamFirstAnswer
{
   public class Program
    {
        static void Main(string[] args)
        {
            SalesPublisher p = new SalesPublisher();
            SalesSubscriber s = new SalesSubscriber();
            p.SalesEvent += s.IamInterestedInSale;
            string message = $"Sale is on at {DateTime.Now} ";
            p.SaleIsOn(new CustomizedEventArgs(message));
        }
    }

    public class CustomizedEventArgs:EventArgs
    {
        public string _message { get; set; }
        public CustomizedEventArgs(string message)
        {
            _message = message;
        }
    }

    public delegate void SalesDelegate(object source, CustomizedEventArgs e);

    public class SalesPublisher
    {
        public event SalesDelegate SalesEvent;

        public void SaleIsOn(CustomizedEventArgs e)
        {
            if(SalesEvent!=null)
            {

                SalesEvent(this, e);
            }
        }

    }

    public class SalesSubscriber
    {

        public void IamInterestedInSale(object source, CustomizedEventArgs e)
        {
            Console.WriteLine(e._message);
        }
    }
}
