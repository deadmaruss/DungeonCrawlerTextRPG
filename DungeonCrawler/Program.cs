using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonCrawler.Strings;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            int MillisecondsTimeout = 2000;

            int PlayerHealth = 100;
            int PlayerAttack = 5;
            int InventorySpace = 12;
            int Sneak = 1;
            Random rnd = new Random();

            Console.WriteLine(PRISON01);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            Console.WriteLine(PRISON02);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            Console.WriteLine(PRISON03);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            string PlayerChoice01 = Console.ReadLine();
            bool HavePrisonKey = false;
            switch (PlayerChoice01)
            {
                case "y":
                    Console.WriteLine(CHOICE01Y);
                    HavePrisonKey = true;
                    InventorySpace--;
                    System.Threading.Thread.Sleep(MillisecondsTimeout);
                    break;
                case "n":
                    Console.WriteLine(CHOICE01N);
                    System.Threading.Thread.Sleep(MillisecondsTimeout);
                    break;
                default:
                    Console.WriteLine(CHOICE01I);
                    System.Threading.Thread.Sleep(MillisecondsTimeout);
                    break;
            }
            Console.WriteLine(PRISON04);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            Console.WriteLine(PRISON05);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            Console.WriteLine(PRISON06);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            Console.WriteLine(PRISON07);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            string PlayerChoice02 = Console.ReadLine();
            switch (PlayerChoice02)
            {
                case "y":
                    Console.WriteLine(CHOICE02Y);
                    System.Threading.Thread.Sleep(MillisecondsTimeout);
                    int dice = rnd.Next(Sneak, 8);
                    if (dice <= 4)
                    {
                        Console.WriteLine(STATCHKF);
                        System.Threading.Thread.Sleep(MillisecondsTimeout);
                        EnemyNPC goblin1 = new EnemyNPC
                        {
                            NPCID = 001,
                            NPCName = "Goblin Thug",
                            NPCHealth = 10,
                            NPCAttack = 10
                        };
                        Console.WriteLine(goblin1.Encounter());
                        while (goblin1.NPCHealth > 0 && PlayerHealth > 0)
                        {
                            int Attack = rnd.Next(0, 5);
                            if (Attack > 3)
                            {
                                goblin1.NPCHealth = goblin1.NPCHealth - PlayerAttack;
                                Console.WriteLine("You hit");
                                Console.WriteLine(ENEMYHP + goblin1.NPCHealth);
                                Console.WriteLine(PLAYERHP + PlayerHealth);
                            }
                            else
                            {
                                PlayerHealth = PlayerHealth - goblin1.NPCAttack;
                                Console.WriteLine(goblin1.NPCName + " hits");
                                Console.WriteLine(PLAYERHP + PlayerHealth);
                                Console.WriteLine(ENEMYHP + goblin1.NPCHealth);
                            }
                            System.Threading.Thread.Sleep(MillisecondsTimeout);

                        }
                        if (goblin1.NPCHealth == 0)
                        {
                            Console.WriteLine(VICTORY);
                            System.Threading.Thread.Sleep(MillisecondsTimeout);
                        }
                        else
                        {
                            Console.WriteLine(DEFEAT);
                            System.Threading.Thread.Sleep(MillisecondsTimeout);
                        }
                    } else
                    {
                        Console.WriteLine(STATCHKS);
                        Sneak++;
                        System.Threading.Thread.Sleep(MillisecondsTimeout);
                    }
                    break;
                case "n":
                    Console.WriteLine(CHOICE02N);
                    System.Threading.Thread.Sleep(MillisecondsTimeout);
                    break;
                default:
                    Console.WriteLine(CHOICE02I);
                    System.Threading.Thread.Sleep(MillisecondsTimeout);
                    break;
            }
            Console.WriteLine(PRISON08);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            Console.WriteLine(PRISON09);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            if (HavePrisonKey == true)
            {
                Console.WriteLine(PRISON10);
                System.Threading.Thread.Sleep(MillisecondsTimeout);
            }
            else
            {
                Console.WriteLine(PRISON11);
                System.Threading.Thread.Sleep(MillisecondsTimeout);
                Console.WriteLine(FIELD01);
            }
        }
    }
}

public class EnemyNPC
{
    public EnemyNPC() { }
    public EnemyNPC(int id, string name, int hp, int attack)
    {
        NPCID = id;
        NPCName = name;
        NPCHealth = hp;
        NPCAttack = attack;
    }

    public int NPCID { get; set;  }
    public string NPCName { get; set; }
    public int NPCHealth { get; set; }
    public int NPCAttack { get; set; }

    public string Encounter()
    {
        return NPCName + ", " + NPCHealth + " HP, " + NPCAttack + " Attack";
    }
}