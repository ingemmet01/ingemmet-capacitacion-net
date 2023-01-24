using System.IO;
using System.Net;
using System.Web;

namespace Ingemmet.FirmaDocumento.Infrastructure.Helpers
{
    public static class CommonHelper
    {
        /// <summary>
        /// Obtener IP.
        /// </summary>
        /// <returns></returns>
        public static string GetIP
        {
            get
            {
                string ClientIP, Forwaded, RealIP = string.Empty;
                try
                {
                    RealIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    ClientIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT-IP"];
                    if (!string.IsNullOrEmpty(ClientIP))
                    {
                        RealIP = ClientIP;
                    }
                    else
                    {
                        Forwaded = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X-Forwarded-For"];
                        if (!string.IsNullOrEmpty(Forwaded)) RealIP = Forwaded;
                        else
                        {
                            RealIP = System.Web.HttpContext.Current.Request.UserHostAddress.ToString().Trim();
                            if (RealIP.Length < 5)
                            {
                                string hostName = Dns.GetHostName();
                                IPAddress[] ips = Dns.GetHostEntry(hostName).AddressList;
                                RealIP = Dns.GetHostEntry(hostName).AddressList[ips.Length - 1].ToString();
                            }
                        }
                    }
                }
                finally { }
                return RealIP;
            }
        }

        /// <summary>
        /// Retorna el texto en plural o singular según el valor a consultar.
        /// </summary>
        /// <param name="valor">Valor númerico</param>
        /// <param name="text">Texto plural o singular ejemplo: Sol(es)</param>
        /// <param name="join">Unir el arreglo, caso contrario obtener el último valor.</param>
        /// <returns></returns>
        public static string GetTextInPluralOrSingular(long valor, string text, bool join = true)
        {
            string[] result = text.Split(new char[] { '(', ')' });

            if (valor == 1)
                return result[0];
            else if (join)
                return string.Join("", result);
            else
                return result[1];
        }

        /// <summary>
        /// Crea el directorio si no existe y retorna el path en un <see cref="string"/>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
    }
}
