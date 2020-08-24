using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Haceau.Google.Translate
{
    /// <summary>
    /// 翻译接口
    /// </summary>
    public interface ITranslation
    {
        /// <summary>
        /// 源语言
        /// </summary>
        public string SourceLanguage
        {
            get;
            set;
        }

        /// <summary>
        /// 目标语言
        /// </summary>
        public string TargetLanguage
        {
            get;
            set;
        }

        /// <summary>
        /// 翻译
        /// </summary>
        /// <param name="message">翻译文本</param>
        /// <returns>翻译结果</returns>
        public string Translate(string message);
    }


    public class Translation : ITranslation
    {
        public HttpClient Client
        {
            get;
            set;
        }

        /// <summary>
        /// 源语言
        /// </summary>
        public string SourceLanguage
        {
            get;
            set;
        } = "zh-cn";

        /// <summary>
        /// 目标语言
        /// </summary>
        public string TargetLanguage
        {
            get;
            set;
        } = "en";

        public string Tkk
        {
            get
            {
                Web web = new Web("https://translate.google.cn/", Client);
                return Regex.Match(web.SendGetRequest(), @"(?<=TKK=')(.*?)(?=')").Value;
            }
        }

        /// <summary>
        /// 获取请求URL TK值的JAVASCRIPT函数代码
        /// </summary>
        private readonly string GET_TK_JAVASCRIPT_CODE = @"function token(a) {
                                var k = """";
                                var b = 406644;
                                var b1 = 3293161072;

                                var jd = ""."";
                                var sb = ""+-a^+6"";
                                var Zb = ""+-3^+b+-f"";

                                for (var e = [], f = 0, g = 0; g < a.length; g++) {
                                    var m = a.charCodeAt(g);
                                    128 > m ? e[f++] = m : (2048 > m ? e[f++] = m >> 6 | 192 : (55296 == (m & 64512) && g + 1 < a.length && 56320 == (a.charCodeAt(g + 1) & 64512) ? (m = 65536 + ((m & 1023) << 10) + (a.charCodeAt(++g) & 1023),
                                    e[f++] = m >> 18 | 240,
                                    e[f++] = m >> 12 & 63 | 128) : e[f++] = m >> 12 | 224,
                                    e[f++] = m >> 6 & 63 | 128),
                                    e[f++] = m & 63 | 128)
                                }
                                a = b;
                                for (f = 0; f < e.length; f++)
                                    a += e[f], 
                                a = RL(a, sb);
                                a = RL(a, Zb);
                                a ^= b1 || 0;
                                0 > a && (a = (a & 2147483647) + 2147483648);
                                a %= 1E6;
                                return a.toString() + jd + (a ^ b)
                            };
                            function RL(a, b) {
                                var t = ""a"";
                                var Yb = ""+"";
                                for (var c = 0; c < b.length - 2; c += 3) {
                                    var d = b.charAt(c + 2),
                                    d = d >= t ? d.charCodeAt(0) - 87 : Number(d),
                                    d = b.charAt(c + 1) == Yb ? a >>> d : a << d;
                                    a = b.charAt(c) == Yb ? a + d & 4294967295 : a ^ d
                                }
                                return a
                            }";

        /// <summary>
        /// 默认初始化
        /// </summary>
        public Translation(HttpClient client) =>
            Client = client;

        /// <summary>
        /// 使用语言进行初始化
        /// </summary>
        /// <param name="sourceLanguage">源语言</param>
        /// <param name="targetLanguage">目标语言</param>
        public Translation(string sourceLanguage, string targetLanguage, HttpClient client)
        {
            SourceLanguage = sourceLanguage;
            TargetLanguage = targetLanguage;
            Client = client;
        }

        /// <summary>
        /// 翻译
        /// </summary>
        /// <param name="message">翻译文本</param>
        /// <returns>翻译结果</returns>
        public string Translate(string message)
        {
            if (SourceLanguage == null || TargetLanguage == null)
                throw new Exception("属性SourceLanguage或TargetLanguage为空。");
            Web web = new Web(
                $"https://translate.google.cn/translate_a/single?client=webapp&sl={SourceLanguage}&tl={TargetLanguage}&hl=zh-CN&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=sos&dt=ss&dt=t&dt=gt&source=bh&ssel=0&tsel=0&xid=45662847&kc=1&tk={GetTk(message)}&q={message}",
                Client);
            string result = web.SendGetRequest();
            return result.Substring(4, (result.IndexOf("\"", 4 + 1) - 4));
        }

        /// <summary>
        /// 获取Tk值
        /// </summary>
        /// <param name="message">信息</param>
        /// <returns>Tk值</returns>
        public object GetTk(object message)
        {
            Script script = new Script();
            return script.Eval(GET_TK_JAVASCRIPT_CODE + $"token('{message}')");
        }
    }
}