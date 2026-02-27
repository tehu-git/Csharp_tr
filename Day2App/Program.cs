using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
class Day2
{
    static string program_ver = "sample2";
    static void Main()
    {
        int sum = 0;
        int max_point = 0;
        int min_point = 0;
        var numlist = new List<int>();
        while(true)
        {
            int num;
            string? input = Console.ReadLine();
            if(!int.TryParse(input, out num))
            {
                Console.WriteLine("数字を入力してください");
                continue;
            }
            if (num == -1)
            {
                break;
            }
            numlist.Add(num);
        }
        Console.WriteLine("探索数値を入力してください");
        
        int snum;
        while(true)
            {
                string? search = Console.ReadLine();
                if(!int.TryParse(search, out snum))
                {
                    Console.WriteLine("数字を入力してください");
                    continue;
                }
                else break;
            }       
        var searchlist = new List<int>();
        for(int i=0; i < numlist.Count; i++)
        {   

            sum += numlist[i];
            if(numlist[i] < numlist[min_point])
            {
                min_point = i;
            }
            if(numlist[i] > numlist[max_point])
            {
                max_point = i;
            }
            if(numlist[i] == snum)
            {
                searchlist.Add(i);
            }
        }

        if(numlist.Count!=0)
        {   
            Console.WriteLine("合計は: "+sum);
            Console.WriteLine("最大値は: "+numlist[max_point]);
            Console.WriteLine("最小値は: "+numlist[min_point]);
            int ave = sum/numlist.Count;
            Console.WriteLine("平均は: "+ave);
            Console.WriteLine("平均以上の点数は");
            for(int j=0; j<numlist.Count; j++)
            {
                if(numlist[j] >= ave)
                {
                    Console.WriteLine(numlist[j]);
                }
            }

        }
        if(searchlist.Count == 0) Console.WriteLine("見つかりませんでした");
        else Console.WriteLine(snum+"　のインデックスは"+string.Join(", ", searchlist));
    }
}
