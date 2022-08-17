using Yields.Werner;
using System.Management;
using Yields.indexators;
using Yields.MachineLearning;
using FirebirdSql.Data.FirebirdClient;
using System.Reflection;

namespace Yields
{
    public class Program : IComparable
    {
        public static void Main()
        {
            //    ScriptEngine engine = Python.CreateEngine();
            //    engine.ExecuteFile(@"C:\Users\intern\source\repos\Yields\Yields\PythonRuby\test.py");


            //не смог разобраться как запустить ruby
            //var ghbd = Ruby.CreateRubySetup();
            ////ghbd.InterpretedMode = true;
            //var runtime = Ruby.CreateRuntime();
            //Console.SetOut(runtime.IO.OutputWriter);
            //runtime.ExecuteFile(@"C:\Users\intern\source\repos\Yields\Yields\PythonRuby\testRuby.rb");


            MachineLearning.Class1.QuestionEvent = () => Console.ReadLine(); // передавать метод для возврата ответа к вопросу ассистента (return текст из распознанного текста)
            MachineLearning.Class1.AnswerEvent = (mess) => Console.WriteLine(mess); // передавать метод для отображения ответа ассистента (голосовой ответ)
            var handle = new MachineLearning.Class1(Console.ReadLine());
            handle.Handling();

            //var class1 = new Doctor(true);
            //class1.Name = "Name";
            //class1.Surname = "Surname";
            //class1.Fathername = "Fathername";
            //var a = class1.GetType();
            //var props = a.GetProperties();
            //var meths = a.GetMethods(BindingFlags.Instance |
            //BindingFlags.Public |
            //BindingFlags.NonPublic);
            //Console.WriteLine("Свойства: ");
            //foreach (var item in props)
            //{
            //    Console.WriteLine($"  {item.PropertyType.Name} {item.Name}");
            //    Console.WriteLine($"  {item}");
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

            //Dictionary dictionary = new Dictionary();
            //Console.WriteLine(dictionary["red"]);
            //dictionary["red"] = "Темно-красный";
            //Console.WriteLine(dictionary["red"]);

            //GenericArray<Dictionary> genericArray = new GenericArray<Dictionary>(new List<Dictionary>() {dictionary});
            //for (int i = 0; i < genericArray.GetLength(); i++)
            //{
            //    var ite = genericArray[i];
            //    Console.WriteLine(ite);
            //    int a = ite.GetLength();
            //    for (int j = 0; j < a; j++)
            //    {
            //        Console.WriteLine("\t" + ite[j]);
            //    }
            //}
            //Console.WriteLine(2);
            //genericArray.AddToArr(new Dictionary());
            //for (int i = 0; i < genericArray.GetLength(); i++)
            //{
            //    var item = genericArray[i];
            //    Console.WriteLine(item);
            //    for (int j = 0; j < item.GetLength(); j++)
            //    {
            //        Console.WriteLine("\t" + item[j]);
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
            PersonalDela[]? mark = new PersonalDela[n];
            for (int i = 0; i < n; i++)
            {
                string[]? str1 = new string[4];
                for (int j = 0; j < 4; j++)
                {
                    string? str = Console.ReadLine();
                    str1[j] = str;
                }
                PersonalDela? marks = new(str1[0], str1[1], str1[2], str1[3]);
                mark[i] = marks;
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n-1; j++)
                {
                    if (mark[j].CompareTo(mark[j+1]) > 0)
                    {
                        (mark[j], mark[j+1]) = (mark[j+1], mark[j]);
                    }
                }
            }

            //Sort<PersonalDela[]>(mark);

            foreach (var item in mark)
            {
                Console.WriteLine(item);
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
                Marks? marks = new(str1[1], str1[0], int.Parse(str1[3]), int.Parse(str1[4]), int.Parse(str1[2]));
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
            string[]? str1 = str.Split(' ');
            int? count = 0;

            for (int i = 0; i < n; i++)
            {
                bool state = false;
                for (int j = i+1; j < n; j++)
                {
                    if (str[i] == str[j])
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
                string[]? str1 = str.Split(' ');
                srMath += Convert.ToDouble(str1[2]);
                srPhys += Convert.ToDouble(str1[3]);
                srInform += Convert.ToDouble(str1[4]);
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
                string[]? str1 = str.Split(' ');
                if(str1[2] == "5" || str1[2] == "4")
                    if(str1[3] == "5" || str1[3] == "4")
                        if(str1[4] == "5" || str1[4] == "4")
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
                string[]? str1 = str.Split(' ');
                Marks? marks = new Marks(str1[1], str1[0], int.Parse(str1[3]), int.Parse(str1[4]), int.Parse(str1[2]));
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
            ManagementObjectSearcher? searcher8 =
                new ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_Processor");

            foreach (ManagementObject queryObj in searcher8.Get())
            {
                Console.WriteLine("------------- Win32_Processor instance ---------------");
                Console.WriteLine("Name: {0}", queryObj["Name"]);
                Console.WriteLine("NumberOfCores: {0}", queryObj["NumberOfCores"]);
                Console.WriteLine("ProcessorId: {0}", queryObj["ProcessorId"]);
            }
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
                    foreach (var simvol in str1)
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

                    foreach (var ch in line)
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
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CatModel? qq = new CatModel();
                                try
                                {
                                    //var values = new object[reader.FieldCount];
                                    //reader.GetValues(values);
                                    qq.Id = long.Parse(reader.GetValue(0)?.ToString() ?? "0");
                                    qq.IdRegPat = long.Parse(reader?.GetValue(1)?.ToString() ?? "0");
                                    if (qq.IdRegPat == 515457024)
                                    {

                                    }
                                    qq.DtBegin = reader?.GetValue(2)?.ToString();
                                    qq.DtEnd = reader?.GetValue(3)?.ToString();
                                    qq.DateGroup = long.Parse(reader?.GetString(4) ?? "0");
                                    qq.Diagnoz = reader?.GetValue(5)?.ToString();
                                    qq.DiagGroup = long.Parse(reader?.GetValue(6)?.ToString() ?? "0");
                                    qq.ServCod = long.Parse(reader?.GetValue(7)?.ToString() ?? "0");
                                    qq.ServCount = long.Parse(reader?.GetValue(8)?.ToString() ?? "0");
                                    qq.ClassCod = long.Parse(reader?.GetValue(9)?.ToString() ?? "0");
                                    qq.Num = long.Parse(reader?.GetValue(10)?.ToString() ?? "0");
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message);
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
}