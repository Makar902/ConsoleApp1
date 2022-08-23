using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Разработать архитектуру классов иерархии товаров
//при разработке системы управления потоками товаров для
//дистрибьюторской компании. Прописать члены классов.
//Создать диаграммы взаимоотношений классов.
//Должны быть предусмотрены разные типы товаров,
//в том числе:
//• бытовая химия;
//• продукты питания.
//Предусмотреть классы управления потоком товаров
//(пришло, реализовано, списано, передано).
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            dynamic[] list=new dynamic[4];
            list[0]="Apple";
            list[1]="Juice";
            list[2]="Domestos";
            list[3]="Soup";

            dynamic[] arr=new dynamic[list.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]=random.Next(1, 50);
            }
            int ind = 3;
            Console.WriteLine("-----------------------");

            Product test0 = new InStock(list,arr);
            test0.Print();

            Console.WriteLine("-----------------------");

            test0.ChStock(ind);
            test0.Print();

            Console.WriteLine("-----------------------");

            Product test1 = new PriceList(list, arr);
            test1.prList=test0.prList;
            test1.stock=test0.stock;

            ind=2;
            test1.ChList(ind);
            test1.Print();

            Console.WriteLine("-----------------------");

            Product test2 = new Cos(list, arr);

            test2.prList=test1.prList;
            test2.stock=test1.stock;
            //test2.cost=test1.cost;

            ind=1;
            test2.Chcost(ind);
            test2.Print();

            Console.WriteLine("-----------------------");

        }
    }
    public  class Product
    {

        public dynamic[] prList;
        public dynamic[] cost;
        public string[] stock;//Пользовательский статус предмета (пришло, реализовано, списано, передано).
        public Product(dynamic[] tmp,dynamic[] arr)
        {
            this.prList = tmp;
            this.cost=arr;
            stock=new string[prList.Length];
            for(int i = 0; i < prList.Length; i++)
            {
                stock[i]="true";
            }
        }
        public void Print()
        {
            for(int i=0;i<prList.Length; i++)
            {
                Console.Write(prList[i]);
                Console.Write(" cost: ");
                Console.Write(cost[i]);
                Console.Write(" in stock: ");
                Console.WriteLine(stock[i]);
            }
        }
        public virtual dynamic ChStock(int index)
        {
            return index;
        }
        public virtual dynamic ChList(int index)
        {
            return null;
        }
        public virtual dynamic Chcost(int index)
        {
            return null;
        }
    }
    public class InStock : Product
    {
        public InStock(dynamic[] tmp, dynamic[] arr) : base(tmp, arr)
        {

        }

        public override dynamic ChStock(int index = 0)
        {
            //Console.WriteLine("Enter new value:");
            stock[index]="in delivery"/*Console.ReadLine()*/;
            return index;
        }
    }
    public class PriceList : Product
    {
        public PriceList(dynamic[] tmp, dynamic[] arr) : base(tmp, arr)
        {
        }

        public override dynamic ChList(int index = 1)
        {
            //Console.WriteLine("Enter Value: ");
            prList[index]="Plum"/*Console.ReadLine()*/;
            return index;
        }
    }
    public class Cos : Product
    {
        public Cos(dynamic[] tmp, dynamic[] arr) : base(tmp, arr)
        {
        }
        public override dynamic Chcost(int index = 1)
        {
            //Console.WriteLine("Enter Value: ");
            dynamic val = 99999/*Console.ReadLine()*/;
            cost[index]=val;
            return index;
        }
    }
}

