using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Ingemmet.FirmaDocumento.Infrastructure.Extensions
{
    public static class CommonExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="lengthExpected"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int lengthExpected, string separator = "...")
        {
            return value.Length > lengthExpected ? $"{value.Substring(0, lengthExpected)}{separator}" : value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="compareValues"></param>
        /// <returns></returns>
        public static bool CompareMultiple(this string data, params string[] compareValues)
        {
            if (data == null) return false;

            foreach (string s in compareValues)
                if (data.Equals(s))
                    return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="compareType"></param>
        /// <param name="compareValues"></param>
        /// <returns></returns>
        public static bool CompareMultiple(this string data, StringComparison compareType, params string[] compareValues)
        {
            if (data == null) return false;

            foreach (string s in compareValues)
                if (data.Equals(s, compareType))
                    return true;
            return false;
        }

        /// <summary>
        /// Convierte una lista generica en <see cref="SelectListItem"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">Una collección de objetos que se usan para crear la lista enumerable.</param>
        /// <param name="value">Obtiene o establece el valor del elemento seleccionado.</param>
        /// <param name="text">Obtiene o establece el texto del elemento seleccionado.</param>
        /// <param name="defaultValue">Obtiene o establece un valor que indica si este objeto 
        /// <see cref="System.Web.Mvc.SelectListItem"/> está seleccionado.</param>
        /// <example>List<Object>.ToSelectList(x => x.Value, x => x.Description);</example>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> entities, Func<T, object> value,
                    Func<T, object> text, object defaultValue = null)
        {
            return entities.Select(x => new SelectListItem
            {
                Value = value(x).ToString(),
                Text = text(x).ToString(),
                Selected = value(x).Equals(defaultValue)
            });
        }

        /// <summary>
        /// Activa el menú según lo parámetros ingresados.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="defaultClass"></param>
        /// <returns></returns>
        public static string IsLinkActive(this UrlHelper url, string action, string controller, string defaultClass = "active")
        {
            if (url.RequestContext.RouteData.Values["controller"].ToString() == controller &&
                url.RequestContext.RouteData.Values["action"].ToString() == action)
                return defaultClass;
            return "";
        }

        /// <summary>
        /// Filtrar documentos por extesión de archivos
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="extensions"></param>
        /// <returns></returns>
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions)
        {
            if (extensions == null)
                throw new ArgumentNullException("extensions");

            var allowedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);

            return dir.EnumerateFiles().Where(f => allowedExtensions.Contains(f.Extension));
        }
    }
}
