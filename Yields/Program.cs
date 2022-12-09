#define MYTEST
using Yields.Werner;
using System.Management;
using Yields.indexators;
using Yields.MachineLearning;
using FirebirdSql.Data.FirebirdClient;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Numerics;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace Yields
{
    delegate void TreeVisitor<T>(T nodeData);

    class NTree<T>
    {
        private T data;
        private LinkedList<NTree<T>> children;

        public NTree(T data)
        {
            this.data = data;
            children = new LinkedList<NTree<T>>();
        }

        public void AddChild(T data)
        {
            children.AddFirst(new NTree<T>(data));
        }

        public NTree<T>? GetChild(int i)
        {
            foreach (NTree<T> n in children)
                if (--i == 0)
                    return n;
            return null;
        }

        public void Traverse(NTree<T> node, TreeVisitor<T> visitor)
        {
            visitor(node.data);
            foreach (NTree<T> kid in node.children)
                Traverse(kid, visitor);
            Console.WriteLine();
        }
    }

    public class Program
    {
        private static async Task Random(int a) // асинхронно
        {
            await Task.Run(() => Console.WriteLine(a));
        }

        private static Task Th() // не асинхронно
        {
            object locker = new object();
            lock (locker)
            {
                return Task.Run(() => Thread.Sleep(1000));
            };
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static async Task Main()
        {
            //int abba = new A() + new A() + new A() * "abc";

            //var aaa = new A();
            //aaa.Number = 1;


            //string str = Console.ReadLine();
            //Console.WriteLine(Decode(str));
            //return;

            //if (3 == FirstOrDefault(new[] { 1, 2, 3 }, x => x > 2))
            //{
            //    foreach (var item in Take(new[] { 5 }, 0))
            //    {
            //        Console.WriteLine("YES\n" + item);
            //    }
            //}
            //else
            //    Console.WriteLine("NO\n" + FirstOrDefault(new int[0], x => true));
            ////Assert.AreEqual(0, FirstOrDefault(new int[0], x => true)); // default(int) == 0
            ////Assert.AreEqual(null, FirstOrDefault(new string[0], x => true)); // default(string) == null
            ////Assert.AreEqual(3, FirstOrDefault(new[] { 1, 2, 3 }, x => x > 2));
            ////Assert.AreEqual(3, FirstOrDefault(new[] { 3, 2, 1 }, x => x > 2));
            ////Assert.AreEqual(3, FirstOrDefault(new[] { 2, 3, 1 }, x => x > 2));
            ////CheckYieldReturn();

            //Console.WriteLine("OK");
            //return;



            //var ints = new[] { 1, 2 };
            //var strings = new[] { "A", "B" };

            //Print(Combine(ints, ints));
            //Print(Combine(ints, ints, ints));
            //Print(Combine(ints));
            //Print(Combine());
            //Print(Combine(strings, strings));
            //Print(Combine(ints, strings));

            //return;


            //await Random(2);
            //await Random(50);
            //await Th();
            //await Random(50);
            //await Random(2);


            // while (true)
            //    Console.WriteLine($"{Console.ReadLine().Length}\n");

            // Stepen();

            //MachineLearning.Class1.QuestionEvent = () => Console.ReadLine(); // передавать метод для возврата ответа к вопросу ассистента (return текст из распознанного текста)
            //MachineLearning.Class1.AnswerEvent = (mess) => Console.WriteLine(mess); // передавать метод для отображения ответа ассистента (голосовой ответ)
            //var handle = new MachineLearning.Class1(Console.ReadLine());
            //handle.Handling();

            Human.WeaponChange += (mes) => Console.WriteLine(mes);
            Human.HpChange += (mes) => Console.WriteLine(mes);
            Human.HumanDead += (mes) => Console.WriteLine(mes);

            IHumanable human = new Human("Human1");

            IHumanable human1 = new Human("Human2");

            Console.WriteLine($"Здоровье Human1 = {human.Hp}");
            Console.WriteLine($"Здоровье Human2 = {human1.Hp}");
            var weapon = new Kinjal(20);

            while (true)
            {
                var key = Console.ReadKey().Key;
                Console.WriteLine("");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                if (key == ConsoleKey.Escape)
                    break;
                else if(key == ConsoleKey.G)
                {
                    human.ThrowWeapon();
                }
                else if(key == ConsoleKey.E)
                {
                    human.PullWeapon<Kinjal>(weapon);
                }
                else if(key == ConsoleKey.R)
                {
                    human.Hit(human1);
                }
                else if(key == ConsoleKey.Q)
                {
                    human1.Eat(new Orange(20)); // специально кушает только второй чел, так как только у него уменьшается хп 
                }
                //human.Weapon?.Kinut(human, human1);
                //human1.PullWeapon(weapon);
                //human1.Hit(human);
                ////human.Hit(human1);
                //human.Hit(human1);
                //Dubin dubin = new Dubin(5);
                //human.PullWeapon(dubin);
            }

            Console.WriteLine($"rЗдоровье Human1 = {human.Hp}");
            Console.WriteLine($"Здоровье Human2 = {human1.Hp}");

            #if RELEASE
                Console.WriteLine("RELEASE"); 
            #elif DEBUG
                Console.WriteLine("DEBUG");
            #endif
 
            WebProxy myProxy = new WebProxy("proxy.akbarsmed.ru", 8080);
            myProxy.BypassProxyOnLocal = false;
            HttpClient.DefaultProxy = myProxy;
            HttpListener listener = new HttpListener();
            var uri = new Uri("");
            listener.Prefixes.Add("https://");
            listener.Prefixes.Add("api.openweathermap.org/data/2.5/weather?q=Kazan&units=metric&appid=fa88c9cdfdb5bff9bc0b42893067a148&lang=ru");
            //listener.Prefixes.Add("");
            //listener.Prefixes.Add("");
            //listener.Prefixes.Add("");
            listener.Start();
            var context = await listener.GetContextAsync();
            string ab = "1";
            string ba = "2";
            Weather? weather = new Weather();

            var url = $"https://api.openweathermap.org/data/2.5/weather?q=Kazan&units=metric&appid=fa88c9cdfdb5bff9bc0b42893067a148&lang=ru";
            Console.WriteLine(ab + " " + ba);
            (ab, ba) = (ba, ab);
            Console.WriteLine(ab + " " + ba);
            HttpClient client = new HttpClient();
            var a = await client.GetStringAsync(url);
            var translatedText = JsonConvert.DeserializeObject<Rootobject>(a);
            Console.WriteLine(translatedText?.Main?.temp + " C ");
            weather = translatedText?.Weather?[0];

            var aa = client.Send(new HttpRequestMessage(HttpMethod.Post, url));
            var dd = await aa.Content.ReadAsStringAsync();

            Console.WriteLine(JsonConvert.DeserializeObject<Rootobject>(dd)?.Main?.temp);
            HttpClient newClient = new HttpClient();
            #region // rubbish
            Console.WriteLine("");
            HttpContent content = aa.Content;
            ContextCallback contextCallback = new ContextCallback((a) => { });
            #endregion

            //ITransport transport = new Car();
            //transport.ToplivoChanged += (mess) => Console.WriteLine(mess);
            //transport.Start();
            //transport.SetToplivo(new Benz92(-83));
            //transport.Move();
            //transport.Stop();
            //transport.Jump();
            //transport.SetToplivo(new Benz92(13));
            //transport = new Moto();
            //transport.ToplivoChanged += (mess) => Console.WriteLine(mess);
            //transport.Start();
            //transport.Move();
            //transport.Jump();
            //transport.BeforeUp();
            //transport.Stop();
            //transport.SetToplivo(new Benz92(30));
            //IFlyable flyTransport = new Flyer();
            //flyTransport.Start();
            //flyTransport.Fly();
            //flyTransport.Katapult();
            //flyTransport.Stop();
            //ISwimable swimTransport = new Swimmer();
            //swimTransport.Start();
            //swimTransport.Swim();
            //swimTransport.Shvartovat();
            //swimTransport.Stop();

            //NTree<int> tree = new NTree<int>(3);
            //tree.AddChild(1);
            //tree.AddChild(2);
            ////tree.AddChild(3);
            //var b = tree.GetChild(1);
            //b.AddChild(5);
            //b = tree.GetChild(2);
            //b.AddChild(5);
            //b.AddChild(5);
            //b.Traverse(b, Console.WriteLine);
            //Console.WriteLine();
            //tree.Traverse(tree, Console.WriteLine);

            //b = tree.GetChild(1);
            //int count = 0;
            //while(b != null)
            //{
            //    if (b == null)
            //        break;
            //    b.Traverse(b, Console.WriteLine);
            //    Console.WriteLine("\n\n\n\n");
            //    b = b.GetChild(count);
            //    count++;
            //}


            //Console.WriteLine("\n\n");
            //IHumanable human2 = new Human();
            //human2.HumanDead += (mess) => Console.WriteLine(mess);
            //human2.HpChange += (mess) => Console.WriteLine(mess);
            //human2.Move();
            //human2.Jump();
            //human2.Eat(new Meat(20));
            //human2.Eat(new Orange(10));
            //human2.Living();

            //Console.WriteLine();
            //IHumanable human = new Human();
            //human.HumanDead += (mess) => Console.WriteLine(mess);
            //human.HpChange += (mess) => Console.WriteLine(mess);
            //human.Move();
            //human.Hit(human2);
            //human.Jump();
            //human.Eat(new Meat(20));
            //human.Eat(new Orange(10));
            //human.Living();

            //Console.WriteLine("\n\n");
            //IHumanable human2 = new Human();
            //human2.HumanDead += (mess) => Console.WriteLine(mess);
            //human2.HpChange += (mess) => Console.WriteLine(mess);
            //human2.Move();
            //human2.Jump();
            //human2.Eat(new Meat(20));
            //human2.Eat(new Orange(10));
            //human2.Living();

            //Matrix<int> matrix = new Matrix<int>(3,4);
            //for (int i = 0; i < matrix.RowCount; i++)
            //{
            //    string a = Console.ReadLine();
            //    string[] str = a.Split(' ');
            //    for (int j = 0; j < matrix.ColumnCount; j++)
            //    {
            //        matrix[i, j] = int.Parse(str[j]);
            //    }
            //}
            //Console.WriteLine();
            //matrix.GetMatrix();
            //Console.WriteLine();
            //Console.WriteLine(matrix[1, 2]);



            //ScriptEngine engine = Python.CreateEngine();
            //engine.ExecuteFile(@"C:\Users\intern\source\repos\Yields\Yields\PythonRuby\test.py");


            // не смог разобраться как запустить ruby
            //var runtime = Ruby.CreateRuntime();
            //runtime.ExecuteFile(@"C:\Users\intern\source\repos\Yields\Yields\PythonRuby\testRuby.rb");


            //var class1 = new Doctor(true);
            //var a = class1.GetType();
            //var props = a.GetProperties();
            //var meths = a.GetMethods();
            //Console.WriteLine("Свойства: ");
            //foreach (var item in props)
            //{
            //    Console.WriteLine($"  {item.PropertyType.Name} {item.Name}");
            //}
            //Console.WriteLine("Методы: ");
            //foreach (var item in meths)
            //{
            //    var d = item.ReflectedType.Assembly.GetFiles();
            //    Console.Write($"  {d[0].Name} {item.Name} {item.ReturnType.Name} (");
            //    var parms = item.GetParameters();
            //    for (int i = 0; i < parms.Length; i++)
            //    {
            //        Console.Write(parms[i].Name);
            //        if(i != parms.Length-1)
            //            Console.Write(", ");
            //    };
            //    Console.Write(")\n");
            //}
            //var tuple = a.GetConstructors();
            //Console.WriteLine("Конструкторы: ");
            //foreach (var item in tuple)
            //{
            //    Console.WriteLine($"  {item}");
            //
            //}
            //Console.WriteLine(meths[0].Invoke(class1, parameters: null));
            //Console.WriteLine(meths[2].Invoke(class1, parameters: null));
            //Console.WriteLine(meths[4].Invoke(class1, parameters: null));



            //FootballTeam footballTeam = new FootballTeam("Star", new Footballist[11]);

            //try
            //{
            //    for (int i = 0; i < 11; i++)
            //    {
            //        footballTeam[i] = new Footballist($"Player{i + 1}", new Random().Next(i, 20));
            //    }

            //    for (int i = 0; i < 15; i++)
            //    {
            //        Console.WriteLine(footballTeam[i]);
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            //var words = new Word<string, string>[3] { new Word<string, string>("red", "красный"), new Word<string, string>("blue", "синий"), new Word<string, string>("green", "зеленый") };
            //var words2 = new Word<string, string>[3] { new Word<string, string>("red", "красный"), new Word<string, string>("blue", "синий"), new Word<string, string>("green", "зеленый") };
            //var dictionary = new indexators.Dictionary<string, string>(words);
            //Console.WriteLine(dictionary["red"]);
            //dictionary["red"] = "Темно-красный";
            //Console.WriteLine(dictionary["red"]);

            //foreach (var pair in dictionary)
            //{
            //    Console.WriteLine(pair);
            //}

            //var genericArray = new GenericArray<indexators.Dictionary<string, string>>(new List<indexators.Dictionary<string, string>>() { dictionary });
            //for (int i = 0; i < genericArray.GetLength(); i++)
            //{
            //    var ite = genericArray[i];
            //    Console.WriteLine(ite);
            //    int a = ite.GetLength();
            //    foreach (var item in ite)
            //    {
            //        Console.WriteLine("\t" + item);
            //    }
            //}

            //Console.WriteLine(2);
            //genericArray.AddToArr(new indexators.Dictionary<string, string>(words2));
            //for (int i = 0; i < genericArray.GetLength(); i++)
            //{
            //    var item = genericArray[i];
            //    Console.WriteLine(item);
            //    foreach (var it in item)
            //    {
            //        Console.WriteLine("\t" + it);
            //    }
            //}



            ////genericArray.DeleteArr(3);
            ////for (int i = 0; i < 6; i++)
            ////{
            ////    Console.WriteLine(genericArray[i]);
            ////}

            //ITransport transport = new Transport();
            //transport = new Flyer();
            //Console.WriteLine(transport.GetTime(500, 50) + "minutes");
            //IGo tr = new Car();
            //tr.Start();
            //tr.Remen();
            //tr.Go();
            //tr.Stop();
            //IFly sam = new Flyer();
            //sam.Start();
            //sam.Fly();
            //sam.Katapult();
            //sam.Stop();
            // Task.Run(() => Stepik2());
            // Stepik1();
            //Stepik7();

            // Prog1();
            //PersonalDela personalDela1 = new PersonalDela("Sidorov", "Sidor", "9A", "");
            //PersonalDela personalDela2 = new PersonalDela("Petrov", "Petr", "9A", "");
            //Console.WriteLine(personalDela1.CompareTo(personalDela2));


            //Console.ReadKey();
            //Console.WriteLine("HelloWorld");
            //CatService catService = new CatService();
            ////Stopwatch stopwatch = new Stopwatch();
            ////stopwatch.Start();
            //foreach (var item in catService)
            //{
            //    Console.WriteLine(item);
            //}
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.Elapsed);
            //Console.ReadKey();
        }


        static void Print(Array array)
        {
            if (array == null)
            {
                Console.WriteLine("null");
                return;
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array.GetValue(i));
            Console.WriteLine();
        }

        static Array Combine(params Array[] arr)
        {
            Type prevType = null;
            int length = 0;
            if (arr.Length == 0)
                return null;

            foreach (var item in arr)
            {
                var currentType = item.GetType().GetElementType();
                if (prevType == null)
                {
                    prevType = currentType;
                    length += item.Length;
                    continue;
                }

                if (currentType != prevType)
                {
                    return null;
                }

                length += item.Length;
                prevType = currentType;
            }


            Array array = Array.CreateInstance(prevType, length);
            int i = 0;
            foreach (var item in arr)
            {
                foreach (var item2 in item)
                {
                    array.SetValue(item2, i);
                    i++;
                }
            }

            return array;
        }

        private static T FirstOrDefault<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            T sourceItem = default(T);
            if (source == null || source.Count() == 0)
                return default(T);

            foreach (var item in source)
            {
                if (filter(item))
                {
                    return item;
                }
            }

            return sourceItem;
        }

        private static IEnumerable<T> Take<T>(IEnumerable<T> source, int count)
        {
            int i = 0;
            if (count > 0)
            {
                foreach (var item in source)
                {
                    yield return item;
                    if (i >= count - 1)
                        break;
                    i++;
                }
            }
            else
            {
                yield break;
            }
        }
        public static string Decode(string textWithWrongEncoding, Encoding rightEncoding = null, Encoding wrongEncoding = null)
        {
            rightEncoding = rightEncoding ?? Encoding.UTF8;
            wrongEncoding = wrongEncoding ?? Encoding.GetEncoding(437);
            return rightEncoding.GetString(wrongEncoding.GetBytes(textWithWrongEncoding));
        }

        public class A
        {
            private int number = 0;
            public int Number { get => number; set { Console.WriteLine("Hello, world!"); Number = value; } }
            public static A operator +(A counter1, A counter2)
            {
                return new A { Number = counter1.Number + counter2.Number };
            }
            public static A operator *(A counter1, string counter2)
            {
                return new A { Number = counter1.Number + int.Parse(counter2) };
            }

            public static implicit operator int(A counter)
            {
                return counter.Number;
            }
        }

        public static void Stepen()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            BigInteger big = BigInteger.Pow(new BigInteger(2), n);
            Console.WriteLine(big);

            string template = "1";
            //string result = "";

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < template.Length; i++)
                {
                    template = (Convert.ToInt64(template[i]) * 2).ToString();
                }
            }

            Console.WriteLine(template);
        }

        // та самая с учащимися
        private static void Stepik6()
        {
            // 3
            // ghb
            // fei
            // 9A
            // 27.03.12
            // gjie
            // gke
            // 10A
            // 29,
            // fkw
            // fw
            // 9B
            // 2032
            int n = Convert.ToInt32(Console.ReadLine());
            PersonalDela[] mark = new PersonalDela[n];
            for (int i = 0; i < n; i++)
            {
                string?[]? str1 = new string[4];
                for (int j = 0; j < 4; j++)
                {
                    string? str = Console.ReadLine();
                    str1[j] = str?.Trim();
                }

                PersonalDela marks = new(str1?[0], str1?[1], str1?[2], str1?[3]);
                mark[i] = marks;
            }
            System.Collections.IEnumerator afr = mark.GetEnumerator();
            while(true)
            {
                var d = afr;
                if (!d.MoveNext())
                    break;
                Console.WriteLine(afr?.Current);
            }

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n-1; j++)
                {
                    if (mark[j].CompareTo(mark[j + 1]) < 0)
                    {
                        (mark[j], mark[j + 1]) = (mark[j + 1], mark[j]);
                    }
                }
            }

            wf<PersonalDela> amgt = new wf<PersonalDela>();
            //amgt.Sort(amgt[], n);

            foreach (var item in mark)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\n\n{Math.Sign(2)}");
            Console.WriteLine($"{Math.Sign(0)}");
            Console.WriteLine($"{Math.Sign(-2)}");

            if(Math.Sign(0) == -1)
            {
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n-1; j++)
                    {
                        (mark[i], mark[j]) = (mark[j], mark[i]);
                        Console.WriteLine(mark[j].ToString());
                    }
                }
            }
        }

        public class wf<T> : IComparable
        {
            public int CompareTo(object? obj)
            {
                var a = (T?)obj;
                return this.Equals(obj).CompareTo(this.Equals(obj));
            }

            public void Sort(wf<T>[] mark, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n - 1; j++)
                    {
                        if (mark[i].CompareTo(mark[i + 1]) < 0)
                            (mark[j], mark[j + 1]) = (mark[j + 1], mark[j]);
                    }
                }
            }
        }

       

        // сортировка по убыванию среднего балла
        private static void Stepik1()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Marks[]? mark = new Marks[n];
            for(int i = 0; i < n; i++)
            {
                string? str = Console.ReadLine();
                string[]? str1 = str?.Split(' ');
                Marks? marks = new(str1?[1], str1?[0], int.Parse(str1[3]), int.Parse(str1[4]), int.Parse(str1[2]));
                mark[i] = marks;
            }

            for (int? j = 0; j < n; j++)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (mark[i].CompareTo(mark[i + 1]) < 0)
                    {
                        var temp = mark[i];
                        mark[i] = mark[i + 1];
                        mark[i + 1] = temp;
                    }
                }
            }

            foreach (var item in mark)
            {
                Console.WriteLine(item.Surname + " " + item.Name);
            }
        }

        public static void Stepik7()
        {
            int? n = Convert.ToInt32(Console.ReadLine());
            string? str = Console.ReadLine();
            string[]? str1 = str?.Split(' ');
            int? count = 0;

            for (int i = 0; i < n; i++)
            {
                bool state = false;
                for (int j = i+1; j < n; j++)
                {
                    if (str?[i] == str?[j])
                    {
                        state = true;
                        break;
                    }
                }

                count = state ? count : count++;
            }

            Console.WriteLine(count);
        }

        private static void Stepik3()
        {
            double n = Convert.ToDouble(Console.ReadLine());
            double srMath = 0.00, srPhys = 0.0, srInform = 0.0;

            for(int? i = 0; i < n; i++)
            {
                string? str = Console.ReadLine();
                string[]? str1 = str?.Split(' ');
                srMath += Convert.ToDouble(str1?[2]);
                srPhys += Convert.ToDouble(str1?[3]);
                srInform += Convert.ToDouble(str1?[4]);
                srPhys = Convert.ToDouble(srPhys.ToString());
            }

            if (srMath % n == 0)
                Console.Write($"{Math.Round(srMath / n, 15)}.0 ");
            else
                Console.Write($"{Math.Round(srMath / n, 15)} "); 
            if (srPhys % n == 0)
                Console.Write($"{Math.Round(srPhys / n, 15)}.0 ");
            else
                Console.Write($"{Math.Round(srPhys / n, 15)} ");
            if (srInform % n == 0)
                Console.Write($"{Math.Round(srInform / n, 15)}.0 ");
            else
                Console.Write($"{Math.Round(srInform / n, 15)} ");
        }

        private static void Stepik4()
        {
            int? n = Convert.ToInt32(Console.ReadLine());
            List<string>? names = new List<string>();
            for (int? i = 0; i < n; i++)
            {
                string? str = Console.ReadLine();
                string[]? str1 = str?.Split(' ');
                if(str1?[2] == "5" || str1?[2] == "4")
                    if(str1?[3] == "5" || str1?[3] == "4")
                        if(str1?[4] == "5" || str1?[4] == "4")
                            names.Add(str1[0] + " " + str1[1]);
            }

            foreach (var item in names)
                Console.WriteLine(item);
        }

        private static void Stepik5()
        {
            int? n = Convert.ToInt32(Console.ReadLine());
            List<Marks>? lst = new List<Marks>();
            List<Marks>? lst2 = new List<Marks>();
            List<Marks>? lst3 = new List<Marks>();
            for (int? i = 0; i < n; i++)
            {
                string? str = Console.ReadLine();
                string[]? str1 = str?.Split(' ');
                Marks? marks = new(str1?[1], str1?[0], int.Parse(str1[3]), int.Parse(str1[4]), int.Parse(str1[2]));
                lst.Add(marks);
                lst2.Add(marks);
            }

            for (int? j = 0; j < n; j++)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (lst[i].CompareTo(lst[i + 1]) < 0)
                    {
                        var temp = lst[i];
                        lst[i] = lst[i + 1];
                        lst[i + 1] = temp;
                    }
                }
            }
            Console.WriteLine();
            foreach (var i in lst)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            lst3.Add(lst[0]);
            lst3.Add(lst[1]);
            lst3.Add(lst[2]);
            for (int i = 3; i < lst.Count; i++)
            {
                if (lst[2].Srednay == lst[i].Srednay)
                    lst3.Add(lst[i]);
            }

            foreach (var item in lst2)
            {
                foreach (var i in lst3)
                {
                    if(item == i)
                        Console.WriteLine(item.Surname + " " + item.Name);
                }
            }
        }

        private static void Stepik2()
        {
#pragma warning disable CA1416 // Проверка совместимости платформы
            ManagementObjectSearcher? searcher8 =
                new ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_Processor");

            foreach (ManagementObject queryObj in searcher8.Get())
            {
                Console.WriteLine("------------- Win32_Processor instance ---------------");
                Console.WriteLine("Name: {0}", queryObj["Name"]);
                Console.WriteLine("NumberOfCores: {0}", queryObj?["NumberOfCores"]);
                Console.WriteLine("ProcessorId: {0}", queryObj?["ProcessorId"]);
            }
#pragma warning restore CA1416 // Проверка совместимости платформы
        }


        private static void Prog2()
        {

            // 110^&1010100110JKjdkdl;?.,lk1101101111Pk1kdfl1001011100111
            // 110^&1010100110JKjdkdl;?.,lk1101101111Pk1kdfl1001011100111
            // 110^&1010100110JKjdkdl;?.,lk1101101111Pk1kdfl1001011100111

            string? str = Console.ReadLine() + ' ';
            string? temp = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '4')
                {

                }
                if (Char.IsDigit(str[i]))
                    temp += str[i];
                else if (temp != "")
                {
                    Console.Write(Convert.ToString(int.Parse(temp), 2));
                    if (str[i] != ' ')
                        Console.Write(str[i]);
                    temp = "";
                }
                else
                    if (str[i] != ' ')
                    Console.Write(str[i]);
            }

            int? digitCount = 0, letterCount = 0, simvolCount = 0, spaceCount = 0;
            foreach (var simvol in str)
            {
                if (char.IsDigit(simvol)) digitCount++;
                else if (char.IsLetter(simvol)) letterCount++;
                else if (simvol == ' ') spaceCount++;
                else simvolCount++;
            }

            Console.WriteLine($"\n\nDigit Count: {digitCount}\nLetter Count: {letterCount}\nSimvol Count: {simvolCount}\nSpace count: {spaceCount}\nAll count: {str.Length}");

            using (StreamReader? reader = new(@"C:\Users\intern\Desktop\rew.txt"))
            {
                int? digitCount1 = 0, letterCount1 = 0, simvolCount1 = 0, spaceCount1 = 0, length = 0;
                while (!reader.EndOfStream)
                {
                    string? str1 = reader.ReadLine();
                    length += str1?.Length;
                    foreach (char simvol in str1)
                    {
                        if (Char.IsDigit(simvol))
                            digitCount1++;
                        else if (char.IsLetter(simvol))
                            letterCount1++;
                        else if (simvol == ' ')
                            spaceCount1++;
                        else
                            simvolCount1++;
                    }
                }

                Console.WriteLine($"\n\nDigit Count: {digitCount1}\nLetter Count: {letterCount1}\nSimvol Count: {simvolCount1}\nSpace count: {spaceCount1}\nAll count: {length}");
            }

            string? Name = "";
            using (FileStream? stream = new(@"C:\Users\intern\Desktop\rew1.txt", FileMode.OpenOrCreate)) Name = stream.Name;

            using (StreamWriter? writer = new StreamWriter(Name, true))
            {
                writer.Write("Hello, World!");
            }
            // 6 ^ &678JKjdkdl;?.,lk879Pk1kdfl4839
            // Console.WriteLine(res);
        }

        private static void Prog1()
        {
            string? path = @"C:\Users\intern\Downloads\data.txt";
            int? nolCount = 0;
            int? oneCount = 0;
            int? strCount = 0;

            using (StreamReader? sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();

                    foreach (char? ch in line)
                    {
                        if (ch == '0')
                        {
                            nolCount++;
                        }
                        else if (ch == '1')
                        {
                            oneCount++;
                        }
                    }

                    if (nolCount % 3 == 0 || oneCount % 2 == 0)
                    {
                        Console.WriteLine(strCount + "\t" + line);
                    }

                    nolCount = 0;
                    oneCount = 0;
                    strCount++;
                }
            }
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        public static void Main1()
        {
            // Save colors so they can be restored when use finishes input.
            ConsoleColor dftForeColor = Console.ForegroundColor;
            ConsoleColor dftBackColor = Console.BackgroundColor;
            bool continueFlag = true;
            Console.Clear();

            do
            {
                ConsoleColor newForeColor = ConsoleColor.White;
                ConsoleColor newBackColor = ConsoleColor.Black;

                Char foreColorSelection = GetKeyPress("Select Text Color (B for Blue, R for Red, Y for Yellow): ",
                                                     new Char[] { 'B', 'R', 'Y' });
                switch (foreColorSelection)
                {
                    case 'B':
                    case 'b':
                        newForeColor = ConsoleColor.DarkBlue;
                        break;
                    case 'R':
                    case 'r':
                        newForeColor = ConsoleColor.DarkRed;
                        break;
                    case 'Y':
                    case 'y':
                        newForeColor = ConsoleColor.DarkYellow;
                        break;
                }
                Char backColorSelection = GetKeyPress("Select Background Color (W for White, G for Green, M for Magenta): ",
                                                     new Char[] { 'W', 'G', 'M' });
                switch (backColorSelection)
                {
                    case 'W':
                    case 'w':
                        newBackColor = ConsoleColor.White;
                        break;
                    case 'G':
                    case 'g':
                        newBackColor = ConsoleColor.Green;
                        break;
                    case 'M':
                    case 'm':
                        newBackColor = ConsoleColor.Magenta;
                        break;
                }

                Console.WriteLine();
                Console.Write("Enter a message to display: ");
                String textToDisplay = Console.ReadLine() ?? "";
                Console.WriteLine();
                Console.ForegroundColor = newForeColor;
                Console.BackgroundColor = newBackColor;
                Console.WriteLine(textToDisplay);
                Console.WriteLine();
                if (Char.ToUpper(GetKeyPress("Display another message (Y/N): ", new Char[] { 'Y', 'N' })) == 'N')
                    continueFlag = false;

                // Restore the default settings and clear the screen.
                Console.ForegroundColor = dftForeColor;
                Console.BackgroundColor = dftBackColor;
                Console.Clear();
            } while (continueFlag);
        }

        private static Char GetKeyPress(String msg, Char[] validChars)
        {
            ConsoleKeyInfo keyPressed;
            bool valid = false;

            Console.WriteLine();
            do
            {
                Console.Write(msg);
                keyPressed = Console.ReadKey();
                Console.WriteLine();
                if (Array.Exists(validChars, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))
                    valid = true;
            } while (!valid);
            return keyPressed.KeyChar;
        }
    }

    public class CatModel
    {
        public long Id { get; set; }
        public long IdRegPat { get; set; }
        public string? DtBegin { get; set; }
        public string? DtEnd { get; set; }
        public long DateGroup { get; set; }
        public string? Diagnoz { get; set; }
        public long DiagGroup { get; set; }
        public long ServCod { get; set; }
        public long ServCount { get; set; }
        public long ClassCod { get; set; }
        public long Num { get; set; }

        public override string ToString()
        {
            return $"{IdRegPat}\t{DtBegin}\t{DtEnd}\t{Diagnoz}\t{ServCod}\t{ClassCod}\t{Num}\t{ServCount}\t{DiagGroup}\t{Id}";
        }

    }

    public class CatService
    {
        public static readonly string? connectionString = "database=dms:D:\\dms\\MEDICINA19042022.GDB;user=***;password=***";

        public IEnumerator<CatModel> GetEnumerator()
        {
            using (var connection = new FbConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = new FbCommand("select rp.id, rp.id_regpat, rp.dt_begin, rp.dt_end, rp.date_group, cast(rp.diagnoz as varchar(250) character set win1251), rp.daig_group, rp.serv_cod, rp.serv_count, rp.classcod, rp.num from regester_positions rp", connection, transaction))
                    {
                        using (FbDataReader? reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CatModel qq = new CatModel();
                                try
                                {
                                    //var values = new object[reader.FieldCount];
                                    //reader.GetValues(values);
                                    qq.Id = long.Parse(reader?.GetValue(0)?.ToString() ?? "0");
                                    qq.IdRegPat = long.Parse(reader?.GetValue(1)?.ToString() ?? "0");
                                    if (qq.IdRegPat == 515457024)
                                    {

                                    }
                                    qq.DtBegin = reader?.GetValue(2)?.ToString();
                                    qq.DtEnd = reader?.GetValue(3)?.ToString();
                                    qq.DateGroup = long.Parse(reader?.GetValue(4)?.ToString() ?? "0");
                                    qq.Diagnoz = reader?.GetValue(5)?.ToString();
                                    qq.DiagGroup = long.Parse(reader?.GetValue(6)?.ToString() ?? "0");
                                    qq.ServCod = long.Parse(reader?.GetValue(7)?.ToString() ?? "0");
                                    qq.ServCount = long.Parse(reader?.GetValue(8)?.ToString() ?? "0");
                                    qq.ClassCod = long.Parse(reader?.GetValue(9)?.ToString() ?? "0");
                                    qq.Num = long.Parse(reader?.GetValue(10)?.ToString() ?? "0");
                                }
                                catch
                                {
                                    //throw new Exception(ex.Message);
                                    //Events.Message?.Invoke($"RegesterPositions) {ex.Message} {qq.Id} {qq.IdRegPat} {qq.DateGroup} {qq.DiagGroup} {qq.ServCod} {qq.ServCount} {qq.ClassCod} {qq.Num}");
                                }
                                yield return qq;
                            }
                        }
                    }
                }
            }
        }
    }

    class Matrix<T>
    {
        public int RowCount = 0, ColumnCount = 0;
        public T[,] matrix;

        public Matrix(int a, int b)
        {
            RowCount = a;
            ColumnCount = b;
            matrix = new T[a, b];
        }

        public void GetMatrix()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        public T this[int index, int index2]
        {
            get
            {
                return matrix[index, index2];
            }
            set
            {
                matrix[index, index2] = value;
            }
        }
    }
}
//2640