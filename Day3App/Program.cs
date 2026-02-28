using System;
using System.Runtime.CompilerServices;

class Day3
{
    static void Main()
    {
        // ここでキャラクターを2体作成し、戦わせる
        // Character hero = new Character("勇者", 100, 20);
        // ...
        Fighter hero = new Fighter("勇者", 100, 20);
        Character slime = new Character("スライム", 300, 5);

        while(true)
        {
            hero.Attack(slime);
            if(slime.Hp == 0) break;
            slime.Attack(hero);
            if(hero.Hp == 0) break;
        }
        
    }
}

class Character
{
    public string? Name;
    public int Hp;
    public int AttackPower;
    public Character(string name, int hp, int Ap)
    {
        Name = name;
        Hp = hp;
        AttackPower = Ap;
    }
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            Console.WriteLine(Name+"　は倒れた！");
        }
    }
    public virtual void Attack(Character target)
    {
        Console.WriteLine($"{Name}の攻撃！{target.Name}に{AttackPower}のダメージ！");
        target.TakeDamage(AttackPower);
    }
    // ここにプロパティ、コンストラクタ、メソッドを記述する
}

class Fighter : Character
{
    public Fighter(string name, int hp, int ap) : base(name, hp, ap)
    {
    }
    
    public override void Attack(Character target)
    {
        Random rand = new Random();
        int num = rand.Next(0, 10); // 0から9までのランダムな整数を生成
        if (num < 3) 
        {
            Console.WriteLine($"{Name}のかいしんの一撃！");
            Console.WriteLine($"{Name}の攻撃！{target.Name}に{AttackPower*2}のダメージ！");
            target.TakeDamage(AttackPower * 2);
            // 30%の確率でここを通る
        }
        else base.Attack(target);
    }
}