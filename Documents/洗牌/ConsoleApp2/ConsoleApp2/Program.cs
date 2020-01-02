using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int colorIndex = 0;
            int tempValue = 0;
            int[] card = { 12, 32, 23, 11, 13, 44, 52, 22, 33, 42, 43, 34, 25 };
            int [] x=PaiXu(card);
            for (int i = 0; i < x.Length; i++)
            {
                if (i % 13 == 0 && i != 0)
                {
                    colorIndex++;
                }

                Char b = 'A';
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


        }
        public static int[] PaiXu(int[] card, int number = 0)
        {
            //Debug.Log(" ... 对手牌 进行 牌值 花色 的排序 ... ... ");
            if (number == 0) { number = card.Length; }
            if (card.Length == 0) { return card; }
            // ========== 根据牌值进行排序 ===============
            int temp = 0;
            for (int i = 0; i < card.Length; i++) //冒泡排序... 从大到小
            {
                for (int j = 0; j < card.Length - 1 - i; j++)
                {
                    if (card[j] < card[j + 1])
                    {
                        temp = card[j];
                        card[j] = card[j + 1];
                        card[j + 1] = temp;
                    }
                }
            }
            List<int> hei = new List<int>();
            List<int> hong = new List<int>();
            List<int> mei = new List<int>();
            List<int> fang = new List<int>();
            List<int> wang = new List<int>();
            for (int i = 0; i < card.Length; i++)
            {
                #region ======= 根据花色分组 ..大小王 单独一组 ...后续对花色中的 A 单独处理 =========
                switch (sendFlower(card[i]))
                {
                    case 3: //黑桃          
                        hei.Add(card[i]);
                        break;
                    case 2: //红桃         
                        hong.Add(card[i]);
                        break;
                    case 1: //梅花          
                        mei.Add(card[i]);
                        break;
                    case 0: //方片          
                        fang.Add(card[i]);
                        break;
                    case 4: //小王
                    case 5: //大王
                        wang.Add(card[i]);
                        break;
                }
                #endregion
            }
            QuA(hei); // 对A 的单独处理
            QuA(hong);
            QuA(mei);
            QuA(fang);
            #region ========== 合并 排序后的牌组========
            List<int> cardlist = new List<int>();
            for (int i = 0; i < wang.Count; i++)  //王
            {
                cardlist.Add(wang[i]);
            }
            // ==========合并 组拼 ============
            List<int> cardtemp = new List<int>();
            cardtemp = PaiXuZuPin(hei, hong, mei, fang);
            for (int i = 0; i < cardtemp.Count; i++)
            {
                cardlist.Add(cardtemp[i]);
            }
            int[] cards = new int[cardlist.Count];
            for (int i = 0; i < cardlist.Count; i++)
            {
                cards[i] = cardlist[i];
            }
            #endregion
            return cards;
        }
        /// <summary>
        /// 取A  -- 把每个花色牌中的A，放到前面（A.K.Q.J...）
        /// </summary>
        /// <param name="hei">花色牌</param> 
       public static void  QuA(List<int> hei)
        {
            if (hei.Count == 0) return;
            List<int> cardlist = new List<int>();
            for (int i = 0; i < hei.Count; i++) // 将牌添加到新列表
            {
                cardlist.Add(hei[i]);
            }
            if (hei.Count > 2)
            {
                if (hei[hei.Count - 2] % 13 == 1)  //如果有两个A (对两幅牌的处理)
                {
                    cardlist.Insert(0, hei[hei.Count - 2]);
                    cardlist.Insert(0, hei[hei.Count - 1]);
                    for (int i = 0; i < hei.Count; i++)
                    {
                        hei[i] = cardlist[i];
                    }
                    return;
                }
            }
            if (hei[hei.Count - 1] % 13 == 1)  //如果有一个A
            {
                cardlist.Insert(0, hei[hei.Count - 1]);
            }
            for (int i = 0; i < hei.Count; i++)
            {
                hei[i] = cardlist[i];
            }
        }
        /// <summary>
        /// 根据传入牌组 的顺序 进行组拼 
        /// </summary>
        public static List<int> PaiXuZuPin(List<int> one, List<int> two, List<int> three, List<int> four)
        {
            List<int> cardlist = new List<int>();
            for (int i = 0; i < one.Count; i++)
            {
                cardlist.Add(one[i]);
            }
            for (int i = 0; i < two.Count; i++)
            {
                cardlist.Add(two[i]);
            }
            for (int i = 0; i < three.Count; i++)
            {
                cardlist.Add(three[i]);
            }
            for (int i = 0; i < four.Count; i++)
            {
                cardlist.Add(four[i]);
            }
            return cardlist;
        }
        /// <summary>
        /// 根据牌值取花色 5:大王 | 4:小王 | 3:黑桃 | 2:红桃 | 1:梅花 | 0:方片 
        /// </summary>
        /// <param name="card"></param>
        public static int sendFlower(int card)
        {
            if (card >= 1 && card <= 13)
            {
                return 3;
            }
            else if (card >= 14 && card <= 26)
            {
                return 2;
            }
            else if (card >= 27 && card <= 39)
            {
                return 1;
            }
            else if (card >= 40 && card <= 52)
            {
                return 0;
            }
            else if (card == 53)
            {
                return 4;
            }
            return 5;
        }
    }
}
