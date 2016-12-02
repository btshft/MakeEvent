using System.Collections.Generic;

namespace MakeEvent.Common.Models
{
    public class OperationResult<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

    public class OperationResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public static OperationResult Success()
            => new OperationResult { Succeeded = true };

        public static OperationResult<T> Success<T>(T result)
            => new OperationResult<T> { Data = result, Succeeded = true };

        public static OperationResult Fail(params string[] errors)
            => new OperationResult { Errors = errors };

        public static OperationResult<T> Fail<T>(params string[] errors)
            => new OperationResult<T> { Errors = errors };
    }
}
