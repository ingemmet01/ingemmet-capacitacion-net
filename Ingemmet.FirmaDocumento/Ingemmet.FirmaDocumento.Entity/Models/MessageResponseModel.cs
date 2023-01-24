namespace Ingemmet.FlujoDocMineral.Entity.Models
{
    public enum MessageEnum
    {
        Success = 1,
        Error = 3,
        None,
        BadRequest,
        ErrorWhenValidatingCode,
        InvalidCode,
        NotEnoughFunds,
        PENOutOfRange,
        USDOutOfRange,
        ExchangeRequestNotFound,
        ExchangeRequestHasExpired,
        RefundNotAllowed,
        InternalPlatformMessage,
        EmailNotSend,
        ValidatedEmail,
        CodeSentSuccessfully,
        InvalidParameters,
        InvalidCaptcha,
        NotFound,
        TokenIsNotValid,
        ExpiredCode,
        AuthenticatedUser,
        RedirectingTheAuthenticatedUser
    }

    public class MessageResponseModel
    {
        public string Description { get; set; }
        public MessageEnum Message { get; set; }

        public MessageResponseModel()
        {

        }

        public MessageResponseModel(MessageEnum message)
        {
            Message = message;

            Description = Message == MessageEnum.Error ? "Lo sentimos. Se ha producido un Error y no hemos podido procesar su solicitud."
              : Message == MessageEnum.Success ? "Se ha procesado con éxito su petición."
              : Message == MessageEnum.ErrorWhenValidatingCode ? "Lo sentimos. No se pudo validar el código proporcionado."
              : Message == MessageEnum.InvalidCode ? "Código invalido. Por favor, verifique su código y vuelva a intentarlo."
              : Message == MessageEnum.BadRequest ? "Lo sentimos. No se ha podido procesar su petición, por favor verifique los datos proporcionados."
              : Message == MessageEnum.EmailNotSend ? "Lo sentimos. No se ha podido realizar el envió del correo, por favor verifique que el correo electrónico de destino sea válido."
              : Message == MessageEnum.ValidatedEmail ? "La cuenta de correo electrónico ya ha sido validado."
              : Message == MessageEnum.CodeSentSuccessfully ? "Se ha enviado con éxito el código de verificación."
              : Message == MessageEnum.InvalidParameters ? "Los parámetros enviados no son válidos."
              : Message == MessageEnum.InvalidCaptcha ? "Captcha invalido. Por favor, verifique su código y vuelva a intentarlo."
              : Message == MessageEnum.NotFound ? "No se ha encontrado registros con los parametros solicitados"
              : message == MessageEnum.TokenIsNotValid ? "El Token no es válido"
              : message == MessageEnum.ExpiredCode ? "Código expirado. Por favor, verifique su código y vuelva a intentarlo."
              : message == MessageEnum.AuthenticatedUser ? "Se realizó con éxito la autorización."
              : message == MessageEnum.RedirectingTheAuthenticatedUser ? "Se realizó con éxito la autorización, espere mientras lo redirigimos a la web."
            : "No hay mensajes";
        }

        public string GetMessage(MessageEnum message)
        {
            return new MessageResponseModel(message).ToString();
        }

        public string GetMessage()
        {
            return new MessageResponseModel(Message).ToString();
        }

        public override string ToString()
        {
            return Description;
        }
    }
}