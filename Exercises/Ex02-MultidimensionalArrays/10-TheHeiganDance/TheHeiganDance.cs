using System;
using System.Collections.Generic;
using System.Linq;

class TheHeiganDance
{
    static void Main(string[] args)
    {
        double playerDamage = double.Parse(Console.ReadLine());

        double heiganHealth = 3000000;
        int playerHealth = 18500;
        int[] playerPosition = new int[] { 7, 7 };
        int poisonDamage = 0;

        while (true)
        {
            string[] spellArgs = Console.ReadLine()
                .Split();

            string spell = spellArgs[0];
            int spellRow = int.Parse(spellArgs[1]);
            int spellCol = int.Parse(spellArgs[2]);

            heiganHealth -= playerDamage;
            playerHealth -= poisonDamage;
            poisonDamage = 0;

            if (heiganHealth <= 0 && playerHealth <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine("Player: Killed by Plague Cloud");
                Console.WriteLine($"Final position: {string.Join(", ", playerPosition)}");
                break;
            }
            else if (heiganHealth <= 0 && playerHealth > 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine($"Player: {playerHealth}");
                Console.WriteLine($"Final position: {string.Join(", ", playerPosition)}");
                break;
            }
            else if (heiganHealth > 0 && playerHealth <= 0)
            {
                Console.WriteLine($"Heigan: {heiganHealth:F2}");
                Console.WriteLine("Player: Killed by Plague Cloud");
                Console.WriteLine($"Final position: {string.Join(", ", playerPosition)}");
                break;
            }

            List<int[]> hitZone = new List<int[]>
            {
                new int[] { spellRow - 1, spellCol - 1 },
                new int[] { spellRow - 1, spellCol },
                new int[] { spellRow - 1, spellCol + 1 },
                new int[] { spellRow, spellCol - 1 },
                new int[] { spellRow, spellCol },
                new int[] { spellRow, spellCol + 1 },
                new int[] { spellRow + 1, spellCol - 1 },
                new int[] { spellRow + 1, spellCol },
                new int[] { spellRow + 1, spellCol + 1 }
            };

            if (hitZone.Any(x => x[0] == playerPosition[0] && x[1] == playerPosition[1]) == false)
            {
                continue;
            }

            int[] playerMove = new int[] { playerPosition[0] - 1, playerPosition[1] };

            if (hitZone.Any(x => x[0] == playerMove[0] && x[1] == playerMove[1]) == false && playerMove[0] >= 0)
            {
                playerPosition = playerMove;
                continue;
            }

            playerMove = new int[] { playerPosition[0], playerPosition[1] + 1 };

            if (hitZone.Any(x => x[0] == playerMove[0] && x[1] == playerMove[1]) == false && playerMove[1] <= 14)
            {
                playerPosition = playerMove;
                continue;
            }

            playerMove = new int[] { playerPosition[0] + 1, playerPosition[1] };

            if (hitZone.Any(x => x[0] == playerMove[0] && x[1] == playerMove[1]) == false && playerMove[0] <= 14)
            {
                playerPosition = playerMove;
                continue;
            }

            playerMove = new int[] { playerPosition[0], playerPosition[1] - 1 };

            if (hitZone.Any(x => x[0] == playerMove[0] && x[1] == playerMove[1]) == false && playerMove[1] >= 0)
            {
                playerPosition = playerMove;
                continue;
            }

            switch (spell)
            {
                case "Cloud":
                    poisonDamage = 3500;
                    playerHealth -= 3500;
                    spell = "Plague Cloud";
                    break;
                case "Eruption":
                    playerHealth -= 6000;
                    break;
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine($"Heigan: {heiganHealth:F2}");
                Console.WriteLine($"Player: Killed by {spell}");
                Console.WriteLine($"Final position: {string.Join(", ", playerPosition)}");
                break;
            }
        }
    }
}