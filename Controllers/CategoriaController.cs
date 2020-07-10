using System.Collections.Generic;
using System.Threading.Tasks;
using lxwebapijwt.Interfaces;
using lxwebapijwt.Models;
using lxwebapijwt.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lxwebapijwt.Controllers
{
    [ApiController]
    [Route("v1/categoria")]
    public class CategoriaController : ControllerBase
    {
        ICategoriaRepository _repository;
        public CategoriaController(ICategoriaRepository CategoriaRepository)
        {
            _repository = CategoriaRepository;
        } 

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await Task.Run(() => _repository.Obter());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Categoria>> GetById(long id)
        {
            if(id > 0)
            {
                var res = await _repository.ObterPorId(id);
                if(res == null) return NotFound();
                return res;
            } 
            else
            {
                return BadRequest(new { message = "Id Inválido"});
            }
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                return await _repository.Adicionar(categoria);
            } else {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> Put(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                return await _repository.Alterar(categoria);
            } else {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(Categoria categoria)
        {
            if(categoria.Id > 0)
            {
                return await _repository.Excluir(categoria.Id);
            } 
            else
            {
                return BadRequest(new { message = "Categoria Inválida"});
            }
        }
    }
}