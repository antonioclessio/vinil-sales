namespace VinilSales.WebAPI.Models.Core
{
    public class ActionResultModel
    {
        public ActionResultModel(string message, object data)
        {
            this.Message = message;
            this.Data = data;
        }

        public string Message { get; set; }
        public object Data { get; set; }
    }
}
