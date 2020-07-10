using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lxwebapijwt.Data;
using lxwebapijwt.Interfaces;
using lxwebapijwt.Models;
using Microsoft.EntityFrameworkCore;

namespace lxwebapijwt.Repositories
{
    
    public class CategoriaRepository : ICategoriaRepository
    {
        DataContext _dataContext;
        public CategoriaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Categoria>> Obter()
        {
            return  await _dataContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> ObterPorId(long id)
        {
            return await _dataContext.Categorias.FindAsync(id);
        }

        public async Task<Categoria> Adicionar(Categoria categoria)
        {
            _dataContext.Categorias.Add(categoria);

            await _dataContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria> Alterar(Categoria categoria)
        {
            _dataContext.Categorias.Attach(categoria).State = EntityState.Modified;

            await _dataContext.SaveChangesAsync();

            return categoria;
        }
        
        public async Task<int> Excluir(long id)
        {
            var registro =  await _dataContext.Categorias.FindAsync(id);

            if(registro != null) _dataContext.Categorias.Remove(registro);

            return await _dataContext.SaveChangesAsync();
        }
    }
}