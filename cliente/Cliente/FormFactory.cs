using Microsoft.Extensions.DependencyInjection;


namespace Cliente
{
    public class FormFactory : IFormFactory
    {
        private readonly IServiceScope _scope;

        public FormFactory(IServiceScopeFactory scopeFactory)
        {
            _scope = scopeFactory.CreateScope();
        }

        public T? Create<T>() where T : IFormBase
        {
            return _scope.ServiceProvider.GetService<T>();
        }

        public T? GetService<T>() where T : class
        {
            return _scope.ServiceProvider.GetService<T>();
        }
    }
}
