using FIFO.Controller;

namespace FIFO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cycle controller = new Cycle();
            controller.Start();
        }
    }
}