using lxwebapijwt.Interfaces;
using lxwebapijwt.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace lxwebapijwt.Ioc
{
    public static class InjectDep
    {
        public static void AdicionarIoc(IServiceCollection services)
        {
            //services.AddScoped<IBaseRepository
            services.AddScoped<ILocalRepository, LocalRepository>();

            services.AddScoped<ICursoRepository, CursoRepository>();
            
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            

        }
        
    }
}