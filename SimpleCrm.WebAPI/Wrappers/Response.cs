namespace SimpleCrm.WebAPI.Wrappers
{ 
    public class Response<T> : Response
    {
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }

        #region Contructors
        public Response()
        { 
        }

        public Response(T data)
        {
            Data =
                data ?? throw new ArgumentException(nameof(data));

            Succeeded = true;
        }
        #endregion
    } 
    public class Response
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public Response()
        {
        }

        public Response(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }
}
