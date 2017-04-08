namespace Source
{
    public class Result<T>
    {
        public T Item { get; }
        public string ErrorMessage { get; }
        public bool IsValid 
            => string.IsNullOrWhiteSpace(ErrorMessage);

        protected Result(T item)
        {
            Item = item;
        }

        protected Result(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public static Result<T> Ok(T item)
            => new Result<T>(item); 

        public static Result<T> Fail(string errorMessage)
            => new Result<T>(errorMessage);                     
    }
}