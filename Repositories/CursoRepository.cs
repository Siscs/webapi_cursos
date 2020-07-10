using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lxwebapijwt.Data;
using lxwebapijwt.Interfaces;
using lxwebapijwt.Models;
using Microsoft.EntityFrameworkCore;

namespace lxwebapijwt.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        DataContext _dataContext;
        public CursoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Curso>> Obter()
        {

            return  await _dataContext.Cursos
                .Include(p => p.Categoria)
                .Include(x => x.Local)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Curso> ObterPorId(long id)
        {
            return await _dataContext.Cursos
                .Include(p => p.Categoria)
                .Include(x => x.Local)
                .AsNoTracking()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Curso> Adicionar(Curso curso)
        {
            _dataContext.Cursos.Add(curso);

            await _dataContext.SaveChangesAsync();

            return curso;
        }

        public async Task<Curso> Alterar(Curso curso)
        {
            _dataContext.Cursos.Attach(curso).State = EntityState.Modified;

            await _dataContext.SaveChangesAsync();

            return curso;
        }
        
        public async Task<int> Excluir(long id)
        {
            var registro =  await _dataContext.Cursos.FindAsync(id);

            if(registro != null) _dataContext.Cursos.Remove(registro);

            return await _dataContext.SaveChangesAsync();
        }
    }
}