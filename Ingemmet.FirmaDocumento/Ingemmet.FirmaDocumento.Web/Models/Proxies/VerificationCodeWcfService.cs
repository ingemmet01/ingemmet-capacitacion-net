//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ingemmet.ServiciosDigitales.Entity.Models.Security
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VerificationCodeRegisterModel", Namespace="http://schemas.datacontract.org/2004/07/Ingemmet.ServiciosDigitales.Entity.Models" +
        ".Security")]
    public partial class VerificationCodeRegisterModel : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string EmailField;
        
        private System.Nullable<short> LongitudCodigoField;
        
        private System.Nullable<int> MinutosExpiraField;
        
        private System.Nullable<long> NotificacionEmailIdField;
        
        private long SistemaIdField;
        
        private string TipoGeneracionField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> LongitudCodigo
        {
            get
            {
                return this.LongitudCodigoField;
            }
            set
            {
                this.LongitudCodigoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> MinutosExpira
        {
            get
            {
                return this.MinutosExpiraField;
            }
            set
            {
                this.MinutosExpiraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> NotificacionEmailId
        {
            get
            {
                return this.NotificacionEmailIdField;
            }
            set
            {
                this.NotificacionEmailIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long SistemaId
        {
            get
            {
                return this.SistemaIdField;
            }
            set
            {
                this.SistemaIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoGeneracion
        {
            get
            {
                return this.TipoGeneracionField;
            }
            set
            {
                this.TipoGeneracionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VerificationCodeModel", Namespace="http://schemas.datacontract.org/2004/07/Ingemmet.ServiciosDigitales.Entity.Models" +
        ".Security")]
    public partial class VerificationCodeModel : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string CodigoVerificacionField;
        
        private string EmailField;
        
        private short EstadoField;
        
        private System.DateTime FechaCreacionField;
        
        private System.Nullable<System.DateTime> FechaVigenciaField;
        
        private System.Nullable<System.DateTime> FechaverificacionField;
        
        private long IdField;
        
        private short LongitudCodigoField;
        
        private int MinutosExpiraField;
        
        private System.Nullable<long> NotificacionEmailIdField;
        
        private long SistemaIdField;
        
        private string TipoGeneracionField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodigoVerificacion
        {
            get
            {
                return this.CodigoVerificacionField;
            }
            set
            {
                this.CodigoVerificacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short Estado
        {
            get
            {
                return this.EstadoField;
            }
            set
            {
                this.EstadoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaCreacion
        {
            get
            {
                return this.FechaCreacionField;
            }
            set
            {
                this.FechaCreacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> FechaVigencia
        {
            get
            {
                return this.FechaVigenciaField;
            }
            set
            {
                this.FechaVigenciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Fechaverificacion
        {
            get
            {
                return this.FechaverificacionField;
            }
            set
            {
                this.FechaverificacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short LongitudCodigo
        {
            get
            {
                return this.LongitudCodigoField;
            }
            set
            {
                this.LongitudCodigoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MinutosExpira
        {
            get
            {
                return this.MinutosExpiraField;
            }
            set
            {
                this.MinutosExpiraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> NotificacionEmailId
        {
            get
            {
                return this.NotificacionEmailIdField;
            }
            set
            {
                this.NotificacionEmailIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long SistemaId
        {
            get
            {
                return this.SistemaIdField;
            }
            set
            {
                this.SistemaIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoGeneracion
        {
            get
            {
                return this.TipoGeneracionField;
            }
            set
            {
                this.TipoGeneracionField = value;
            }
        }
    }
}
namespace Ingemmet.ServiciosDigitales.WCF.Services.Security.Model
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VerificationCodeResponse", Namespace="http://schemas.datacontract.org/2004/07/Ingemmet.ServiciosDigitales.WCF.Services." +
        "Security.Model")]
    public partial class VerificationCodeResponse : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Ingemmet.ServiciosDigitales.Entity.Models.Security.VerificationCodeModel DataField;
        
        private Ingemmet.ServiciosDigitales.WCF.Model.MessageResponse StatusField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Ingemmet.ServiciosDigitales.Entity.Models.Security.VerificationCodeModel Data
        {
            get
            {
                return this.DataField;
            }
            set
            {
                this.DataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Ingemmet.ServiciosDigitales.WCF.Model.MessageResponse Status
        {
            get
            {
                return this.StatusField;
            }
            set
            {
                this.StatusField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VerificationCodeValidResponse", Namespace="http://schemas.datacontract.org/2004/07/Ingemmet.ServiciosDigitales.WCF.Services." +
        "Security.Model")]
    public partial class VerificationCodeValidResponse : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool IsValidField;
        
        private Ingemmet.ServiciosDigitales.WCF.Model.MessageResponse StatusField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsValid
        {
            get
            {
                return this.IsValidField;
            }
            set
            {
                this.IsValidField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Ingemmet.ServiciosDigitales.WCF.Model.MessageResponse Status
        {
            get
            {
                return this.StatusField;
            }
            set
            {
                this.StatusField = value;
            }
        }
    }
}
namespace Ingemmet.ServiciosDigitales.WCF.Model
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MessageResponse", Namespace="http://schemas.datacontract.org/2004/07/Ingemmet.ServiciosDigitales.WCF.Model")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeValidResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Ingemmet.ServiciosDigitales.Entity.Models.Security.VerificationCodeRegisterModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Ingemmet.ServiciosDigitales.Entity.Models.Security.VerificationCodeModel))]
    public partial class MessageResponse : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private short CodeField;
        
        private string MessageField;
        
        private object OtherCodeField;
        
        private bool SuccessField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short Code
        {
            get
            {
                return this.CodeField;
            }
            set
            {
                this.CodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object OtherCode
        {
            get
            {
                return this.OtherCodeField;
            }
            set
            {
                this.OtherCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success
        {
            get
            {
                return this.SuccessField;
            }
            set
            {
                this.SuccessField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IVerificationCodeWcfService")]
public interface IVerificationCodeWcfService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerificationCodeWcfService/Create", ReplyAction="http://tempuri.org/IVerificationCodeWcfService/CreateResponse")]
    Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse Create(Ingemmet.ServiciosDigitales.Entity.Models.Security.VerificationCodeRegisterModel verificationCode);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerificationCodeWcfService/Create", ReplyAction="http://tempuri.org/IVerificationCodeWcfService/CreateResponse")]
    System.Threading.Tasks.Task<Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse> CreateAsync(Ingemmet.ServiciosDigitales.Entity.Models.Security.VerificationCodeRegisterModel verificationCode);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerificationCodeWcfService/Close", ReplyAction="http://tempuri.org/IVerificationCodeWcfService/CloseResponse")]
    Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse Close(long id, string email, string code);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerificationCodeWcfService/Close", ReplyAction="http://tempuri.org/IVerificationCodeWcfService/CloseResponse")]
    System.Threading.Tasks.Task<Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse> CloseAsync(long id, string email, string code);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerificationCodeWcfService/GetById", ReplyAction="http://tempuri.org/IVerificationCodeWcfService/GetByIdResponse")]
    Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse GetById(long id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerificationCodeWcfService/GetById", ReplyAction="http://tempuri.org/IVerificationCodeWcfService/GetByIdResponse")]
    System.Threading.Tasks.Task<Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse> GetByIdAsync(long id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerificationCodeWcfService/Validate", ReplyAction="http://tempuri.org/IVerificationCodeWcfService/ValidateResponse")]
    Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeValidResponse Validate(long id, string email, string code);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVerificationCodeWcfService/Validate", ReplyAction="http://tempuri.org/IVerificationCodeWcfService/ValidateResponse")]
    System.Threading.Tasks.Task<Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeValidResponse> ValidateAsync(long id, string email, string code);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IVerificationCodeWcfServiceChannel : IVerificationCodeWcfService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class VerificationCodeWcfServiceClient : System.ServiceModel.ClientBase<IVerificationCodeWcfService>, IVerificationCodeWcfService
{
    
    public VerificationCodeWcfServiceClient()
    {
    }
    
    public VerificationCodeWcfServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public VerificationCodeWcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public VerificationCodeWcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public VerificationCodeWcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse Create(Ingemmet.ServiciosDigitales.Entity.Models.Security.VerificationCodeRegisterModel verificationCode)
    {
        return base.Channel.Create(verificationCode);
    }
    
    public System.Threading.Tasks.Task<Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse> CreateAsync(Ingemmet.ServiciosDigitales.Entity.Models.Security.VerificationCodeRegisterModel verificationCode)
    {
        return base.Channel.CreateAsync(verificationCode);
    }
    
    public Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse Close(long id, string email, string code)
    {
        return base.Channel.Close(id, email, code);
    }
    
    public System.Threading.Tasks.Task<Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse> CloseAsync(long id, string email, string code)
    {
        return base.Channel.CloseAsync(id, email, code);
    }
    
    public Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse GetById(long id)
    {
        return base.Channel.GetById(id);
    }
    
    public System.Threading.Tasks.Task<Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeResponse> GetByIdAsync(long id)
    {
        return base.Channel.GetByIdAsync(id);
    }
    
    public Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeValidResponse Validate(long id, string email, string code)
    {
        return base.Channel.Validate(id, email, code);
    }
    
    public System.Threading.Tasks.Task<Ingemmet.ServiciosDigitales.WCF.Services.Security.Model.VerificationCodeValidResponse> ValidateAsync(long id, string email, string code)
    {
        return base.Channel.ValidateAsync(id, email, code);
    }
}
