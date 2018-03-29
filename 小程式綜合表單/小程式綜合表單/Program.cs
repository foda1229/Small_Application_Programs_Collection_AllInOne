using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小程式綜合表單
{
    class Program
    {
        public enum Programs
        {
            PRODUCTLIST,
            BMI,
            AUTOCALCU,
            ARMSTRONG,
            GUESS,
            PALINDROMIC,
            PRIME,
            LOOPINTRO,
            TRIANGLE,
            MAXMIN,
            PARALLELOGRAM,
            ENGLISHSCORE,
            FISTFAME,
            GCD,
            LOTTERY,
            BOOKLISTKEYIN,
            NULL,
        }
        public enum Status//設定一個列舉,給予不同的狀態類別
        {
            input,
            statistic,
            revise,
            end,
        }
        public struct Member//設定一個結構,裡面包含固定會有的資訊
        {
            public int id;
            public int listening;
            public int reading;
            public int total;

        }
        public enum FistStatus
        {
            playerturn,
            computerturn,
            playerwin,
            computerwin,
        }
        public struct BookList
        {
            public string title;
            public int price;
            public int amount;
        }
        static void Main(string[] args)
        {
            bool getin = true;
            while (getin)
            {
                Console.Clear();
                Console.WriteLine("以下是各種應用程式,可以輸入編號選擇想應用的程式");
                Console.WriteLine("1.九九乘法表\n2.BMI計算機\n3.自動加、減、乘、除、算餘數的計算機\n4.Armstrong數檢查\n5.金庫密碼\n6.持續判斷是否為回文數\n7.求質數、因數、質因數\n8.小小迴圈教學系統\n9.繪製直角三角形，與倒三角形\n10.找出最大、最小及平均值與陣列長度調整\n11.繪製平行四邊形\n12.全民英檢成績紀錄程式\n13.5、10、15 划酒拳\n14.求最大公因數與最小公倍數\n15.樂透兌獎機\n16.簡單訂書報表");
                Console.WriteLine("請輸入程式編號:");
                string choose = Console.ReadLine();
                int choosenum = Get_integer(choose);
                while (choosenum == -1)
                {
                    Console.WriteLine("輸入值無效,請重新輸入程式編號:");
                    choose = Console.ReadLine();
                    choosenum = Get_integer(choose);
                }
                while (choosenum > 16 || choosenum < 1)
                {
                    Console.WriteLine("輸入值無效,請重新輸入程式編號:");
                    choose = Console.ReadLine();
                    choosenum = Get_integer(choose);
                }
                Programs programs = Programs.NULL;
                programs = Program_Status(choosenum, programs);

                while (programs == Programs.PRODUCTLIST)
                {
                    Console.Clear();
                    Console.WriteLine("九九乘法表:");
                    for (int i = 1; i <= 9; i++)
                    {
                        for (int j = 1; j <= 9; j++)
                        {
                            Console.WriteLine($"{i}*{j}={i * j}\t{i + 1}*{j}={(i + 1) * j}\t{i + 2}*{j}={(i + 2) * j}");
                        }
                        Console.WriteLine();
                        i += 2;
                    }
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.BMI)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter your name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please enter your height(cm):");
                    decimal height = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter your weight:");
                    decimal weight = decimal.Parse(Console.ReadLine());
                    decimal BMI = weight * 10000 / height / height;
                    Console.WriteLine($"{name},your BMI is {Math.Round(BMI, 2)}");
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.AUTOCALCU)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the first number:");
                    int a = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the second number:");
                    int b = int.Parse(Console.ReadLine());
                    Console.WriteLine($"{a}+{b}={a + b}");
                    Console.WriteLine($"{a}-{b}={a - b}");
                    Console.WriteLine($"{a}*{b}={a * b}");
                    Console.WriteLine($"{a}/{b}={a / b}");
                    Console.WriteLine($"{a}/{b}的餘數是{a % b}");
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.ARMSTRONG)
                {
                    Console.Clear();
                    Console.WriteLine("請輸入一個三位數正整數,來判斷是否為Armstrong數:");
                    int input = int.Parse(Console.ReadLine());
                    int a, b, c, d;
                    a = input / 100;
                    b = input % 100 / 10;
                    c = input % 100 % 10;
                    d = a * a * a + b * b * b + c * c * c;
                    if (input == d)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.GUESS)
                {
                    Console.Clear();
                    Random rand = new Random();
                    int computer = rand.Next(1, 101);
                    Console.Write("請猜一個整數,範圍1~100:");
                    int input = int.Parse(Console.ReadLine());
                    int min = 1, max = 100;
                    while (computer != input)
                    {
                        if (input > computer)
                        {
                            max = input;
                            Console.WriteLine("猜的數字比金庫密碼大,請猜一個介於{0}~{1}間的數字:", min, max);
                            input = int.Parse(Console.ReadLine());
                        }
                        if (input < computer)
                        {
                            min = input;
                            Console.WriteLine("猜的數字比金庫密碼小,請猜一個介於{0}~{1}間的數字:", min, max);
                            input = int.Parse(Console.ReadLine());
                        }
                    }
                    if (computer == input)
                    {
                        Console.WriteLine("答對了!");
                    }
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.PALINDROMIC)
                {
                    Console.Clear();
                    Console.WriteLine("請輸入一個5位數,看是否為回文數:");
                    int input = int.Parse(Console.ReadLine());
                    Console.WriteLine("想繼續請按1,離開請按-1:");
                    int decision = int.Parse(Console.ReadLine());
                    bool go = false;
                    while (decision == 1)
                    {
                        while (go == true)
                        {
                            Console.WriteLine("請輸入一個5位數,看是否為回文數:");
                            input = int.Parse(Console.ReadLine());
                            go = false;
                        }
                        int a = input / 10000;
                        int b = (input % 10000) / 1000;
                        int c = (input % 100) / 10;
                        int d = input % 10;
                        if (a == d && b == c)
                        {
                            Console.WriteLine("Result: Yes!");
                            Console.WriteLine("想繼續請按1,離開請按-1:");
                            decision = int.Parse(Console.ReadLine());
                        }
                        if (a != d || b != c)
                        {
                            Console.WriteLine("Result: No!");
                            Console.WriteLine("想繼續請按1,離開請按-1:");
                            decision = int.Parse(Console.ReadLine());
                        }
                        if (decision == 1)
                        {
                            go = true;
                        }
                        if (decision == -1)
                        {
                            break;
                        }
                    }
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.PRIME)
                {
                    Console.Clear();
                    bool go = true;
                    while (go)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a number between 1000~5000:");
                        int num = int.Parse(Console.ReadLine());
                        while (num < 1000 || num > 5000)
                        {
                            Console.WriteLine("Please enter a number between 1000~5000:");
                            num = int.Parse(Console.ReadLine());
                        }
                        int remainder = 0;
                        int a = num;
                        int b = num;
                        int c = num;
                        Console.WriteLine($"小於等於{num}的質數有:");
                        while (a > 1)
                        {
                            int count = 0;
                            for (int i = 1; i <= a; i++)
                            {
                                remainder = a % i;
                                if (remainder == 0)
                                {
                                    count++;
                                }
                            }
                            if (count == 2)
                            {
                                Console.Write(a + ",");
                            }
                            a--;
                            if (a == 1)
                            {
                                Console.Write(a);
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine($"{num}的因數有:");
                        for (int i = 1; i <= b; i++)
                        {
                            remainder = b % i;
                            if (remainder == 0)
                            {
                                if (i != b)
                                {
                                    Console.Write(i + ",");
                                }
                                else
                                {
                                    Console.Write(i);
                                }
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine($"{num}的質因數有:");
                        for (int i = 1; i <= c; i++)
                        {
                            if (i == 1)
                            {
                                Console.Write(i);
                            }
                            remainder = c % i;
                            if (remainder == 0)
                            {
                                int factor = i;
                                int count = 0;
                                int remainder2 = 0;
                                for (int j = 1; j <= factor; j++)
                                {
                                    remainder2 = factor % j;
                                    if (remainder2 == 0)
                                    {
                                        count++;
                                    }
                                }
                                if (count == 2)
                                {
                                    Console.Write("," + factor);
                                }
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Play again?Yes=1,No=any key");
                        string response = Console.ReadLine();
                        if (response != "1")
                        {
                            go = false;
                        }
                    }
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.LOOPINTRO)
                {
                    Console.Clear();
                    #region codeArea
                    string choice = "", innerchoice = "";
                    bool defense = true;
                    bool defenseprime = true;


                    while (defenseprime)
                    {
                        if (choice != "")
                        {

                        }
                        else if (innerchoice == "q")
                        {
                            Console.Clear();
                            Console.Write("請選擇想看的迴圈介紹\n1. while\n2. do...while\n3. for\nq.離開:\n");
                            choice = Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("請選擇想看的迴圈介紹\n1. while\n2. do...while\n3. for\nq.離開:\n");
                            choice = Console.ReadLine();
                        }

                        switch (choice)
                        {
                            case "1":
                                bool enter1 = true;
                                while (enter1)
                                {
                                    Console.Clear();
                                    Console.WriteLine(@"while的迴圈結構如圖:

while(1.判斷式)
{
3.重複做的事
2.影響判斷式
}

給while迴圈一個判斷式和影響判斷式的方法，
當判斷式成立時,就會重複做指令給電腦做的事，
直到判斷式不成立後就會跳出迴圈。

範例code:

列印1~10的數字,在i<=10時,印出i的值,並且讓i的值+1,直到i大於10的時候跳出while迴圈。

int i = 1;
            while (i<=10)
            {
                Console.WriteLine(i);
                i++;
            }
");
                                    Console.WriteLine("請按q回選單:");
                                    innerchoice = Console.ReadLine();
                                    Console.WriteLine();
                                    enter1 = innerchoice == "" ? true : false;

                                }
                                while (innerchoice != "q")
                                {
                                    Console.Clear();
                                    Console.WriteLine("您所輸入的值不是q,請按q回選單:");
                                    innerchoice = Console.ReadLine();
                                }
                                choice = "";
                                break;
                            case "3":
                                bool enter2 = true;
                                while (enter2)
                                {
                                    Console.Clear();
                                    Console.WriteLine(@"for的迴圈結構如圖:

for(有起始值的一個變數;1.判斷式;2.影響判斷式)
{
3.重複做的事情
}

for迴圈也同樣在判斷式成立時,會重複做指定給迴圈要做的事情
使用方法是:
在for條件中依序填入
一個變數,並給一個值
填入判斷式
再給一個方法來影響判斷式
然後填入需要重複做的事情
迴圈會不斷執行，直到判斷式不符合，就會跳出迴圈。


範例code:

列印1~10的數字,在i<=10時,印出i的值,並且讓i的值+1,直到i大於10的時候跳出while迴圈。

for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
");
                                    Console.WriteLine("請按q回選單:");
                                    innerchoice = Console.ReadLine();
                                    Console.WriteLine();
                                    enter2 = innerchoice == "" ? true : false;

                                }
                                while (innerchoice != "q")
                                {
                                    Console.Clear();
                                    Console.WriteLine("您所輸入的值不是q,請按q回選單:");
                                    innerchoice = Console.ReadLine();
                                }
                                choice = "";
                                break;
                            case "2":
                                bool enter3 = true;
                                while (enter3)
                                {
                                    Console.Clear();
                                    Console.WriteLine(@"do...while的迴圈結構如圖:

do
{
3.重複做的事
2.影響判斷式
}while(1.判斷式)

和while不同的是:do...while會至少先執行一次再進行判斷式，
使用方式也是給do...while迴圈一個判斷式和影響判斷式的方法，
當判斷式成立時,就會重複做指令給電腦做的事，
直到判斷式不成立後就會跳出迴圈。

範例code:

列印1~10的數字,在i<=10時,印出i的值,並且讓i的值+1,直到i大於10的時候跳出while迴圈。

int i = 1;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i<=10);");
                                    Console.WriteLine("請按q回選單:");
                                    innerchoice = Console.ReadLine();
                                    Console.WriteLine();
                                    enter3 = innerchoice == "" ? true : false;

                                }
                                while (innerchoice != "q")
                                {
                                    Console.Clear();
                                    Console.WriteLine("您所輸入的值不是q,請按q回選單:");
                                    innerchoice = Console.ReadLine();
                                }
                                choice = "";
                                break;
                            case "q":
                                Console.Clear();
                                break;
                            default:
                                if (choice != "q")
                                {
                                    defense = false;
                                }
                                if (choice != "1")
                                {
                                    defense = false;
                                }
                                if (choice != "2")
                                {
                                    defense = false;
                                }
                                if (choice != "3")
                                {
                                    defense = false;
                                }

                                while (!defense)
                                {
                                    Console.Write("您輸入的值不在選單範圍內,請選擇想看的迴圈介紹(1. while 2. do while 3. for q.離開:");
                                    choice = Console.ReadLine();
                                    if (choice == "q")
                                    {
                                        defense = true;
                                    }
                                    if (choice == "1")
                                    {
                                        defense = true;
                                    }
                                    if (choice == "2")
                                    {
                                        defense = true;
                                    }
                                    if (choice == "3")
                                    {
                                        defense = true;
                                    }
                                }
                                break;
                        }

                        if (choice == "q")
                        {
                            defenseprime = false;
                        }
                    }
                    #endregion
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.TRIANGLE)
                {
                    Console.Clear();
                    bool ifcontinue = true;

                    while (ifcontinue)
                    {
                        Console.Write("請輸入1或2(1=直角三角形,2=倒直角三角形):");
                        int ans = int.Parse(Console.ReadLine());

                        if (ans == 1)
                        {
                            Console.WriteLine();
                            string star = "*";
                            int i = 1;
                            while (i <= 5)
                            {
                                for (int j = 1; j <= i; j++)
                                {
                                    Console.Write($"{star}");
                                }
                                Console.WriteLine();
                                i++;
                            }
                            Console.Write("是否再玩一次(1=yes,2=no):");
                            string respond = Console.ReadLine();
                            ifcontinue = respond == "2" ? false : true;
                            if (respond == "2")
                            {
                            }
                            else
                            {
                                while (respond != "1")
                                {
                                    Console.Write("請輸入1或2判別,是否再玩一次(1=yes,2=no):");
                                    respond = Console.ReadLine();
                                }
                            }
                        }
                        else if (ans == 2)
                        {
                            Console.WriteLine();
                            string star = "*";
                            int i = 5;
                            while (i >= 1)
                            {
                                for (int j = 1; j <= i; j++)
                                {
                                    Console.Write($"{star}");
                                }
                                Console.WriteLine();
                                i--;
                            }
                            Console.Write("是否再玩一次(1=yes,2=no):");
                            string respond = Console.ReadLine();
                            ifcontinue = respond == "2" ? false : true;
                            if (respond == "2")
                            {
                            }
                            else
                            {
                                while (respond != "1")
                                {
                                    Console.Write("請輸入1或2判別,是否再玩一次(1=yes,2=no):");
                                    respond = Console.ReadLine();
                                }
                            }
                        }


                    }

                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.MAXMIN)
                {
                    Console.Clear();
                    int[] array = new int[1];
                    int respondnum = 0;
                    int respond;
                    double sum = 0;
                    Console.WriteLine("這是個簡單程式,可以記錄最大值,最小值,平均值,和總共多少數字");
                    do
                    {
                        Console.Write("請輸入一個正整數n，共可輸入n個正整數(0<n<2147483647),直到輸入-1做結算:");
                        respond = int.Parse(Console.ReadLine());


                        if (respond != -1)
                        {
                            respondnum++;
                            Array.Resize(ref array, respondnum);
                            array[(respondnum - 1)] = respond;
                            sum = sum + respond;
                        }

                    } while (respond != -1);

                    Console.WriteLine($"Length={respondnum}");

                    for (int i = 0; i < array.Length; i++)
                    {
                        int bigger = 0, smaller = 0;

                        for (int j = 0; j < array.Length; j++)
                        {
                            if (array[i] < array[j])
                            {
                                bigger++;
                            }
                            if (array[i] > array[j])
                            {
                                smaller++;
                            }
                        }

                        if (bigger == 0)
                        {
                            Console.WriteLine($"Maximum={array[i]}");
                        }

                    }
                    for (int i = 0; i < array.Length; i++)
                    {
                        int bigger = 0, smaller = 0;

                        for (int j = 0; j < array.Length; j++)
                        {
                            if (array[i] < array[j])
                            {
                                bigger++;
                            }
                            if (array[i] > array[j])
                            {
                                smaller++;
                            }
                        }


                        if (smaller == 0)
                        {
                            Console.WriteLine($"Minimum={array[i]}");
                        }
                    }
                    Console.WriteLine($"Mean={sum / respondnum}");
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.PARALLELOGRAM)
                {
                    Console.Clear();
                    int length;
                    Console.Write("請輸入一個正整數作為平行四邊形的邊長:");
                    length = int.Parse(Console.ReadLine());

                    for (int i = 0; i < length; i++)
                    {
                        for (int j = (length - i); j > 1; j--)
                        {
                            Console.Write(" ");
                        }
                        for (int k = 0; k <= length; k++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.ENGLISHSCORE)
                {
                    Console.Clear();
                    bool go = true;//給定一個布林值,作為可以回選單的迴圈判定方法

                    Status list = Status.input;//先給狀態一個初始值,讓選單判別系統可以改變狀態,不然會發生null而後面無法使用的狀況
                    Console.Write("主選項:1)輸入成績 2)統計資料 3)修改成績 -1)結束:");
                    int choice = int.Parse(Console.ReadLine());
                    #region 表單防呆和選單判別

                    while (choice != 1 && choice != 2 && choice != 3 && choice != -1)
                    {
                        Console.WriteLine("無該選項!");
                        Console.Write("主選項:1)輸入成績 2)統計資料 3)修改成績 -1)結束:");
                        choice = int.Parse(Console.ReadLine());
                    }

                    if (choice == 1)
                    {
                        list = Status.input;
                    }
                    if (choice == 2)
                    {
                        list = Status.statistic;
                    }
                    if (choice == 3)
                    {
                        list = Status.revise;
                    }
                    if (choice == -1)
                    {
                        list = Status.end;
                        go = false;
                    }
                    #endregion
                    //表單防呆和選單判別在每一個迴圈寫法都相同,在最後可以更改進入不同狀態
                    int membercount = 0;
                    int membernum = 1;
                    Member[] members = new Member[membernum];//最外面先宣告一個members的陣列集合,來收集所有輸入的成績,如果寫在迴圈裡面,狀態改變時,都會初始化一次
                                                             //寫在外面可以累積輸入的成績

                    while (go)
                    {

                        while (list == Status.input)
                        {
                            Member member;//宣告一個結構,來放進該結構需要的不同資訊
                            Console.Write("聽力測驗:");//這邊請使用者輸入成績
                            member.listening = int.Parse(Console.ReadLine());

                            while (member.listening < 0 || member.listening > 120)
                            {
                                Console.WriteLine("聽力測驗分數輸入錯誤!");//成績輸入範圍錯誤時,進入防呆迴圈
                                Console.Write("聽力測驗:");
                                member.listening = int.Parse(Console.ReadLine());
                            }

                            Console.Write("閱讀測驗:");//這邊請使用者輸入成績
                            member.reading = int.Parse(Console.ReadLine());

                            while (member.reading < 0 || member.reading > 120)
                            {
                                Console.WriteLine("閱讀測驗分數輸入錯誤!");//成績輸入範圍錯誤時,進入防呆迴圈
                                Console.Write("閱讀測驗:");
                                member.reading = int.Parse(Console.ReadLine());
                            }

                            member.total = member.listening + member.reading;//成績加總
                            member.id = ++membercount;//計算總共輸入多少分成績
                            Array.Resize(ref members, membercount);//成績陣列集合大小改變成,總共的成績數量
                            members[membercount - 1] = member;//成績陣列的元素來源是,這個已經具備資料的結構元素
                            Console.Write("主選項:1)輸入成績 2)統計資料 3)修改成績 -1)結束:");//出現表單選項問使用者接下來要做什麼
                            choice = int.Parse(Console.ReadLine());
                            #region 表單防呆和選單判別
                            while (choice != 1 && choice != 2 && choice != 3 && choice != -1)
                            {
                                Console.WriteLine("無該選項!");
                                Console.Write("主選項:1)輸入成績 2)統計資料 3)修改成績 -1)結束:");
                                choice = int.Parse(Console.ReadLine());
                            }

                            if (choice == 1)
                            {
                                list = Status.input;
                            }
                            if (choice == 2)
                            {
                                list = Status.statistic;
                            }
                            if (choice == 3)
                            {
                                list = Status.revise;
                            }
                            if (choice == -1)
                            {
                                list = Status.end;
                            }
                            #endregion

                        }
                        while (list == Status.revise)
                        {
                            Console.Write("編號:");//如果需要修改資料,可以先輸入編號
                            int revisenum = int.Parse(Console.ReadLine());//得到需要改的編號的數字
                            while (revisenum < 1 || revisenum > membercount)//編號防呆設計
                            {
                                Console.WriteLine("超出索引範圍!");
                                Console.Write("編號:");
                                revisenum = int.Parse(Console.ReadLine());
                            }

                            Console.Write("修正分數(輸入格式:聽力成績 閱讀成績):");//使用者輸入要改成的成績
                            string reviseans = Console.ReadLine();
                            string[] revisegrade = reviseans.Split(' ');//猜開字串
                            members[revisenum - 1].listening = int.Parse(revisegrade[0]);//拆開字串後,把前面的資訊給該編號結構的聽力成績
                            members[revisenum - 1].reading = int.Parse(revisegrade[1]);//把後面的資訊給該編號的閱讀成績
                            members[revisenum - 1].total = members[revisenum - 1].listening + members[revisenum - 1].reading;//改變總成績為新的成績加總

                            Console.Write("主選項:1)輸入成績 2)統計資料 3)修改成績 -1)結束:");
                            choice = int.Parse(Console.ReadLine());
                            #region 表單防呆和選單判別
                            while (choice != 1 && choice != 2 && choice != 3 && choice != -1)
                            {
                                Console.WriteLine("無該選項!");
                                Console.Write("主選項:1)輸入成績 2)統計資料 3)修改成績 -1)結束:");
                                choice = int.Parse(Console.ReadLine());
                            }

                            if (choice == 1)
                            {
                                list = Status.input;
                            }
                            if (choice == 2)
                            {
                                list = Status.statistic;
                            }
                            if (choice == 3)
                            {
                                list = Status.revise;
                            }
                            if (choice == -1)
                            {
                                list = Status.end;
                            }
                            #endregion
                        }
                        while (list == Status.statistic)
                        {
                            Console.WriteLine("       聽力測驗  閱讀測驗  總分");//表單的目錄
                            Console.WriteLine("----------------------------------------------");//分隔線
                            for (int i = 0; i < members.Length; i++)
                            {
                                Console.WriteLine($"{members[i].id}               {members[i].listening} {members[i].reading} {members[i].total}");//表單資料呈現
                            }
                            Console.Write("主選項:1)輸入成績 2)統計資料 3)修改成績 -1)結束:");
                            choice = int.Parse(Console.ReadLine());
                            #region 表單防呆和選單判別
                            while (choice != 1 && choice != 2 && choice != 3 && choice != -1)
                            {
                                Console.WriteLine("無該選項!");
                                Console.Write("主選項:1)輸入成績 2)統計資料 3)修改成績 -1)結束:");
                                choice = int.Parse(Console.ReadLine());
                            }

                            if (choice == 1)
                            {
                                list = Status.input;
                            }
                            if (choice == 2)
                            {
                                list = Status.statistic;
                            }
                            if (choice == 3)
                            {
                                list = Status.revise;
                            }
                            if (choice == -1)
                            {
                                list = Status.end;
                            }
                            #endregion
                        }

                        while (list == Status.end)  //輸入-1後,狀態進到這裡,改變布林值且改變狀態來結束迴圈
                        {
                            go = false;
                            list = Status.input;
                        }


                    }



                    Console.WriteLine("結束程式");
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.FISTFAME)
                {
                    Console.Clear();
                    bool go = true;
                    while (go)
                    {
                        bool gogo = true;
                        Console.Clear();
                        Console.WriteLine("This is a 划酒拳 game.");
                        Console.WriteLine("拳法是:左手/右手/拳語,左右手可以分別出0或5,拳語是左右手總和");
                        Console.WriteLine("Ex: 0 5 10");
                        Console.WriteLine("出拳順序為隨機決定");
                        Console.WriteLine("遊戲開始囉");
                        Console.WriteLine();
                        FistStatus whoseturn = FistStatus.playerturn;
                        Random order = new Random();
                        int whofirst = order.Next(1, 3);
                        if (whofirst == 1)
                        {
                            whoseturn = FistStatus.playerturn;
                        }
                        else if (whofirst == 2)
                        {
                            whoseturn = FistStatus.computerturn;
                        }

                        while (gogo)
                        {

                            int playercount = 0;
                            int computercount = 0;

                            while (whoseturn == FistStatus.playerturn)
                            {
                                Console.Write("玩家先出拳(Ex:5 5 15):");
                                string playerrespond = Console.ReadLine();
                                string[] playerfist = playerrespond.Split(' ');
                                int[] playerfistint = new int[3];
                                int[] fistbag = { 0, 5 };
                                Random fistcode = new Random();

                                int[] computerfistint = new int[2];
                                int playerfistsum = 0;
                                int computerfistsum = 0;
                                for (int i = 0; i < playerfist.Length; i++)
                                {
                                    playerfistint[i] = int.Parse(playerfist[i]);
                                }
                                for (int i = 0; i < 2; i++)
                                {
                                    playerfistsum += playerfistint[i];
                                }
                                Console.WriteLine($"玩家:{playerrespond}");
                                for (int i = 0; i < computerfistint.Length; i++)
                                {
                                    int computerfistnum = fistcode.Next(0, 2);
                                    computerfistint[i] = fistbag[computerfistnum];
                                }
                                for (int i = 0; i < computerfistint.Length; i++)
                                {
                                    computerfistsum += computerfistint[i];
                                }
                                Console.WriteLine($"電腦:{computerfistint[0]} {computerfistint[1]}");
                                Console.WriteLine($"總和:{playerfistsum + computerfistsum}");
                                if (playerfistint[2] == (playerfistsum + computerfistsum))
                                {
                                    playercount++;
                                    Console.WriteLine("玩家聽牌");
                                    whoseturn = FistStatus.playerturn;
                                }
                                if (playerfistint[2] != (playerfistsum + computerfistsum))
                                {
                                    playercount = 0;
                                    whoseturn = FistStatus.computerturn;
                                }
                                if (playercount == 2)
                                {
                                    whoseturn = FistStatus.playerwin;
                                }
                                Console.WriteLine();
                            }

                            while (whoseturn == FistStatus.computerturn)
                            {
                                int[] fistbag = { 0, 5 };
                                Random fistcode = new Random();

                                int[] computerfistint = new int[3];
                                int playerfistsum = 0;
                                int computerfistsum = 0;
                                for (int i = 0; i < 2; i++)
                                {
                                    int computerfistnum = fistcode.Next(0, 2);
                                    computerfistint[i] = fistbag[computerfistnum];
                                }

                                computerfistint[2] = computerfistint[0] + computerfistint[1];

                                for (int i = 0; i < computerfistint.Length; i++)
                                {
                                    computerfistsum += computerfistint[i];
                                }
                                Console.Write("電腦已出拳,換玩家出拳(Ex: 5 5):");
                                string playerrespond = Console.ReadLine();
                                string[] playerfist = playerrespond.Split(' ');
                                int[] playerfistint = new int[2];
                                for (int i = 0; i < playerfist.Length; i++)
                                {
                                    playerfistint[i] = int.Parse(playerfist[i]);
                                }
                                for (int i = 0; i < 2; i++)
                                {
                                    playerfistsum += playerfistint[i];
                                }
                                Console.WriteLine($"電腦{computerfistint[0]} {computerfistint[1]} {computerfistint[2]}");
                                Console.WriteLine($"玩家:{playerfistint[0]} {playerfistint[1]}");
                                Console.WriteLine($"總和:{playerfistsum + computerfistsum}");
                                if (computerfistint[2] == (playerfistsum + computerfistsum))
                                {
                                    computercount++;
                                    Console.WriteLine("電腦聽牌");
                                    whoseturn = FistStatus.computerturn;
                                }
                                if (computerfistint[2] != (playerfistsum + computerfistsum))
                                {
                                    computercount = 0;
                                    whoseturn = FistStatus.playerturn;
                                }
                                if (computercount == 2)
                                {
                                    whoseturn = FistStatus.computerwin;
                                }
                                Console.WriteLine();
                            }
                            if (whoseturn == FistStatus.playerwin)
                            {
                                Console.WriteLine("玩家獲勝!");
                                Console.Write("請問是否繼續(1: Yes/2: No)？");
                                int decision = int.Parse(Console.ReadLine());

                                if (decision == 2)
                                {
                                    gogo = false;
                                    go = false;
                                }
                                if (decision == 1)
                                {
                                    whoseturn = FistStatus.playerturn;
                                    go = true;
                                    gogo = false;
                                }
                            }
                            if (whoseturn == FistStatus.computerwin)
                            {
                                Console.WriteLine("電腦獲勝!");
                                Console.Write("請問是否繼續(1: Yes/2: No)？");
                                int decision = int.Parse(Console.ReadLine());

                                if (decision == 2)
                                {
                                    gogo = false;
                                    go = false;
                                }
                                if (decision == 1)
                                {
                                    whoseturn = FistStatus.computerturn;
                                    go = true;
                                    gogo = false;
                                }
                            }


                        }

                    }


                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.GCD)
                {
                    Console.Clear();
                    bool isok = true;
                    while (isok)
                    {
                        Console.Clear();
                        Console.WriteLine("please input first number");
                        int num1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("please input second number");
                        int num2 = int.Parse(Console.ReadLine());

                        int gcd = Getgcd(num1, num2); //這是最大公因數的function

                        int firstcm = Get1cm(num1, num2, gcd);//這是最小公倍數的function

                        Console.WriteLine($"1cm:{firstcm}");
                        Console.WriteLine("======");
                        Console.WriteLine("Do you want to continue? Yes=1, No=any key");
                        string response = Console.ReadLine();

                        if (response != "1")
                        {
                            isok = false;
                        }
                    }
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.LOTTERY)
                {
                    Console.Clear();
                    Random pool = new Random();

                    bool go = true;

                    while (go)
                    {

                        Console.Clear();

                        Console.WriteLine("這是樂透兌獎機,請輸入6個不重複的數字,並用逗號隔開,(Ex:1,2,3,4,5,6):");
                        string[] inputstring = Console.ReadLine().Split(',');
                        int[] inputnum = new int[inputstring.Length];

                        while (inputstring.Length != 6)
                        {
                            Console.Clear();
                            Console.WriteLine("這是樂透兌獎機,請輸入6個不重複的數字,並用逗號隔開,(Ex:1,2,3,4,5,6):");
                            inputstring = Console.ReadLine().Split(',');
                            inputnum = new int[inputstring.Length];
                        }

                        for (int i = 0; i < inputnum.Length; i++)
                        {
                            inputnum[i] = int.Parse(inputstring[i]);
                        }

                        int repeatcount = Check_ifrepeat(inputstring, inputnum);//檢查是否有重複數字

                        while (repeatcount > 6)
                        {
                            repeatcount = 0;
                            Console.Clear();
                            Console.WriteLine("這是樂透兌獎機,請輸入6個不重複的數字,並用逗號隔開,(Ex:1,2,3,4,5,6):");
                            inputstring = Console.ReadLine().Split(',');
                            inputnum = new int[inputstring.Length];
                        }

                        for (int i = 0; i < inputnum.Length; i++)
                        {
                            inputnum[i] = int.Parse(inputstring[i]);
                        }
                        int[] computer = Generate_computernum(pool);//產生電腦樂透數字

                        int matchnum = Count_matchnum(inputnum, computer);//計算選中多少號碼

                        Console.Write("使用者輸入:");
                        for (int i = 0; i < inputnum.Length; i++)
                        {
                            if (i == 5)
                            {
                                Console.Write(inputnum[i]);
                            }
                            else
                            {
                                Console.Write(inputnum[i] + ",");
                            }
                        }
                        Console.WriteLine();
                        Console.Write("電腦產生樂透值:");
                        for (int i = 0; i < computer.Length; i++)
                        {
                            if (i == 5)
                            {
                                Console.Write(computer[i]);
                            }
                            else
                            {
                                Console.Write(computer[i] + ",");
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine($"猜對的數字有{matchnum}個");
                        Console.Write("猜對的數字有:");

                        Show_thematchlist(inputnum, computer, matchnum);//顯示選中哪些數字

                        Console.WriteLine();

                        Console.Write("再玩一次(Yes=1,No=any key)?");
                        string decision = Console.ReadLine();

                        if (decision != "1")
                        {
                            go = false;
                        }

                    }
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }
                while (programs == Programs.BOOKLISTKEYIN)
                {
                    Console.Clear();
                    try
                    {
                        string path = $"Book_List_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss.fffffff")}.html";//存成html檔案
                        Console.WriteLine("請問要輸入幾筆書目(至少輸入3筆):");
                        string inputnum = Console.ReadLine();
                        int num = Transfer_to_int(inputnum);
                        while (num == -1)
                        {
                            Console.WriteLine("您輸入的不是數字,請問要輸入幾筆書目(至少輸入3筆):");
                            inputnum = Console.ReadLine();
                            num = Transfer_to_int(inputnum);
                        }
                        while (num < 3)
                        {
                            Console.WriteLine("請至少輸入3筆");
                            Console.WriteLine("請問要輸入幾筆書目(至少輸入3筆):");
                            num = int.Parse(Console.ReadLine());
                        }
                        BookList[] content = new BookList[num];
                        int counter = 0;
                        while (counter < num)
                        {
                            Console.WriteLine($"這是第{counter + 1}筆資料,共{num}筆");
                            Console.WriteLine("標題:");
                            string title = Console.ReadLine();
                            Console.WriteLine("價錢:");
                            string inputprice = Console.ReadLine();
                            int price = Transfer_to_int(inputprice);
                            while (price == -1)
                            {
                                Console.WriteLine("您輸入的不是數字,價錢:");
                                inputprice = Console.ReadLine();
                                price = Transfer_to_int(inputprice);
                            }
                            Console.WriteLine("數量");
                            string inputamount = Console.ReadLine();
                            int amount = Transfer_to_int(inputamount);
                            while (amount == -1)
                            {
                                Console.WriteLine("您輸入的不是數字,數量:");
                                inputamount = Console.ReadLine();
                                amount = Transfer_to_int(inputamount);
                            }
                            content[counter].title = title;
                            content[counter].price = price;
                            content[counter].amount = amount;
                            counter++;
                        }
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine("<!DOCTYPE html>");
                        stringBuilder.AppendLine(@"<html lang=""en"">");
                        stringBuilder.AppendLine("<head>");
                        stringBuilder.AppendLine(@"<meta charset=""UTF - 8"">");
                        stringBuilder.AppendLine(@"<meta name=""viewport"" content=""width = device - width, initial - scale = 1.0"">");
                        stringBuilder.AppendLine(@"<meta http-equiv=""X - UA - Compatible"" content=""ie = edge"">");
                        stringBuilder.AppendLine("<title>Book List</title>");
                        stringBuilder.AppendLine("<style>");
                        stringBuilder.AppendLine("table.book, th, td");
                        stringBuilder.AppendLine("{");
                        stringBuilder.AppendLine("border: 1px solid black;");
                        stringBuilder.AppendLine("border-collapse: collapse;");
                        stringBuilder.AppendLine("}");
                        stringBuilder.AppendLine("</style>");
                        stringBuilder.AppendLine("</head><body>");
                        stringBuilder.AppendLine(@"<table class=""book"">");
                        stringBuilder.AppendLine(@"<tr><th style=""text-align:left"">title</th><th style=""text-align:left"">price</th><th style=""text-align:left"">amount</th></tr>");
                        for (int i = 0; i < content.Length; i++)
                        {
                            stringBuilder.AppendLine(@"<tr><td style=""text-align:left;width:150px"">" + $"{content[i].title}" + @"</td><td style=""text-align:right;width:50px"">" + $"{content[i].price}" + @"</td><td style=""text-align:right;width:70px"">" + $"{content[i].amount}</td><tr>");
                        }
                        stringBuilder.AppendLine("</table></body></html>");
                        File.WriteAllText(path, stringBuilder.ToString(), Encoding.UTF8);
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    Console.WriteLine("再玩一次請按1,或按任意鍵離開");
                    string stayOrLeave = Console.ReadLine();
                    if (stayOrLeave != "1")
                    {
                        programs = Programs.NULL;
                    }
                }

                Console.Clear();
                Console.WriteLine("回主選單請按1,或按任意鍵離開:");
                string final = Console.ReadLine();
                if (final != "1")
                {
                    getin = false;
                }
            }
        }
        private static Programs Program_Status(int choosenum, Programs programs)
        {
            if (choosenum == 1)
            {
                programs = Programs.PRODUCTLIST;
            }
            else if (choosenum == 2)
            {
                programs = Programs.BMI;
            }
            else if (choosenum == 3)
            {
                programs = Programs.AUTOCALCU;
            }
            else if (choosenum == 4)
            {
                programs = Programs.ARMSTRONG;
            }
            else if (choosenum == 5)
            {
                programs = Programs.GUESS;
            }
            else if (choosenum == 6)
            {
                programs = Programs.PALINDROMIC;
            }
            else if (choosenum == 7)
            {
                programs = Programs.PRIME;
            }
            else if (choosenum == 8)
            {
                programs = Programs.LOOPINTRO;
            }
            else if (choosenum == 9)
            {
                programs = Programs.TRIANGLE;
            }
            else if (choosenum == 10)
            {
                programs = Programs.MAXMIN;
            }
            else if (choosenum == 11)
            {
                programs = Programs.PARALLELOGRAM;
            }
            else if (choosenum == 12)
            {
                programs = Programs.ENGLISHSCORE;
            }
            else if (choosenum == 13)
            {
                programs = Programs.FISTFAME;
            }
            else if (choosenum == 14)
            {
                programs = Programs.GCD;
            }
            else if (choosenum == 15)
            {
                programs = Programs.LOTTERY;
            }
            else if (choosenum == 16)
            {
                programs = Programs.BOOKLISTKEYIN;
            }

            return programs;
        }
        private static int Get_integer(string input)
        {
            int num;
            if (int.TryParse(input, out num))
            {
                return num;
            }
            return -1;
        }
        private static int Get1cm(int num1, int num2, int gcd)
        {
            return num1 * num2 / gcd;
        }
        private static int Getgcd(int num1, int num2)
        {
            int a = num1;
            int b = num2;
            int remainder = 1;
            int c = remainder;
            int gcd = 1;

            while (c != 0)
            {
                if (a > b)
                {
                    c = a % b;
                    Console.WriteLine($"num1:{a},num2:{b},remainder:{c}");
                    a = b;
                    b = c;
                }
                if (a < b)
                {
                    c = b % a;
                    Console.WriteLine($"num1:{b},num2:{a},remainder:{c}");
                    b = a;
                    a = c;
                }
            }

            if (b != 0)
            {
                Console.WriteLine($"gcd:{b}");
                gcd = b;
            }
            if (a != 0)
            {
                Console.WriteLine($"gcd:{a}");
                gcd = a;
            }

            return gcd;
        }
        private static int[] Generate_computernum(Random pool)
        {
            int[] computer = new int[6];
            bool a = true;
            while (a)
            {
                int b = 0;

                for (int i = 0; i < 6; i++)
                {
                    int randnum = pool.Next(1, 50);
                    computer[i] = randnum;
                }

                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (computer[i] == computer[j])
                        {
                            b++;
                        }
                    }
                }
                if (b == 6)
                {
                    a = false;
                }
            }

            return computer;
        }
        private static int Check_ifrepeat(string[] inputstring, int[] inputnum)
        {
            int repeatcount = 0;

            for (int i = 0; i < inputstring.Length; i++)
            {
                for (int j = 0; j < inputstring.Length; j++)
                {
                    if (inputnum[i] == inputnum[j])
                    {
                        repeatcount++;
                    }
                }
            }

            return repeatcount;
        }
        private static void Show_thematchlist(int[] inputnum, int[] computer, int matchnum)
        {
            int countlist = 0;
            for (int i = 0; i < inputnum.Length; i++)
            {
                for (int j = 0; j < computer.Length; j++)
                {
                    if (inputnum[i] == computer[j])
                    {
                        countlist++;
                        if (countlist == matchnum)
                        {
                            Console.Write(inputnum[i]);
                        }
                        else
                        {
                            Console.Write(inputnum[i] + ",");
                        }
                    }
                }
            }
        }
        private static int Count_matchnum(int[] inputnum, int[] computer)
        {
            int matchnum = 0;
            for (int i = 0; i < computer.Length; i++)
            {
                for (int j = 0; j < computer.Length; j++)
                {
                    if (inputnum[i] == computer[j])
                    {
                        matchnum++;
                    }
                }
            }

            return matchnum;
        }
        private static int Transfer_to_int(string input)
        {
            int num;
            if (int.TryParse(input, out num))
            {
                return num;
            }
            return -1;
        }
    }
}
