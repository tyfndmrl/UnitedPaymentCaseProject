using System.Net;

namespace UnitedPayment.DTO.Models.Results
{
    public class ResponseModel
    {
        public ResponseModel() { }

        public ResponseModel(bool success)
        {
            Success = success;
        }

        public ErrorModel Error { get; set; }
        public bool Success { get; set; }
    }

    public class ResponseModel<T> : ResponseModel
    {
        public T Data { get; set; }
        public new bool Success => (Error == null);
    }

    public class ErrorModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<FieldModel> Fields { get; set; }
    }

    public class FieldModel
    {
        public string Field { get; set; }
        public string[] Message { get; set; }
    }
}
