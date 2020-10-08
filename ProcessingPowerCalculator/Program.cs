using System;

namespace ProcessingPowerCalculator
{
    class Program
    {
        static void Main(string[] args)
        { 

            Console.WriteLine("Welcome to ProcessingPowerCalculator!");
            Console.WriteLine(" ");
            Console.WriteLine("This program calculates the amount of time required");
            Console.WriteLine("for the processing power to further improve");
            Console.WriteLine("by the multiplier you enter!");
            Console.WriteLine(" ");

            //Definim o variabila 'n' fiind multiplicatorul (putere de calcul de n ori mai mare)
            int n = 0;

            // Folosim structura repetitiva 'while' pentru a evita inchiderea programului in cazul in care apare
            // o eroare de conversie sau daca n < 2
            while (n < 1) {
                
                // Folosim methoda 'try & catch' pentru a evita erorile de conversie din string in int
                try {
                   
                    // Convertim valoarea introdusa in numar intreg si il atribuim lui 'n'
                    Console.WriteLine("Please enter the multiplier number:");
                    n = int.Parse(Console.ReadLine());

                    // Verificam daca n >= 2
                    if (n < 2) {
                        Console.WriteLine("Please enter positive integer higher than 1!");

                        // Ii atribuim lui 'n' valoarea 0 pentru a relua structura repetitiva 'while'
                        n = 0;

                        // Folosim keyword-ul 'continue' pentru a intrerupe iteratia curenta
                        continue;
                    }

                    // Calculam numarul de ani folosind formula (log2 2*(n-1))*1.5
                    // 1.5 - 1 an si jumatate (18 luni/12 luni)
                    // 2 * (n - 1) - dublarea de (n - 1) ori
                    // Rotunjim rezultatul la un numar cu o cifra decimala
                    double years = Math.Round(Math.Log(2*(n-1),2) * 1.5, 1);

                    // Afisam rezultatul
                    Console.WriteLine($"The Processing Power will encrease {n} times for the same price in {years} years!");
                } catch (Exception e) {

                    // In cazul in care nu s-a introdus un numar intreg, ii atribuim lui 'n' valoarea 0, afisam acest mesaj si reluam introducerea numarului
                    n = 0;
                    Console.WriteLine("Please use integers only!");
                }
            }

        }
    }
}
