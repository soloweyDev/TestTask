using System.Threading.Tasks;

namespace TestTask
{
    class Program
    {
        static async Task Main()
        {
            await Test1();
            await Test2();
            Test3();
            Test4();
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
            throw new System.NotImplementedException();
        }

        /*
        Будет вторым плюсом, если будет выполнено следующее:

        Вывести пользователю отсортированные по имени категории сгруппированные по родительской категории.
        */
        private static void Test4()
        {
            throw new System.NotImplementedException();
        }
    }
}
