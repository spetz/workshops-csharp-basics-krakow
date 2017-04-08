using System;

namespace Source.Services
{
    public interface IActionHandler
    {
         Result<T> Handle<T>(Func<T> func);
    }

    public class ActionHandler : IActionHandler
    {
        public Result<T> Handle<T>(Func<T> func)
        {
            try
            {
                var result = func();

                return Result<T>.Ok(result);
            }
            catch(Exception exception)
            {
                return Result<T>.Fail(exception.Message);
            }
        }
    }
}