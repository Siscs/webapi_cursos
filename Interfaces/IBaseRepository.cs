using System.Collections.Generic;
using System.Threading.Tasks;

namespace lxwebapijwt.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
         
        public Task<List<TEntity>> Obter();
        public Task<TEntity> ObterPorId(long id);
        public Task<TEntity> Adicionar(TEntity entity);
        public Task<TEntity> Alterar(TEntity entity);
        public Task<int> Excluir(long id);

    }
}