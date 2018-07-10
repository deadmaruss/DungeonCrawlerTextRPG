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
        public static int MillisecondsTimeout = 2000;

        public static int PlayerHealth = 100;
        public static int PlayerAttack = 5;
        public static int PlayerSpeed = 1;
        public static int InventorySpace = 16;
        public static int PlayerSneak = 1;
		
        static void Main(string[] args)
        {
            Console.WriteLine(PRISON01);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            Console.WriteLine(PRISON02);
            System.Threading.Thread.Sleep(MillisecondsTimeout);
            Console.WriteLine(PRISON03);
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
            EnemyNPC goblin1 = new EnemyNPC
            {
                NPCID = 001,
                NPCName = "Goblin Thug",
                NPCHealth = 10,
                NPCAttack = 10,
                NPCSpeed = 2
            };
            string PlayerChoice02 = Console.ReadLine();
            switch (PlayerChoice02)
            {
                case "y":
                    Console.WriteLine(CHOICE02Y);
                    System.Threading.Thread.Sleep(MillisecondsTimeout);
                    Random RollDice = new Random();
                    int dice = RollDice.Next(PlayerSneak, 8);
                    if (dice <= 4)
                    {
                        Console.WriteLine(STATCHKF);
                        System.Threading.Thread.Sleep(MillisecondsTimeout);
                        Console.WriteLine(goblin1.Encounter());
                        BattleSim(goblin1.NPCName, goblin1.NPCSpeed, goblin1.NPCHealth, goblin1.NPCAttack);
                    } else
                    {
                        Console.WriteLine(STATCHKS);
                        PlayerSneak++;
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
                    Console.WriteLine(goblin1.Encounter());
                    BattleSim(goblin1.NPCName, goblin1.NPCSpeed, goblin1.NPCHealth, goblin1.NPCAttack);
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
		
		public static void BattleSim(string EnemyName, int EnemySpeed, int EnemyHP, int EnemyAttack)
        {
            int AttackProb = PlayerSpeed - EnemySpeed;
            while (EnemyHP > 0 && PlayerHealth > 0)
            {
                Random rnd = new Random();
                int Attack = rnd.Next(AttackProb, 10);
                if (Attack > 4)
                {
                    EnemyHP = EnemyHP - PlayerAttack;
                    Console.WriteLine("You hit");
                    Console.WriteLine(ENEMYHP + EnemyHP);
                    Console.WriteLine(PLAYERHP + PlayerHealth);
					System.Threading.Thread.Sleep(MillisecondsTimeout);
                }
                else
                {
                    PlayerHealth = PlayerHealth - EnemyAttack;
                    Console.WriteLine(EnemyName + " hits");
                    Console.WriteLine(PLAYERHP + PlayerHealth);
                    Console.WriteLine(ENEMYHP + EnemyHP);
					System.Threading.Thread.Sleep(MillisecondsTimeout);
                }

            }
            if (EnemyHP == 0)
            {
                Console.WriteLine(VICTORY);
				System.Threading.Thread.Sleep(MillisecondsTimeout);
            }
            else
            {
                Console.WriteLine(DEFEAT);
				System.Threading.Thread.Sleep(MillisecondsTimeout);
            }
        }
    }
}

public class EnemyNPC
{
    public EnemyNPC() { }
    public EnemyNPC(int id, string name, int hp, int attack, int speed)
    {
        NPCID = id;
        NPCName = name;
        NPCHealth = hp;
        NPCAttack = attack;
        NPCSpeed = speed;
    }

    public int NPCID { get; set;  }
    public string NPCName { get; set; }
    public int NPCHealth { get; set; }
    public int NPCAttack { get; set; }
    public int NPCSpeed { get; set; }

    public string Encounter()
    {
        return NPCName + ", " + NPCHealth + " HP, " + NPCAttack + " Attack";
    }
}

public class PlayerItem
{
    public PlayerItem() {}
    public PlayerItem(int id, string name, int attack, int defence, int slot)
    {
        ItemID = id;
        ItemName = name;
        ItemAttackValue = attack;
        ItemDefenceValue = defence;
        ItemWeight = slot;
    }

    public int ItemID { get; set; }
    public string ItemName { get; set; }
    public int ItemAttackValue { get; set; }
    public int ItemDefenceValue { get; set; }
    public int ItemWeight { get; set; }
}