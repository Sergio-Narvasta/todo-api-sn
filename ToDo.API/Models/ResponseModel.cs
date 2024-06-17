namespace ToDo.WebAPI.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }

    public class ResponseMessage
    {
        public const string RegisterSucess = "Se registro con exito";
        public const string UpdateSucess = "Se actualizo con exito";
        public const string DeleteSucess = "Se elimino con exito";
        public const string OperationError = "Ocurrio un error !";
    }
}
