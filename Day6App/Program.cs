using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using System.Linq;
class Day6
{
    static void Main()
    {
        // ここでキャラクターを2体作成し、戦わせる
        // Character hero = new Character("勇者", 100, 20);
        // ...
        Character Hero = new Character("勇者", 100, 70);
        Fighter fit = new Fighter("戦士", 100, 40);
        Wizard wiz = new Wizard("魔法使い", 80, 20, 50);
        var charalist = new List<Character>() {Hero, wiz, fit};
        
        Character slime = new Character("スライム", 1000, 50);
        Material box = new Material("木箱", 100);
        var entitylist = new List<IDamageable>() {slime, box};

        while(true)
        {
            foreach(Character character in charalist)
            {
                foreach(IDamageable entity in entitylist)
                {
                    if(entity.HP <= 0) continue;
                    character.Attack(entity);
                    
                }
                if (character.HP <= 0) break;
                
            }
            if (entitylist.All(e => e.HP <= 0)) break;
            if (charalist.All(e => e.HP <= 0))
            {
                Console.WriteLine("全滅しました");
                break;
            }
            
        }
        
    }
}

class Material : IDamageable
{
    public String Name{set; get;}
    public int HP{set; get;}
    public Material(string name, int hp)
    {
        Name = name;
        HP = hp;
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Console.WriteLine($"{Name}は壊れた!");
        }
        else Console.WriteLine($"{Name}は{damage}ダメージを受けた！");
        
    }
}
class Character : IDamageable
{
    public string Name {get; set;}
    public int HP{set; get;}
    public int AttackPower;
    public Character(string name, int hp, int Ap)
    {
        Name = name;
        HP = hp;
        AttackPower = Ap;
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            Console.WriteLine(Name+"　は倒れた！");
        }
    }
    public virtual void Attack(IDamageable target)
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
    
    public override void Attack(IDamageable target)
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
    
    public override void Attack(IDamageable target)
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

interface IDamageable
{
    string Name{get;}
    int HP{get;}
    void TakeDamage(int damage);
}