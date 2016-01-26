namespace Sunix.Lib.Strings
{
    /// <summary>
    /// JSON解析工具;
    /// </summary>
    public class Json
    {
        /// <summary>
        /// 将对象以字符串的形式打印出来;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string toString(object value)
        {
            return Jayrock.Json.Conversion.JsonConvert.ExportToString(value);
        }
    }
}
