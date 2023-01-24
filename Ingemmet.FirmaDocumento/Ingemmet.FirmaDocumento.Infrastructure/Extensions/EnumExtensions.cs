using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Ingemmet.FirmaDocumento.Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        #region Utilities

        private static DisplayAttribute GetDisplayAttribute(object value)
        {
            Type type = value.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException(string.Format("Type {0} is not an enum", type));
            }

            // Get the enum field.
            var field = type.GetField(value.ToString());
            return field == null ? null : field.GetCustomAttribute<DisplayAttribute>();
        }

        #endregion

        /// <summary>
        /// Get Description <see cref="Enum"/>
        /// </summary>
        /// <param name="enu"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enu)
        {
            Type genericEnumType = enu.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(enu.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return enu.ToString();
        }

        /// <summary>
        /// Get Display Name <see cref="Enum"/>
        /// </summary>
        /// <param name="enu"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enu)
        {
            var attr = GetDisplayAttribute(enu);
            return attr != null && attr.Name != null ? attr.Name : enu.ToString();
        }

        /// <summary>
        /// Obtener el total de atributos de un <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="soure"></param>
        /// <returns></returns>
        public static int Count<T>() where T : IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return Enum.GetNames(typeof(T)).Length;
        }

        /// <summary>
        /// Obtiene el valor numérico del <see cref="Enum"/> y lo convierte a <see cref="string"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="soure"></param>
        /// <returns></returns>
        public static string GetValueToString(this Enum enu)
            => ((int)(IConvertible)enu).ToString();

        /// <summary>
        /// Obtiene el valor numérico del <see cref="Enum"/>
        /// </summary>
        /// <param name="enu"></param>
        /// <returns></returns>
        public static int ToInt(this Enum enu)
            => (int)(IConvertible)enu;

        /// <summary>
        /// Convert string to <see cref="Enum"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumString"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string enumString)
        {
            return (T)Enum.Parse(typeof(T), enumString);
        }

        /// <summary>
        /// Get ShortName <see cref="Enum"/>
        /// </summary>
        /// <param name="enu"></param>
        /// <returns></returns>
        public static string GetShortName(this Enum enu)
        {
            var attr = GetDisplayAttribute(enu);
            return attr != null && attr.ShortName != null ? attr.ShortName : enu.ToString();
        }

        /// <summary>
        /// Returns a new string that right-aligns the characters in this instance by padding
        /// them on the left with a specified Unicode character, for a specified total length.
        /// </summary>
        /// <param name="enu"></param>
        /// <param name="totalWidth"></param>
        /// <param name="paddingChar"></param>
        /// <returns></returns>
        public static string PadLeft(this Enum enu, int totalWidth, char paddingChar = '0')
        {
            var attr = GetDisplayAttribute(enu);
            return ((int)(IConvertible)enu).ToString().PadLeft(2, '0');
        }
    }
}
