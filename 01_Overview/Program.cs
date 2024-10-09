using System.Collections;
using System.Text;
using static System.Console;
namespace _01_Overview
{
    class Program
    {
        private const int ConstValue = 10;
        private static int _staticValue = 10;


        public delegate int AddDelegate(int a, int b);

        public static int Add(int a, int b)
        {
            var result = a + b;
            WriteLine($"Call from Add, result = {result}");
            return result;
        }

        public static int Add2(int a, int b)
        {
            var result = a * 2 + b;
            WriteLine($"Call from Add2, result = {result}");
            return result;
        }

        private static void Main(string[] args)
        {
            InputEncoding = OutputEncoding = Encoding.Unicode;

            #region Sample CLI
            WriteLine("".PadLeft(40, '*'));
            WriteLine("Sample CLI");
            int argsLength = args.Length;
            for (var i = 0; i < argsLength; i++)
            {
                switch (args[i])
                {
                    case "-h":
                        WriteLine("Show help 😎");
                        return; //don't input anyone :>

                    case "-i" when i + 1 < argsLength:
                        var inputDirectory = args[i + 1];
                        WriteLine($"Your input directory: {inputDirectory}");

                        //var innerDirs = Directory.GetDirectories(inputDirectory);

                        //if (innerDirs.Any())
                        //{
                        //    foreach (var innerDir in innerDirs)
                        //    {
                        //        Console.WriteLine(innerDir);
                        //    }
                        //}

                        break;
                    case "-o" when i + 1 < argsLength:
                        var outputDirectory = args[i + 1];

                        WriteLine($"Your output directory: {outputDirectory}");

                        lock (Out)
                        {
                            if (!Directory.Exists(outputDirectory))
                            {

                                ForegroundColor = ConsoleColor.Red;
                                WriteLine($"{outputDirectory} not exist!!!");
                                ResetColor();
                            }
                        }

                        break;
                }
            }
            #endregion

            #region Review Part 1

            WriteLine("".PadLeft(40, '*'));
            WriteLine("Review");

            WriteLine("Xin chào");

            int myVar = 0;
            WriteLine($"myvar = {myVar}");

            var student = new Student()
            {
                Id = 1,
                Name = "Test",
                Age = 21
            };

            WriteLine(student);

            WriteLine(ConstValue);
            //ConstValue += 10;


            WriteLine(_staticValue);

            _staticValue += 10;
            WriteLine(_staticValue);



            var doubleValue = 45.45;
            WriteLine($"Value = {doubleValue}");
            WriteLine($"(int)Value = {(int)(doubleValue)}");
            WriteLine($"(Ceiling)Value = {Math.Ceiling(doubleValue)}");
            WriteLine($"(Floor)Value = {Math.Floor(doubleValue)}");

            var x = Random.Shared.Next(0, 10000);


            WriteLine(x % 2 == 0 ? $"{x} is even number" : $"{x} is odd number");



            var breakPoint = Random.Shared.Next(0, 1000);
            var result = 0;
            for (var i = 1; i <= breakPoint; i++)
            {
                result += i;
            }

            WriteLine($"Sum 1..{breakPoint} = {result}");


            ShowLogStatic("Test log", ConsoleColor.Green);
            ShowLogStatic("Test log with default value");

            new Program().ShowLogNonStatic("Test log with non-static", ConsoleColor.Red);

            int refValue = 1;//Must declared
            ChangeRefValue(ref refValue);
            WriteLine($"ref value {refValue}");

            int outValue;
            ChangeOutValue(out outValue);
            WriteLine($"out value {outValue}");


            ChangeOutValue(out var outValueShort);
            WriteLine($"out value {outValueShort}");


            var arr = new[] { 1, 2, 3, 4, 5 };

            WriteLine(arr[1]);

            var cloneArr = arr[1..^1];// 1..n - 2

            WriteLine(string.Join(',', cloneArr));

            var list = arr.ToList();
            list.Add(6);

            foreach (var i1 in list)
            {
                Write($"{i1} ");
            }

            WriteLine();
            WriteLine(string.Join(" --> ", list));


            string myName = "  Test Ezio         ";

            myName = myName.Trim().Replace("Test", "Talon");

            WriteLine(string.Equals(myName, "Talon Ezio"));
            WriteLine(string.CompareOrdinal(myName, "Talon Ezio"));// -1, 0 , 1

            WriteLine(string.Concat(list));

            WriteLine(string.Join("", myName.Reverse()));


            var split = myName.Split(' ');
            WriteLine($"{split[0]} {split[1]}");


            var arrayList = new ArrayList
            {
                'a',
                "B",
                10,
                new Student(),
                new()
            };
            Write("ArrayList: ");
            foreach (var item in arrayList)
            {
                Write(item + "\t");
            }

            Write("\nList: ");
            var listInt = new List<int>() { 1, 34, 243, 32, 43 };
            foreach (var item in listInt)
            {
                Write($"{item} ");
            }

            Write("\nDictionary: ");
            var dict = new Dictionary<int, string>()
            {
                {
                    1, "Test"
                },
                {
                    2,"Abc"
                },
                {
                    3,"xyz"
                }

            };

            foreach (var keyValuePair in dict)
            {
                Write($"{keyValuePair.Key} - {keyValuePair.Value}");
            }
            WriteLine();

            #endregion

            #region Enum,Delegate, Event,...

            WriteLine("".PadLeft(40, '*'));
            WriteLine("Review");


            var accountType = AccountType.Vip;

            int accountTypeInt = (int)AccountType.Normal;

            WriteLine($"Enum {accountType} - {accountTypeInt} - {Enum.GetName(accountType)}");



            int a = 10;
            int b = 20;
            SwapGeneric(ref a, ref b);
            WriteLine($"a = {a}; b = {b}");

            string a1 = "A";
            string b1 = "B";
            SwapGeneric(ref a1, ref b1);
            WriteLine($"a1 = {a1}; b1 = {b1}");


            //dynamic intValue = 10;

            //Console.WriteLine(intValue.ToUpper());//Error on runtime...

            var anonymousValue = new
            {
                Name = "A",
                Age = 20,
                Array = new[] { 1, 2, 32, 21 }
            };

            WriteLine($"{anonymousValue.GetType()} - {anonymousValue.Name} - {anonymousValue.Age} - {string.Join(',', anonymousValue.Array)}");



            AddDelegate addDelegate = Add;

            WriteLine(addDelegate(5, 10));

            //Multi-cast
            addDelegate += Add2;

            WriteLine(addDelegate(11, 7));

            addDelegate += (i, y) =>
            {
                var lambdaResult = i * 3 + y;
                WriteLine($"Call from Lambda, result = {lambdaResult}");
                return lambdaResult;
            };

            addDelegate += delegate (int a2, int b2)
            {
                var anonymousDelegateResult = a2 * 5 + b2;
                WriteLine($"Call from Anonymous delegate, result = {anonymousDelegateResult}");
                return anonymousDelegateResult;
            };

            WriteLine(addDelegate(2, 3));


            Action<string> showLogAction = message => WriteLine(message); // Method(string) -> void

            Action<string> showLogActionShorter = WriteLine; // shorter 🤫

            //Local function 🤐
            long FactorialFunc(int i)
            {
                long factorial = 1;
                for (var j = 1; j <= i; ++j)
                {
                    factorial *= j;
                }
                return factorial;
            }

            showLogAction.Invoke("Test message");

            showLogActionShorter.Invoke("Test short action");

            WriteLine($"5! = {FactorialFunc(5)}");


            DelegateAsParameter(5, 10, i => WriteLine($"Tổng của 2 số là {i}"));


            YoutubeChannel lckChannel = new YoutubeChannel()
            {
                Name = "LCK"
            };

            var userA = new Subscriber()
            {
                Name = "User A"
            };
            var userB = new Subscriber()
            {
                Name = "User B"
            };
            var userC = new Subscriber()
            {
                Name = "User C"
            };

            userA.SubscribeDelegate(lckChannel, newVideoTitle => WriteLine($"Xem ngay {newVideoTitle}"));
            userB.SubscribeDelegate(lckChannel, newVideoTitle => WriteLine($"Đã thêm {newVideoTitle} vào danh sách chờ"));

            lckChannel.PublishNewVideo("T1 vs GenG");

            
            userC.CancelAllAndSubscribe(lckChannel, newVideoTitle => WriteLine($"Đã huỷ toàn bộ subscribe cũ, chỉ một mình được xem {newVideoTitle} 😂"));//issue 🤐

            lckChannel.PublishNewVideo("T1 vs HLE");


            userA.SubscribeEvent(lckChannel, newVideoTitle => WriteLine($"Đã nhận được từ event, Xem ngay {newVideoTitle}"));
            userB.SubscribeEvent(lckChannel, newVideoTitle => WriteLine($"Đã nhận được từ event, Đã thêm {newVideoTitle} vào danh sách chờ"));


            lckChannel.PublishNewVideoForEvent("T1 vs DK");

            userA.UnsubscribeEvent(lckChannel);
            userB.UnsubscribeEvent(lckChannel);

            
            
            userA.SubscribeForEventHandler(lckChannel, newVideoTitle => WriteLine($"Đã nhận được từ event chuẩn .NET, Xem ngay {newVideoTitle}"));
            userB.SubscribeForEventHandler(lckChannel, newVideoTitle => WriteLine($"Đã nhận được từ event chuẩn .NET, Đã thêm {newVideoTitle} vào danh sách chờ"));


            lckChannel.PublishNewVideoForEventHandler("GenG vs DK");

            userA.UnsubscribeEventHandler(lckChannel);
            

            lckChannel.PublishNewVideo("HLE vs NS");



            "Log với phương thức mở rộng".PrintLog();

            #endregion
        }

        private static void DelegateAsParameter(int a, int b, Action<int> callback)
        {
            var result = a + b;

            callback.Invoke(result);

        }

        enum AccountType
        {
            Normal,
            Vip
        }
        static void ShowLogStatic(string message, ConsoleColor color = ConsoleColor.Blue)
        {
            lock (Out)
            {
                ForegroundColor = color;
                WriteLine(message);
                ResetColor();
            }
        }

        static void SwapGeneric<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }
        void ShowLogNonStatic(string message, ConsoleColor color = ConsoleColor.Blue)
        {
            lock (Out)
            {
                ForegroundColor = color;
                WriteLine(message);
                ResetColor();
            }
        }

        static void ChangeRefValue(ref int value)
        {
            value *= 2;

        }
        static void ChangeOutValue(out int value)
        {
            value = Random.Shared.Next(1000);
        }
    }
}
