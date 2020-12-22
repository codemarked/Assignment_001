using System;

namespace Coffee
{
    class Program
    {
        static Machine machine;
        
        static void Main(string[] args)
        {
            machine = new Machine("Coffee Machine", MachineState.A);
            machine.start();
        }

        public static Economy getCoin()
        {
            Economy coin = Economy.Null;
            Console.WriteLine();
            Console.WriteLine("Available coins:");
            Console.WriteLine("#N Nickel  | N");
            Console.WriteLine("#D Dime    | D");
            Console.WriteLine("#Q Quarter | Q");
            Console.WriteLine();
            Console.WriteLine("Current State: " + machine.state);
            Console.WriteLine();
            Console.WriteLine("Insert your coin: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "n")
                coin = Economy.Nickel; 
            else if (input.ToLower() == "d")
                coin = Economy.Dime; 
            else if (input.ToLower() == "q")
                coin = Economy.Quarter;
            return coin;
        }
    }
}
