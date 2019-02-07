using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson24
{
    class Program
    {
        // Домашнее задание
        // В вашей предметной области создать анонимный метод и 
        // аналогичное лямбда выражение.

        // Использовать делегат, обработчик события и изменять 
        // логику метода путем передачи в качестве аргумента делегата.

        public delegate int MyHandler(int i);
        static void Main(string[] args)
        {
            var lesson = new Lesson("Программирование C#");

            lesson.Started += (sender, date) =>
            {
                Console.WriteLine(sender);
                Console.WriteLine(date);
            };

            lesson.Start();

            var list = new List<int>();
            for(int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            var res = list.Aggregate((x, y) => x + y);
            Console.WriteLine(res);

            var result1 = Agr(list, delegate (int i)
            {
                var r = i * i;
                Console.WriteLine(r);
                return r;
            });

            var result2 = Agr(list, Method);

            var result3 = Agr(list, x => x * x * x * x);

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                MyHandler handler = delegate (int i)
                {
                    var r = i * i;
                    Console.WriteLine(r);
                    return r;
                };

                //handler += Method;

                handler(result);
                handler(88);


                MyHandler lambdaHandler = (i) => //i * i;
                {
                    var r = i * i;
                    Console.WriteLine(r);
                    return r;
                };

                lambdaHandler(99);
            }

            Console.ReadLine();
            Method(88);
        }

        public static int Agr(List<int> list, MyHandler handler)
        {
            int result = 0;

            foreach(var item in list)
            {
                result += handler(item);
            }

            return result;
        }

        public static int Method(int i)
        {
            var r = i * i * i;
            Console.WriteLine(r);
            return r;
        }
    }
}
