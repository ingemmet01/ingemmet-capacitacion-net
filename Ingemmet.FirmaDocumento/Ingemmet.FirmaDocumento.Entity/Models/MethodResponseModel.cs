using Ingemmet.FlujoDocMineral.Entity.Models;
using System.Net;

namespace Ingemmet.FirmaDocumento.Entity.Models
{
    public class MethodResponseModel<T>
    {
        public MethodResponseModel()
        {
            Code = (int)HttpStatusCode.OK;
        }

        public MethodResponseModel(MessageEnum message)
        {
            Code = message.Equals(MessageEnum.Error) ? (short)HttpStatusCode.InternalServerError
                : message.Equals(MessageEnum.Success) ? (short)HttpStatusCode.OK
                : (short)HttpStatusCode.BadRequest;
            Message = new MessageResponseModel(message).ToString();
        }

        public MethodResponseModel(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public MethodResponseModel(HttpStatusCode statusCode, string message = null)
        {
            Code = (short)statusCode;
            Message = message;
        }

        public MethodResponseModel(HttpStatusCode code, MessageEnum message)
        {
            Code = (short)code;
            Message = new MessageResponseModel(message).ToString();
        }

        public int Code { get; set; }
        public object OtherCode { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public bool IsSuccess => Code == (int)HttpStatusCode.OK;
        public string Priority => Code == (int)HttpStatusCode.BadRequest ? "warning"
            : Code == (int)HttpStatusCode.InternalServerError ? "danger"
            : Code == (int)HttpStatusCode.OK ? "success" : "warning";
    }
}
