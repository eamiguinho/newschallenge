using System;

namespace BBCChallenge.Core.Interfaces
{
    public class DataResult<T>
    {
        public T Data { get; private set; }
        public Result Result { get; private set; }
        public Exception Exception { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool IsOk { get { return Result == Result.Ok; } }

        public DataResult(T data)
        {
            Result = Result.Ok;
            Data = data;
        }

        public DataResult(Exception e)
        {
            Result = Result.Error;
            Exception = e;
        }

        public DataResult(string errorMessage)
        {
            Result = Result.Error;
            ErrorMessage = errorMessage;
        }

        public DataResult(Result result)
        {
            Result = result;
        }

    }

    public enum Result
    {
        Ok,
        Error,
        Unauthorized,
        NoInternetConnection
    }
}