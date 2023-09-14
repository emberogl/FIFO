namespace FIFO.Controller
{
    internal class Cycle
    {
        public void Start()
        {
            /// User select menu option
            string userSelection = View.Menu.GetUserSelection();
            switch (userSelection)
            {
                case "1":
                    AddCustomer();
                    break;
                case "2":
                    ServeNextCustomer();
                    break;
                case "3":
                    ShowNumberOfCustomers();
                    break;
                case "4":
                    ShowMinMax();
                    break;
                case "5":
                    FindCustomer();
                    break;
                case "6":
                    PrintCustomers();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Start();
                    break;
            }
        }
        #region Menu Options
        /// Add a customer order by specifying how many things they order
        public void AddCustomer() 
        {
            string amount = View.Menu.OrderAmountInput(); // Gets amount of orders to add to list
            if (Int32.TryParse(amount, out int intAmount))
            {
                List<string> orders = new List<string>();
                for (int i = 0; i < intAmount; i++)
                {
                    orders.Add(View.Menu.RequestOrder(i)); // Gets order name as a string (fx. Big Mac)
                }
                Model.Queue.Customers.Enqueue(new Model.Customer(Model.Queue.OrderCount + 1, orders, DateTime.Now)); // Adds to queue
                Model.Queue.OrderCount += 1; // New order ID in the system
                View.Menu.SuccessMessage($"Sucessfully added customer {Model.Queue.Customers.Last().GetOrderId()}");
                Start();
            }
            else 
            {
                View.Menu.ErrorMessage("Invalid amount"); // User input parsing failed
                Start(); 
            }
        }
        /// Gets the first order in queue to serve (dequeue)
        public void ServeNextCustomer()
        {
            string choice = View.Menu.ServeRequest();
            if (choice == "n")
            {
                Start();
            }
            else if (choice == "y")
            {
                Model.Queue.Customers.Dequeue();
                View.Menu.SuccessMessage("Customer served");
                Start();
            }
            else if (choice == "none")
            {
                View.Menu.ErrorMessage("No customers in queue");
                Start();
            }
            else 
            {
                View.Menu.ErrorMessage("Invalid answer");
                Start();
            }
        }
        public void ShowNumberOfCustomers()
        {
            View.Menu.ShowCustomerCount();
            Start();
        }
        /// Gets a range of orders based on how many order items the customer has in their list
        public void ShowMinMax()
        {
            (string min, string max) = View.Menu.GetMinMax();
            if (Int32.TryParse(min, out int minValue) && Int32.TryParse(max, out int maxValue))
            {
                View.Menu.Clear();
                bool success = false;
                foreach (Model.Customer customer in Model.Queue.Customers)
                {  
                    if (customer.GetListOrder().Count >= minValue && customer.GetListOrder().Count <= maxValue)
                    {
                        View.Menu.OutputOrder(customer);
                        success = true;
                    }
                }
                if (success)
                {
                    View.Menu.SuccessMessage($"\nOutputted orders between {minValue}-{maxValue}");
                }
                else
                {
                    View.Menu.ErrorMessage("No order found");
                }
                Start();
            }
        }
        /// Gets order ID specified by user
        public void FindCustomer()
        {
            string orderId = View.Menu.OrderIdToFind();
            if (Int32.TryParse(orderId, out int intOrderId))
            {
                Model.Customer foundCustomer = null!;

                foreach (Model.Customer customer in Model.Queue.Customers)
                {
                    if (customer.GetOrderId() == intOrderId)
                    {
                        foundCustomer = customer;
                        break;
                    }
                }

                if (foundCustomer != null)
                {
                    View.Menu.OutputOrder(foundCustomer);
                    View.Menu.SuccessMessage("Customer order found");
                    Start();
                }
                else
                {
                    View.Menu.ErrorMessage("\nCustomer order not found");
                    Start();
                }
            }
        }
        public void PrintCustomers()
        {
            View.Menu.OutputAllOrders();
            View.Menu.SuccessMessage("Press any key to continue");
            Start();
        }
        #endregion
    }
}