using System;

namespace DataStructuresAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //公鸡每只5元，母鸡每只3元，三只小鸡1元，用100元买100只鸡，问公鸡、母鸡、小鸡各多少只？
            int k = 0;
            for (int i = 0; i < 20; i++) {
                for (int j = 0; j < 33; j++) {
                    k = 100 - i - j;
                    if (i + j +k== 100 && 7 * i + 4 * j == 100)
                    {
                        Console.WriteLine("买公鸡:{0}只,母鸡:{1}只,小鸡:{2}只,可达到百钱买百只鸡", i,j,k);
                    }
                }
            }
        }
    }
}
