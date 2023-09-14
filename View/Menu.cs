namespace FIFO.View
{
    internal class Menu
    {
        public static string GetUserSelection()
        {
            #region Menu UI
            Console.Title = "Order menu";
            Console.Clear();
            Console.WriteLine("           __________                       ");
            Console.WriteLine("         .'----------`.                     ");
            Console.WriteLine("         | .--------. |                     ");
            Console.WriteLine("         | |########| |       __________    ");
            Console.WriteLine("         | |########| |      /__________\\  ");
            Console.WriteLine(".--------| `--------' |------|    --=-- |---");
            Console.WriteLine("|        `----,-.-----'      |o ======  |   ");
            Console.WriteLine("|       ______|_|_______     |__________|   ");
            Console.WriteLine("|      /  %%%%%%%%%%%%  \\                  ");
            Console.WriteLine("|     /  %%%%%%%%%%%%%%  \\                 ");
            Console.WriteLine("|     ^^^^^^^^^^^^^^^^^^^^                  ");
            Console.WriteLine("+-------------------------------------------");
            Console.WriteLine("==================================\n");
            Console.WriteLine("     Fast food Operations Menu    \n");
            Console.WriteLine("==================================\n");
            Console.WriteLine("1. Add customer order");
            Console.WriteLine("2. Serve next customer");
            Console.WriteLine("3. Show the number of customer orders");
            Console.WriteLine("4. Show min and max customer orders");
            Console.WriteLine("5. Find a customer order");
            Console.WriteLine("6. Print all customer orders");
            Console.WriteLine("7. Exit\n\n");
            #endregion
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine()!;
            return choice;
        }
        public static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ReadKey();
            Console.ResetColor();
        }
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ReadKey();
            Console.ResetColor();
        }
        /// Gets the amount of order items to put in customer order from user input
        public static string OrderAmountInput()
        {
            Console.Title = "Creating customer order...";
            Console.Clear();
            Console.Write("Number of items in order: ");
            string number = Console.ReadLine()!;
            return number;
        }
        /// Prompts every order item string from a for loop
        public static string RequestOrder(int i)
        {
            Console.Write($"Order {i + 1}: ");
            string item = Console.ReadLine()!;
            return item;
        }
        /// Outputs the first customer in queue to serve, and asks user if they want to serve them or not
        public static string ServeRequest()
        {
            if (Model.Queue.Customers.Any())
            {
                Console.Title = "Serving customer...";
                Console.Clear();
                Console.WriteLine("Next customer:\n");
                Model.Customer nextCustomer = Model.Queue.Customers.Peek();
                Console.WriteLine($"Order ID: {nextCustomer.GetOrderId()}");
                Console.WriteLine($"Order: {nextCustomer.GetOrder()}");
                Console.WriteLine($"Order date: {nextCustomer.GetOrderDate()}\n");
                Console.WriteLine("Serve customer? [y], [n]");
                string choice = Console.ReadLine()!;
                return choice;
            }
            else
            {
                return "none";
            }

        }

        public static void ShowCustomerCount()
        {
            int count = Model.Queue.Customers.Count;
            Console.WriteLine($"There are {count} customer(s) orders in queue");
            Console.ReadKey();
        }

        public static (string min, string max) GetMinMax()
        {
            Console.Write("Minimum value: ");
            string minValue = Console.ReadLine()!;
            Console.WriteLine();
            Console.Write("Maximum value: ");
            string maxValue = Console.ReadLine()!;
            return (min: minValue, max: maxValue);
        }
        /// Output single order
        public static void OutputOrder(Model.Customer order)
        {
            Console.Title = "Min max";
            Console.WriteLine($"Order ID: {order.GetOrderId()}");
            Console.WriteLine($"Order: {order.GetOrder()}");
            Console.WriteLine($"Order date: {order.GetOrderDate()}\n");
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void OutputAllOrders()
        {
            Console.Title = "All orders";
            Console.Clear();
            if (Model.Queue.Customers.Any())
            {
                foreach (Model.Customer order in Model.Queue.Customers)
                {
                    Console.WriteLine($"Order ID: {order.GetOrderId()}");
                    Console.WriteLine($"Order: {order.GetOrder()}");
                    Console.WriteLine($"Order date: {order.GetOrderDate()}\n");
                }
            }
        }

        public static string OrderIdToFind()
        {
            Console.Clear();
            Console.Title = "Find order by ID";
            Console.Write("Order ID to find: ");
            string orderId = Console.ReadLine()!;
            return orderId;
        }
    }
}