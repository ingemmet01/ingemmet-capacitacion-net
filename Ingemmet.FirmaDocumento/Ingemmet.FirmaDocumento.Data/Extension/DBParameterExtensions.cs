using Newtonsoft.Json;

namespace System.Data.Common
{
    public static class DbParameterExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetValueOrDefault<T>(this object value)
        {
            if (value == DBNull.Value || value == null)
            {
                if (typeof(T).IsValueType)
                    return (T)Activator.CreateInstance(typeof(T));

                return (default);
            }

            return JsonConvert.DeserializeObject<T>(value.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static T GetValueOrDefault<T>(this DbParameter parameter)
            => parameter.Value.GetValueOrDefault<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="colum"></param>
        /// <returns></returns>
        public static T GetValueOrDefault<T>(this DbCommand command, string colum)
            => command.Parameters[colum].GetValueOrDefault<T>();
    }
}
