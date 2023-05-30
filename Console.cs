using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        #region 創建List
        /*
         * C# 創建無資料 List<"屬性"> 變數名稱 = new List<"屬性">();
         * C# 創建有資料 List<"屬性"> 變數名稱 = new List<"屬性">() {1,2,3};
         */
        #endregion
        #region 終端機顯示
        /*
         * List<int> myList = new List<int>(1,2,3);
         * Console.WritLine(myList) 會顯示List型態，非顯示List內的資料。需要轉換才能查看內容。
         * 第一種(單一)
         * foreach (int item in myList)
         *{
         * Console.WritLine(item)
         *}

         * 第二種(全部)
         * string result = string.Join(", ", myList);
         * Console.WriteLine(result);
         */
        #endregion
        static void Main(string[] args)
        {
            // Pokers Random
            Random random = new Random();
            // 初始Pokers
            List<int> myList = Pokers();
            Print(myList);

            // 假設 Mousec點選 洗牌
            for (int i = 4; i >= 0; i--)
            {
                FisherYates(myList, random);
                Print(myList);
            }


            // 終端機顯示
            ReadWindow();
        }

        private static void FisherYates(List<int> myList, Random random)
        {
            for (int i = myList.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = myList[i];
                myList[i] = myList[j];
                myList[j] = temp;
            }
        }

        private static void Print(List<int> myList)
        {
            string result = string.Join(", ", myList);
            Console.WriteLine($"{result}\n");
        }

        private static void ReadWindow()
        {
            Console.Read();
        }

        private static List<int> Pokers()
        {
            List<int> myList = new List<int>();
            for (int i = 1; i < 53; i++)
            {
                myList.Add(i);
            }

            return myList;
        }
    }
}
