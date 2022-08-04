using System;

namespace space_simulations
{
    class Program
    {
        static void Main(string[] args){
            Console.WriteLine(Task1());
        }

        static byte[] Task1() {
            return new byte[] {6 , 6, 64, 3, 8, 1, 0 };
        }
        static byte[] Task2(){
            return new byte[] { 1, 8, 1, 0, 6 };
        }
    }
}
