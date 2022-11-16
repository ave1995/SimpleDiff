namespace SimpleDiff.Models
{
    public sealed class Result
    {
        public bool Success { get; set; }
        public string Error { get; private set; }
        public bool IsFailure => !Success;

        public Result(bool succes, string error)
        {
            if (succes && error != string.Empty)
                throw new InvalidOperationException();
            if (!succes && error == string.Empty)
                throw new InvalidOperationException();
            Success = succes;
            Error = error;
        }

        public static Result Fail(string message) { return new Result(false, message); }
        public static Result OK() { return new Result(true, string.Empty); }
    }
}
