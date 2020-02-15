using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestTask
{
    class Program
    {
        static string _file;

        static async Task Main(string[] args)
        {
            
            await Test1();
            await Test2();
            if (ReadArgs(args))
            {
                Test3();
            }
            await Test4();
        }

        private static bool ReadArgs(string[] args)
        {
            if (args.Length == 0)
            {
                string test = "Для запуска 3 и 4 теста нужно указать абсолютный путь к файлу Users.json.\n\rПример: TestTask d:\\Projects\\CSharp\\TestTask\\Users.json";
                Console.WriteLine(test);
                return false;
            }

            _file = args[0];
            return true;
        }

        /*
        Необходимо реализовать программу, которая будет делать запрос двух информационных справочников, разбирать их и записывать в базу.

        Первым справочником является набор кодов ошибок и их описание. Адрес для запроса - https://pastebin.com/raw/JK7WiMax
        Тип запроса – GET. Формат ответа – "text/plain; charset=utf-8".
        Пример ответа:
        <ErrorCodes>
        <ErrorCode code="-1" text="Оператор временно недоступен"/>
        <ErrorCode code="0" text="Ошибки нет"/>
        </ErrorCodes>

        Code - код ошибки;
        Text - описание кода ошибки;
        
        Для обоих справочников нужно создать в БД таблицы. Запись в таблицу должна производиться через
        хранимую процедуру. В процедуре должна быть реализована проверка на существование записей (любым
        возможным способом). Если такая запись существует, то добавлять ее не нужно.
        */
        private static async Task Test1()
        {
            var workWeb = new WorkWeb();
            var list = await workWeb.GetErrorCodesAsync();

            var bataBase = new DataBase();
            foreach (var errorCode in list.ListErrorCodes)
            {
                bataBase.InsertErrorCode(errorCode);
            }
        }

        /*
        Вторым справочником является список категорий и их детали. Адрес для запроса - https://pastebin.com/raw/0RpLbQ19
        Тип запроса – GET. Формат ответа – "text/plain; charset=utf-8".
        Пример ответа:
        <Categories>
        <category id="100" name="Автоматический выбор оператора" parent="0" image="main_main_ico.gif"/>
        <category id="101" name="Мобильная связь" parent="0" image="main_mobile_ico.gif"/>
        </Categories>

        ID - уникальный идентификатор категории;
        Name - название категории;
        Parent - идентификатор родительской категории. Если значение равно 0 - значит родителя - нет;
        Image - лого категории;
        
        Для обоих справочников нужно создать в БД таблицы. Запись в таблицу должна производиться через
        хранимую процедуру. В процедуре должна быть реализована проверка на существование записей (любым
        возможным способом). Если такая запись существует, то добавлять ее не нужно.
        */
        private static async Task Test2()
        {
            var workWeb = new WorkWeb();
            var list = await workWeb.GetCategoriesAsync();

            var bataBase = new DataBase();
            foreach (var category in list.ListCategories)
            {
                bataBase.InsertCategory(category);
            }
        }

        /*
        Будет плюсом если будет реализованно так же прочитать JSON из файла и сконвертировать его.

        JSON файл с именем "User.json" следует прочитать, и записать в файл "UserConverted.txt" (в
        формате txt следует использовать разделитель ";"). В конце файла "UserConverted.txt" последней
        строкой должена идти дополнительная информация. Дополнительная информация должна содержать
        количество записей (т.е. сколько людей было), а так же даты самого ранеего и самого позднего
        создания пользователя, дополнительная информация должна быть в формате: знак доллара ($), затем
        количество запистей, вертикальная черта (|), дальше дата самого раненнго создания аккаунта,
        знак собаки (@), дата самого последнего создания аккаунта. Даты должна быть записаны в формате
        ДД.ММ.ГГГГ чч:мм:сс.
        Например так: $10|20.12.1999 15:22:37@1.10.2290 11:33:22.
        */
        private static void Test3()
        {
            using (var sr = new StreamReader(_file))
            {
                var text = sr.ReadToEnd();
                var json = JsonConvert.DeserializeObject<List<Person>>(text);

                DateTime minTimeCreateAccaunt = json.Min(x => x.CreatedAt);
                DateTime maxTimeCreateAccaunt = json.Max(x => x.CreatedAt);

                using (var sw = new StreamWriter("UserConverted.txt"))
                {
                    foreach (Person person in json)
                    {
                        sw.WriteLine($"{person.Id};{person.CreatedAt};{person.Country};{person.FullName};{person.Email}");
                    }

                    sw.WriteLine($"{json.Count}|{DateTimeToString(minTimeCreateAccaunt)}@{DateTimeToString(maxTimeCreateAccaunt)}");
                }
            }
        }

        private static string DateTimeToString(DateTime dateTime)
        {
            return $"{dateTime.Day}.{dateTime.Month}.{dateTime.Year} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
        }

        /*
        Будет вторым плюсом, если будет выполнено следующее:

        Вывести пользователю отсортированные по имени категории сгруппированные по родительской категории.
        */
        private static async Task Test4()
        {
            var workWeb = new WorkWeb();
            var list = await workWeb.GetCategoriesAsync();

            var groups = list.ListCategories.GroupBy(x => x.Parent);

            foreach (var group in groups)
            {
                if (group.Key != 0)
                {
                    var temp = list.ListCategories.First(x => x.Id == group.Key);
                    Console.WriteLine($"{temp.Name}:");
                    foreach (var category in group)
                    {
                        if (category.Name != temp.Name)
                            Console.WriteLine($"    {category.Name}");
                    }
                }
            }
        }
    }
}
