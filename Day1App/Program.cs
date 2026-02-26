using System;
using System.Collections.Generic;
using System.Globalization;
class day1
{
    static string pro_ver = "sample_1";
    static void Main() {
    int sum = 0;
    int max_point = 0;
    int min_point = 0;
    var numlist = new List<int>();
    while(true)
        {
            string? input = Console.ReadLine();
            int num;
            if (!int.TryParse(input, out num))
            {
                Console.WriteLine("数値を入力してください");
                continue;
            }
            if (num == -1)
            {
                break;
            }
            numlist.Add(num); 
        }

        for (int i=0; i < numlist.Count; i++) {
            sum += numlist[i];
            if (numlist[max_point] < numlist[i])
            {
                max_point = i;
            } 
            else if (numlist[min_point] > numlist[i])
            {
                min_point = i;
            }
        }
        System.Console.WriteLine("平均は: "+ sum/numlist.Count);
        System.Console.WriteLine("最大値は: "+numlist[max_point]);
        System.Console.WriteLine("最小値は: "+numlist[min_point]);
    }
}
