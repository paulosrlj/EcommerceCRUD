namespace EcommerceCRUD.Models.DTO.Output
{
    public class ResponseObject
    {
        public int Status { get; set; }

        public Object Data { get; set; }

        public ResponseObject(int status, Object data) 
        { 
            Status = status;
            Data = data;
        }
    }
}
