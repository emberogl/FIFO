namespace FIFO.Model
{
    public class Customer
    {
        private int _orderId { get; set; }
        private List<string> _order { get; set; }
        private DateTime _orderDate { get; set; }
        public Customer(int orderId, List<string> order, DateTime orderDate)
        {
            _orderId = orderId;
            _order = order;
            _orderDate = orderDate;
        }
        public int GetOrderId()
        {
            return _orderId;
        }
        public string GetOrder()
        {
            return string.Join(", ", _order);
        }

        /// For counting
        public List<string> GetListOrder()
        {
            return _order;
        }
        
        public DateTime GetOrderDate()
        {
            return _orderDate;
        }
    }
}
