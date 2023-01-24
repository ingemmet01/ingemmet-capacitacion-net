using System;

namespace Ingemmet.FirmaDocumento.Infrastructure.Helpers
{
    public class Moneda
    {
        public Moneda()
        {
            Nombre = "Sol(es)";
            Centimos = "Céntimo(s)";
            Preposicion = "con";
        }

        /// <summary>
        /// Nombre de la Moneda (Singular)
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Nombre de los Céntimos
        /// </summary>
        public string Centimos { get; set; }

        /// <summary>
        /// Preposición entre Moneda y Céntimos
        /// </summary>
        public string Preposicion { get; set; }
        public string Literal { get; set; }

    }

    public class NumberSpan : Moneda
    {
        private readonly decimal maxValue = 1999999999.99M;
        private static readonly string[] unidades = { "", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve", "Diez", "Once", "Doce", "Trece", "Catorce", "Quince", "Dieciséis", "Diecisiete", "Dieciocho", "Diecinueve", "Veinte", "Veintiuno", "Veintidos", "Veintitres", "Veinticuatro", "Veinticinco", "Veintiseis", "Veintisiete", "Veintiocho", "Veintinueve" };
        private static readonly string[] decenas = { "", "Diez", "Veinte", "Treinta", "Cuarenta", "Cincuenta", "Sesenta", "Setenta", "Ochenta", "Noventa", "Cien" };
        private static readonly string[] centenas = { "", "Ciento", "Doscientos", "Trescientos", "Cuatrocientos", "Quinientos", "Seiscientos", "Setecientos", "Ochocientos", "Novecientos" };

        public NumberSpan(long value)
        {
            Literal = ToText(value);
        }

        /// <summary>
        /// Convierte valores monetarios a letras. 
        /// </summary>
        /// <param name="valor">Valor monetario</param>
        /// <param name="decimalesEnLetras">Convierte la parte decimal a letras</param>
        public NumberSpan(decimal valor, bool decimalesEnLetras = false)
        {
            if (valor < 0)
                Literal = $"El número es negativo: {valor}";
            else if (valor > maxValue)
                Literal = $"El número esta fuera del rango; valor máximo permitido: {maxValue}";
            else
            {
                Int64 amount = Convert.ToInt64(valor);
                string amountText = CommonHelper.GetTextInPluralOrSingular(amount, Nombre);

                // Obtenemos la parte decimal y lo transformamos a entera
                int decPlaces = (int)((valor % 1) * 100);

                string decimalText = decimalesEnLetras
                    ? $"{ToText(decPlaces)} {CommonHelper.GetTextInPluralOrSingular(decPlaces, Centimos)}"
                    : decPlaces.ToString().PadLeft(2, '0') + "/100";

                decimalText = $"{Preposicion} {decimalText}";

                Literal = decimalesEnLetras ? $"{ToText(amount)} {amountText} {decimalText}"
                    : $"{ToText(amount)} {decimalText} {amountText}";
            }
        }

        /// <summary>
        /// Combierte el número en letras
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToText(long value)
        {
            return value == 0 ? "Cero" :
                value < 30 ? unidades[value] :
                value < 101 ? decenas[Convert.ToInt32(value / 10)] + (value % 10 != 0 ? $" y {ToText(value % 10)}" : "") :
                value < 1000 ? centenas[Convert.ToInt32(value / 100)] + (value % 100 != 0 ? $" {ToText(value % 100)}" : "") :
                value < 2000 ? "Mil" + (value % 1000 != 0 ? $" {ToText(value % 1000)}" : "") :
                value < 1000000 ? ToText(Convert.ToInt32(value / 1000)) + " Mil" + (value % 1000 != 0 ? $" {ToText(value % 1000)}" : "") :
                value < 2000000 ? "Un Millón" + (value % 1000000 != 0 ? $" {ToText(value % 1000000)}" : "") :
                value < 2000000000 ? ToText(Convert.ToInt32(value / 1000000)) + " Millones" + (value % 1000000 != 0 ? $" {ToText(value % 1000000)}" : "") : "";
        }

        public override string ToString()
        {
            return Literal.ToString();
        }
    }
}
