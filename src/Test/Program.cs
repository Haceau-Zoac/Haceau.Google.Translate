using Haceau.Google.Translate;
using System;
using System.Net.Http;

namespace Haceau.Gooogle.Translate.Test
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static void Main()
        {
            Translation t = new Translation(client);

            Console.WriteLine("zh-CN to en");
            Console.WriteLine($"你妈炸了 - {t.Translate("你妈炸了")}");

            t.TargetLanguage = "ja";

            Console.WriteLine("zh-CN to ja");
            Console.WriteLine($"测试一下 - {t.Translate("测试一下")}");

            t.SourceLanguage = "auto";
            t.TargetLanguage = "ht";

            Console.WriteLine("auto（自动猜测） to ht");
            Console.WriteLine($"テストを受ける - {t.Translate("テストを受ける")}");
        }
    }
}
