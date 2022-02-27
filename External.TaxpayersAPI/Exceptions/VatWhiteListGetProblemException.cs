namespace External.TaxpayersAPI.Exceptions
{
    public class VatWhiteListGetProblemException : ExceptionBase
    {
        public override string Code => "vat_white_list_get_problem";

        public VatWhiteListGetProblemException(string message) :
            base(message)
        { 
        }
    }
}