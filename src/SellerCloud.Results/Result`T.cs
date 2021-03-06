﻿namespace SellerCloud.Results
{
    public class Result<T> : Result
        where T : class
    {
        internal Result(T data)
        {
            this.Data = data;
        }

        internal Result(string message, string? source = null)
            : base(message, source)
        {
            this.Data = default!;
        }

        public T Data { get; }
    }
}
