using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 洗扑克牌
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] cardColor = { "黑桃", "方块", "梅花", "红桃" };
            Card[] cardList = new Card[52];
            int colorIndex = 0;
            int tempValue = 0;
            for (int i = 0; i < cardList.Length; i++)
            {
                if (i % 13 == 0 && i != 0)
                {
                    colorIndex++;
                }

                Char a = 'A';
                tempValue = i % 13;
                switch (tempValue)
                {
                    case 0:
                        a = 'A';
                        break;
                    case 9:
                        a = '0';
                        break;
                    case 10:
                        a = 'J';
                        break;
                    case 11:
                        a = 'Q';
                        break;
                    case 12:
                        a = 'K';
                        break;
                    default:
                        a = (Char)(tempValue + (int)'1');
                        break;
                }

                cardList[i] = new Card()
                {
                    value = a,
                    color = cardColor[colorIndex]
                };
            }




            Console.WriteLine("洗牌之前:");
            ShowCard(cardList);

            ShuffleCard(cardList);

            Console.WriteLine("\n\n洗牌之后:");
            ShowCard(cardList);

            Console.ReadLine();
        }

        static void ShuffleCard(Card[] cardList)
        {
            Random random = new Random();
            int tempIndex = 0;
            Card temp = null;
            for (int i = 0; i < 52; i++)
            {
                tempIndex = random.Next(52);
                temp = cardList[tempIndex];
                cardList[tempIndex] = cardList[i];
                cardList[i] = temp;
            }
        }

        static void ShowCard(Card[] cardList)
        {
            for (int i = 0; i < cardList.Length; i++)
            {
                if (i % 13 == 0 && i != 0)
                {
                    Console.WriteLine("\n");
                }

                Console.Write(cardList[i].color + "" + cardList[i].value + " ");
            }
        }

    }

    public class Card
    {
        public char value;
        public string color;
    }


}
