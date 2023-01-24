using System.Net.Mail;

namespace Ingemmet.FirmaDocumento.Entity.Models
{
    public class MailAddressModel : MailAddress
    {
        public MailAddressModel(string address)
            : base(address)
        {
            To = "To";
        }

        public MailAddressModel(string address, string displayName)
            : base(address, displayName)
        {
            To = "To";
        }

        public string To { get; set; }
    }

    public class MailingModel<T>
    {
        public bool IsLogoBase64 { get; set; }
        public string Title { get; set; }
        public string CodeVerify { get; set; }
        public string RenderBody { get; set; }
        public string Info { get; set; }
        public string TemplateName { get; set; }
        public string PathTemplate { get; set; }
        public T Body { get; set; }
    }
}
