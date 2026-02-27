using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

class Day2
{
    static void Main()
    {
        // ① スコアの入力処理を呼び出す
        List<int> numlist = GetScoresFromUser();

        // 空の場合はここでプログラムを終了（早期リターン）
        if (numlist.Count == 0) return; 

        // ② 検索する数値の入力処理を呼び出す
        int snum = GetSearchTarget();

        // ③ 統計の計算と表示を呼び出す
        CalculateAndDisplayStats(numlist);

        // ④ 検索と表示を呼び出す
        SearchAndDisplayIndex(numlist, snum);
    }

    // --- ここから下に、それぞれのメソッドの中身を実装してください ---

    static List<int> GetScoresFromUser()
    {
        var numlist = new List<int>();
        int num;
        while (true)
        {
            string? input = Console.ReadLine();
            if(!int.TryParse(input, out num))
            {
                Console.WriteLine("数値のみを入力してください");
                continue;
            }
            if(num == -1) break;
            else numlist.Add(num);
        }
        return numlist;
        // -1が入力されるまで数値をリストに追加し、そのリストを返す処理
    }

    static int GetSearchTarget()
    {
        Console.WriteLine("探索する数値を入力してください");
        int snum;
        while(true)
        {
        string? input = Console.ReadLine();
        if(!int.TryParse(input, out snum))
            {
                Console.WriteLine("数値のみを入力してください");
                continue;
            }
        else break;
        }
        return snum;
        // 探索数値を正しく入力させ、その数値を返す処理
    }

    static void CalculateAndDisplayStats(List<int> scores)
    {
        int max_point = 0;
        int min_point = 0;
        int ave;
        int sum =0;

        for (int i=0; i< scores.Count; i++)
        {
            sum += scores[i];
            if(scores[i]<scores[min_point]) min_point = i;
            if(scores[i]>scores[max_point]) max_point = i;

        }
        Console.WriteLine("合計は: "+sum);
        Console.WriteLine("最大値は: "+scores[max_point]);
        Console.WriteLine("最小値は: "+scores[min_point]);
        ave = sum/scores.Count;
        Console.WriteLine("平均は: "+ave);
        for (int j=0; j<scores.Count; j++)
        {
            if(scores[j] >= ave) Console.WriteLine(scores[j]);
        }
        // 合計、最大、最小、平均、平均以上の表示を行う処理
        // (先ほどの numlist は scores という名前に変わって渡されてきます)
    }

    static void SearchAndDisplayIndex(List<int> scores, int target)
    {   
        bool isfound = false;
        for (int j=0; j<scores.Count; j++)
        {
            if(scores[j] == target) 
            {
                isfound = true;
                Console.WriteLine(j+1+"番目");
            }
        // ターゲット数値がリストの何番目にあるかを探し、表示する処理
        }
        if (isfound == false) Console.WriteLine("見つかりませんでした");
    }
}