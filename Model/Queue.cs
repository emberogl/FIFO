namespace FIFO.Model
{
    public class Queue
    {
        // Order ID counter for running session
        public static int OrderCount { get; set; }
        // Main customer order queue
        public static Queue<Customer> Customers { get; set; } = new Queue<Customer>();
    }
}