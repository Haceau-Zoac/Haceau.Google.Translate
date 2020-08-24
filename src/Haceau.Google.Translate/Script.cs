using Jurassic;

namespace Haceau.Google.Translate
{
    /// <summary>
    /// 脚本
    /// </summary>
    internal class Script
    {
        /// <summary>
        /// 引擎
        /// </summary>
        ScriptEngine engine = new ScriptEngine();

        /// <summary>
        /// 表达式求值
        /// </summary>
        /// <param name="code">表达式</param>
        /// <returns>值</returns>
        public object Eval(string code) =>
            engine.Evaluate(code);
    }
}
