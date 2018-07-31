using System;
using System.Collections.Generic;
using System.Linq;

class KeyRevolver
{
    static void Main(string[] args)
    {
        int bulletPrice = int.Parse(Console.ReadLine());
        int gunBarelSize = int.Parse(Console.ReadLine());
        Stack<int> bullets = new Stack<int>(Console.ReadLine()
             .Split()
             .Select(int.Parse));
        Queue<int> locks = new Queue<int>(Console.ReadLine()
            .Split()
            .Select(int.Parse));
        int intelligencePrice = int.Parse(Console.ReadLine());
        int bulletsInBarrel = gunBarelSize;

        while(bullets.Count != 0 && locks.Count != 0)
        {
            int bullet = bullets.Pop();

            if (bullet <= locks.Peek())
            {
                locks.Dequeue();
                Console.WriteLine("Bang!");
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            bulletsInBarrel--;
            intelligencePrice -= bulletPrice;

            if (bulletsInBarrel == 0 && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
                bulletsInBarrel = gunBarelSize;
            }
        }

        if (locks.Count > 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
        else
        {
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligencePrice}");
        }
    }
}