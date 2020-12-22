using System;

namespace Coffee
{
    class Machine
    {
        public string name;
        public MachineState state;

        public Machine(string name, MachineState state)
        {
            this.name = name;
            this.state = state;
        }

        public void reset()
        {
            this.state = MachineState.A;
        }
        public void finalize()
        {
            Console.WriteLine("");
            Console.WriteLine("                        (");
            Console.WriteLine("                          )     (");
            Console.WriteLine("                   ___...(-------)-....___");
            Console.WriteLine("               .-''       )    (          ''-.");
            Console.WriteLine("         .-'``'|-._             )         _.-|");
            Console.WriteLine("        /  .--.|   `''---...........---''`   |");
            Console.WriteLine("       /  /    |                             |");
            Console.WriteLine("       |  |    |    _____________________    |");
            Console.WriteLine("        ∖  ∖   |    |                    |   |");
            Console.WriteLine("         `∖ '∖ |    |  Enjoy your drink! |   |");
            Console.WriteLine("           `∖ `|    |____________________|   |");
            Console.WriteLine("           _/ /∖                             /");
            Console.WriteLine("          (__/  ∖                           /");
            Console.WriteLine("       _..---''` ∖                         /`''---.._");
            Console.WriteLine("    .-'           ∖                       /          '-.");
            Console.WriteLine("   :               `-.__             __.-'              :");
            Console.WriteLine("   :                  ) ''---...---'' (                 :");
            Console.WriteLine("    '._               `'--...___...--'`              _.'");
            Console.WriteLine("      ∖''--..__                              __..--'' / ");
            Console.WriteLine("       '._     '''----.....______.....----'''     _.'");
            Console.WriteLine("          `''--..,,_____            _____,,..--''`");
            Console.WriteLine("                        `'''----'''`");
            Console.WriteLine();
            Console.ReadKey();
        }

        public void start()
        {
            Economy coin = Economy.Null;
            do
            {
                switch (this.state)
                {
                    case MachineState.A:
                        coin = Program.getCoin();
                        if (coin == Economy.Nickel)
                            this.state = MachineState.B;
                        else if (coin == Economy.Dime)
                            this.state = MachineState.C;
                        else if (coin == Economy.Quarter)
                        {
                            Console.WriteLine("The change: " + this.giveChange(Economy.Nickel));
                            this.reset();
                            this.finalize();
                        } else
                        {
                            Console.WriteLine("You entered an invalid coin!");
                            this.reset();
                        }
                        break;
                    case MachineState.B:
                        coin = Program.getCoin();
                        if (coin == Economy.Nickel)
                            this.state = MachineState.C;
                        else if (coin == Economy.Dime)
                            this.state = MachineState.D;
                        else if (coin == Economy.Quarter)
                        {
                            Console.WriteLine("The change: " + this.giveChange(Economy.Dime));
                            this.reset();
                            this.finalize();
                        }
                        else
                        {
                            Console.WriteLine("You entered an invalid coin!");
                            this.reset();
                        }
                        break;
                    case MachineState.C:
                        coin = Program.getCoin();
                        if (coin == Economy.Nickel)
                            this.state = MachineState.D;
                        else if (coin == Economy.Dime)
                            this.finalize();
                        else if (coin == Economy.Quarter)
                        {
                            Console.WriteLine("The change: " + this.giveChange(Economy.Nickel) + " & " + this.giveChange(Economy.Dime));
                            this.reset();
                            this.finalize();
                        }
                        else
                        {
                            Console.WriteLine("You entered an invalid coin!");
                            this.reset();
                        }
                        break;
                    case MachineState.D:
                        coin = Program.getCoin();
                        if (coin == Economy.Nickel)
                        {
                            this.reset();
                            this.finalize();
                        }
                        else if (coin == Economy.Dime)
                        {
                            this.reset();
                            Console.WriteLine("The change: " + this.giveChange(Economy.Nickel));
                            this.finalize();
                        }
                        else if (coin == Economy.Quarter)
                        {
                            Console.WriteLine("The change: " + this.giveChange(Economy.Nickel) + " & " + this.giveChange(Economy.Dime));
                            this.state = MachineState.B;
                            this.finalize();
                        }
                        else
                        {
                            Console.WriteLine("You entered an invalid coin!");
                            this.reset();
                        }
                        break;
                }
            } while (true);
        }

        public string giveChange(Economy coin)
        {
            if (coin == Economy.Dime)
                return "1 #D";
            if (coin == Economy.Nickel)
                return "1 #N";
            return "";
        }
    }
}
