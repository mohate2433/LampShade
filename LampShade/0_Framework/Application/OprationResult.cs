namespace _0_Framework.Application
{
    public class OprationResult
    {
        public string Message { get; set; }
        public bool IsSuccedd { get; set; }

        public OprationResult()
        {
            IsSuccedd = false;
        }

        public OprationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccedd = true;
            Message = message;
            return this;
        }
        public OprationResult Failed(string message)
        {
            IsSuccedd = false;
            Message = message;
            return this;
        }
    }
}
