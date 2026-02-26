using System;
using System.Collections.Generic;
using System.Globalization;
class day1
{
    static string pro_ver = "sample_1";
    static void Main() {
    int sum = 0;
    var numlist = new List<int>();
    while(true)
        {
            string entersum = Console.ReadLine();
            int a = int.Parse(entersum);
            if (a == -1)
            {
                break;
            }
            numlist.Add(a); 
        }

        for (int i=0; i < numlist.Count; i++) {
            sum += numlist[i];
        }
        System.Console.WriteLine("合計は: "+ sum );
    }
}
