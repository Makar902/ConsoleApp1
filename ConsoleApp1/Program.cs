using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Разработать абстрактный класс «Геометрическая Фигура» с методами «Площадь Фигуры» и «Периметр Фигуры».
//Разработать классы-наследники: Треугольник, Квадрат,
//Ромб, Прямоугольник, Параллелограмм, Трапеция, Круг,
//Эллипс.Реализовать конструкторы, которые однозначно
//определяют объекты данных классов.
//Реализовать класс «Составная Фигура», который
//может состоять из любого количества «Геометрических
//Фигур». Для данного класса определить метод нахождения
//площади фигуры. Создать диаграмму взаимоотношений
//классов.
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                Console.WriteLine("Trian: ");
                Trian test0 = new Trian(3, 2, 3);
                Console.Write("S = ");
                Console.WriteLine(test0.S);
                Console.Write("P = ");
                Console.WriteLine(test0.P);

                Console.WriteLine("Squ: ");
                Squ test1 = new Squ(56, 1, 6, 10);
                Console.Write("S = ");
                Console.WriteLine(test1.S);
                Console.Write("P = ");
                Console.WriteLine(test1.P);

                Console.WriteLine("Ro: ");
                Ro test2 = new Ro(56, 10);
                Console.Write("S = ");
                Console.WriteLine(test2.S);
                Console.Write("P = ");
                Console.WriteLine(test2.P);

                Console.WriteLine("Priam: ");
                Priam test3 = new Priam(5, 10);
                Console.Write("S = ");
                Console.WriteLine(test3.S);
                Console.Write("P = ");
                Console.WriteLine(test3.P);

                Console.WriteLine("Par: ");
                Par test4 = new Par(5, 14, 8);
                Console.Write("S = ");
                Console.WriteLine(test4.S);
                Console.Write("P = ");
                Console.WriteLine(test4.P);

                Console.WriteLine("Trap: ");
                Trap test5 = new Trap(5, 5, 5);
                Console.Write("S = ");
                Console.WriteLine(test5.S);
                Console.Write("P = ");
                Console.WriteLine(test5.P);

                Console.WriteLine("Kr: ");
                Kr test6 = new Kr(5);
                Console.Write("S = ");
                Console.WriteLine(test6.S);
                Console.Write("P = ");
                Console.WriteLine(test6.P);

                Console.WriteLine("Eli: ");
                Eli test7 = new Eli(5, 5);
                Console.Write("S = ");
                Console.WriteLine(test7.S);
                Console.Write("P = ");
                Console.WriteLine(test7.P);

            //Console.WriteLine("Enter len: ");
            dynamic len/* = int.Parse(Console.ReadLine())*/;
            //при пользовательском вводе можно хранить сколько угодно фигур
            len=8;
            GeomFig[] temp=new GeomFig[len];
            temp[0]=new Trian(3,2,3);
            temp[1]=new Squ(0, 0, 0, 0);
            temp[2]=new Ro(0, 0 );
            temp[3]=new Priam(0, 0);
            temp[4]=new Par(0, 0, 0);
            temp[5]=new Trap(0, 0, 0);
            temp[6]=new Kr(0);
            temp[7]=new Eli(0, 0);
            ComFig tmp = new ComFig(temp);
            Console.WriteLine("-------------------------------------------------------");
            tmp.AllSfind();
            tmp.OneSFind();
        }
    }
    public class ComFig
    {
        public GeomFig[] arr;
        dynamic S = 0;
        public ComFig(GeomFig[] arr)
        {
            this.arr=arr;
        }
        public dynamic AllSfind()
        {
            //Я немного не понял задание
            //это функция для поиска S всех фигур вместе взятых
            for (int i = 0; i<arr.Length; i++)
            {
                S+=arr[i].Sfig();
            }
            Console.Write("S = ");
            Console.WriteLine(S);
            return S;
        }
        //А здесь для поиска конкретной S 
        public dynamic OneSFind()
        {
            //индекс по какому бедет определяться какой фигуры S надо найти
            //Console.WriteLine("Enter index:");
            int ind;/*=int.Parse(Console.ReadLine());*/
            ind=2;
            dynamic S2 = 0;
            S2+=arr[5].Sfig();
            Console.Write("S = ");
            Console.WriteLine(S2);
            return S2;
        }
    }
    public abstract class GeomFig
    {
        public dynamic S = 0;
        public dynamic P = 0;
        public dynamic a = 0, b = 0, c = 0, d = 0, h = 0;
        public const double Pi = 3.141592653589793238462643d;
        public dynamic r = 0;

        public virtual dynamic Sfig()
        {
            return 0;
        }
        public virtual dynamic Pfig()
        {
            return a+b+c+d;
        }
    }
    public class Trian : GeomFig
    {
        public Trian(dynamic a, dynamic b, dynamic c)
        {
            this.a=a;
            this.b=b;
            this.c=c;
            this.S=Sfig();
            this.P=Pfig();
        }
        public override dynamic Sfig()
        {
            return Math.Sqrt(((a+b+c)/2)*(((a+b+c)/2)-a)*(((a+b+c)/2)-b)*(((a+b+c)/2)-c));
        }
        public override dynamic Pfig()
        {
            return base.Pfig();
        }
    }
    public class Squ : GeomFig
    {
        public Squ(dynamic a, dynamic b, dynamic c, dynamic d)
        {
            this.a=a;
            this.b=b;
            this.c=c;
            this.d=d;
            this.S=Sfig();
            this.P=Pfig();
        }
        public override dynamic Sfig()
        {
            return Math.Pow(a, 2);
        }
        public override dynamic Pfig()
        {
            return a+b+c+d;
        }
    }
    public class Ro : GeomFig
    {
        public Ro(dynamic a, dynamic h)
        {
            this.a=a;
            this.b=a;
            this.c=a;
            this.d=a;
            this.h=h;
            this.S=Sfig();
            this.P=Pfig();
        }
        public override dynamic Sfig()
        {
            return a*h;
        }
        public override dynamic Pfig()
        {
            return base.Pfig();
        }
    }
    public class Priam : GeomFig
    {
        public Priam(dynamic a, dynamic b)
        {
            this.a= a;
            this.b=b;
            this.c=b;
            this.d=a;
            this.S=Sfig();
            this.P=Pfig();
        }
        public override dynamic Sfig()
        {
            return a*b;
        }
        public override dynamic Pfig()
        {
            return base.Pfig();
        }
    }
    public class Par : GeomFig
    {
        public Par(dynamic a, dynamic b, dynamic h)
        {
            this.a=a;
            this.b=b;
            this.c=a;
            this.d=b;
            this.h=h;
            this.S=Sfig();
            this.P=Pfig();
        }
        public override dynamic Sfig()
        {
            return a*h;
        }
        public override dynamic Pfig()
        {
            return a+b+c+d;
        }
    }
    public class Trap : GeomFig
    {
        public Trap(dynamic a, dynamic b, dynamic h)
        {
            this.a=a;
            this.b=b;
            this.c=a;
            this.d=b;
            this.h=h;
            this.S=Sfig();
            this.P=Pfig();
        }
        public override dynamic Sfig()
        {
            //return ((a+b)/2)*Math.Sqrt(Math.Pow(a,2)-Math.Pow(((Math.Pow((b-a), 2)+Math.Pow(c, 2)-Math.Pow(d, 2))/(2*(b-a))),2));
            return ((a+b)/2)*h;
        }
        public override dynamic Pfig()
        {
            return a+b+c+d;
        }
    }
    public class Kr : GeomFig
    {
        public Kr(dynamic r)
        {
            this.r=r;
            this.S=Sfig();
            this.P=Pfig();
        }
        public override dynamic Sfig()
        {
            return Pi*Math.Pow(r, 2);
        }
        public override dynamic Pfig()
        {
            return 2*Pi*r;
        }
    }
    public class Eli : GeomFig
    {
        public Eli(dynamic a, dynamic b)
        {
            this.a=a;
            this.b=b;
            this.S=Sfig();
            this.P=Pfig();
        }
        public override dynamic Sfig()
        {
            return Pi*a*b;
        }
        public override dynamic Pfig()
        {
            return 4*((Pi*a*b+(a-b))/(a+b));
        }
    }
}
