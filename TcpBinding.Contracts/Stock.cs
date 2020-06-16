using System;

namespace TcpBinding.Contracts
{
    public class Stock
    {
        public DateTime TimeSent { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
    }
}
