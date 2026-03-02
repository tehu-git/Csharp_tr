using System;
using System.Runtime.CompilerServices;

class Day4
{
    static void Main()
    {
        // ここでキャラクターを2体作成し、戦わせる
        // Character hero = new Character("勇者", 100, 20);
        // ...
        Character Hero = new Character("勇者", 100, 70);
        Fighter fit = new Fighter("戦士", 100, 40);
        Wizard wiz = new Wizard("魔法使い", 80, 20, 50);
        Character slime = new Character("スライム", 1000, 5);
        var charalist = new List<Character>() {Hero, wiz, fit};

        while(true)
        {
            foreach(Character character in charalist)
            {
                character.Attack(slime);
                if(slime.Hp == 0) break;
                
            }
            if(slime.Hp == 0) break;
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

class Wizard : Character
{
    public int MP;
    public Wizard(string name, int hp, int ap, int mp) : base(name, hp, ap)
    {
        MP = mp;
    }
    
    public override void Attack(Character target)
    {
        if (MP >= 10)
        {
            MP -= 10;
            Console.WriteLine($"{Name}の魔法攻撃！{target.Name}に{AttackPower*3}のダメージ！");
            target.TakeDamage(AttackPower * 3);
        
        }
        else base.Attack(target);
    }
}