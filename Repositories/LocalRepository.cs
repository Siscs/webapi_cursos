using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lxwebapijwt.Data;
using lxwebapijwt.Interfaces;
using lxwebapijwt.Models;
using Microsoft.EntityFrameworkCore;

namespace lxwebapijwt.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        DataContext _dataContext;
        public LocalRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Local>> Obter()
        {

            return await _dataContext.Locais.ToListAsync();

        }

        public async Task<Local> ObterPorId(long id)
        {
            return await _dataContext.Locais.FindAsync(id);
        }

        public async Task<Local> Adicionar(Local local)
        {
            _dataContext.Locais.Add(local);

            await _dataContext.SaveChangesAsync();

            return local;
        }

        public async Task<Local> Alterar(Local local)
        {
            _dataContext.Locais.Attach(local).State = EntityState.Modified;

            await _dataContext.SaveChangesAsync();

            return local;
        }
        
        public async Task<int> Excluir(long id)
        {

            var registro =  await _dataContext.Locais.FindAsync(id);

            if(registro != null) _dataContext.Locais.Remove(registro);

            return await _dataContext.SaveChangesAsync();
        }

    }
}