namespace External.TaxpayersAPI.Exceptions
{
    public class ApiException : ExceptionBase
    {
        public override string Code => _code;
        private readonly string _code;

        public ApiException(string code, string message) :
            base(message)
        {
            _code = code;
        }
    }
}