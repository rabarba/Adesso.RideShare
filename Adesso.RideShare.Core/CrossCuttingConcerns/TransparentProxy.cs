using CacheManager.Core;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Adesso.RideShare.Core.CrossCuttingConcerns
{
    public class TransparentProxy<T> : DispatchProxyAsync
    {
        private T _decorated;
        private ICacheManager<object> _cacheManager;

        public override object Invoke(MethodInfo method, object[] args)
        {
            throw new NotImplementedException();
        }

        public override Task InvokeAsync(MethodInfo method, object[] args)
        {
            throw new NotImplementedException();
        }

        public override Task<TResult> InvokeAsyncT<TResult>(MethodInfo method, object[] args)
        {
            dynamic arg = args[0];
            var aspects = method.GetCustomAttributes(typeof(IAspect), true);

            var result = method.Invoke(_decorated, args);
            var taskValue = CheckAndGetTaskValue(result);

            return (Task<TResult>)result;
        }

        public static T Create(T decorated)
        {
            object proxy = Create<T, TransparentProxy<T>>();
            ((TransparentProxy<T>)proxy).SetParameters(decorated);

            return (T)proxy;
        }

        public static T Create(T decorated, ICacheManager<object> cacheManager)
        {
            object proxy = Create<T, TransparentProxy<T>>();
            ((TransparentProxy<T>)proxy).SetParameters(decorated, cacheManager);

            return (T)proxy;
        }
        private void SetParameters(T decorated)
        {
            _decorated = decorated;
        }

        private void SetParameters(T decorated, ICacheManager<object>  cacheManager)
        {
            _decorated = decorated;
            _cacheManager = cacheManager;
        }

        private dynamic CheckAndGetTaskValue(object result)
        {
            if (!(result is Task taskResult)) return result;

            Task.WaitAll(taskResult);
            var property = taskResult.GetType().GetTypeInfo().GetProperties().FirstOrDefault(p => p.Name == "Result");

            return property.GetValue(taskResult);
        }
    }
}
