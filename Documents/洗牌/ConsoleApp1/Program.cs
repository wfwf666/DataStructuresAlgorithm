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

            string[] cardColor = { "方块", "梅花", "红桃", "黑桃" };
            int[] u = {
                    44,48,0,4,8,12,16,20,24,28,32,36,40,
                    45,49,1,5,9,13,17,21,25,29,33,37,41,
                    46,50,2,6,10,14,18,22,26,30,34,38,42,
                    47,51,3,7,11,15,19,23,27,31,35,39,43
            };         
          
            Card[] cardList = new Card[52];
            Card[] cardLists = new Card[54];
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
                        a = '十';
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
                cardList[i] = new Card
                {
                    value = a,
                    color = cardColor[colorIndex],
                    xia = u[i]
                };
            }

            Console.WriteLine("\n\n洗牌之前:");
            ShowCard(cardList);
            Console.WriteLine("\n\n洗牌之后:");
            Card[] tt = ShuffleCard(cardList);
            Card[] one = new Card[13];
            Card[] tow = new Card[13];
            Card[] three = new Card[13];
            Card[] four = new Card[13];
            //Card[] glide= new Card[3];
            for (int i = 0; i < tt.Length; i++)
            {

                if (i < 13)
                {
                    one[i] = new Card()
                    {
                        color = tt[i].color,
                        value = tt[i].value,
                        xia = tt[i].xia
                    };

                }
                else if (i < 26)
                {
                    tow[i-13] = new Card()
                    {
                        color = tt[i].color,
                        value = tt[i].value,
                        xia = tt[i].xia
                    };
                }
                else if (i < 39)
                {
                    three[i-26] = new Card()
                    {
                        color = tt[i].color,
                        value = tt[i].value,
                        xia = tt[i].xia
                    };
                }

                else
                {
                    four[i - 39] = new Card()
                    {
                        color = tt[i].color,
                        value = tt[i].value,
                        xia = tt[i].xia 
                    };
                }
            
            }
            ShuffleCard(cardList).CopyTo(cardLists,0);
            Console.Write("one手上的牌是：");
            ShowCard(one);
            Console.Write("tow手上的牌是：");
            ShowCard(tow);
            Console.Write("three手上的牌是：");
            ShowCard(three);
            Console.Write("four手上的牌是：");
            ShowCard(four);
            Console.WriteLine("各自手上洗牌后：");
            Console.Write("one手上的牌是：");
            ShowCards(one);
            Console.Write("tow手上的牌是：");
            ShowCards(tow);
            Console.Write("three手上的牌是：");
            ShowCards(three);
            Console.Write("four手上的牌是：");
            ShowCards(four);
            Console.ReadLine();
        }
        /// <summary>
        /// 随机洗牌
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
      public static Card[] ShuffleCard(Card[] cardList)
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

            return cardList;
        }
        /// <summary>
        /// 显示数组元素
        /// </summary>
        /// <param name="cardList"></param>
        static void ShowCard(Card[] cardList)
        {
            for (int i = 0; i < cardList.Length; i++)
            {
                

                Console.Write(cardList[i].color + "" + cardList[i].value + " "+cardList[i].xia+" ");
                if (i % 12 == 0 && i != 0)
                {
                    Console.WriteLine("\n");
                }
            }

        }
        /// <summary>
        /// 冒泡排序后显示
        /// </summary>
        /// <param name="cardList"></param>
        static void ShowCards(Card[] cardList)
        {
            Card aa = null;
            
            for (int j = 0; j < cardList.Length; j++)
            {
                for (int i = 0; i < cardList.Length - 1; i++)
                {
                    
                    if (cardList[i].xia  > cardList[i + 1].xia )
                    {
                        aa = cardList[i];
                        cardList[i] = cardList[i + 1];
                        cardList[i + 1] = aa;

                    }                   

                }
            }
            for (int i = 0; i < cardList.Length; i++)//显示排序好的卡牌
            {

                Console.Write(cardList[i].color + "" + cardList[i].value + " ");

            }
            Console.WriteLine();
        }


    }

    public class Card
    {
        public char value;//卡牌点数
        public string color;//卡牌花色
        public int xia;//卡牌下标
    }


}
