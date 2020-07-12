using System.Collections.Generic;
using System.Threading.Tasks;
using lxwebapijwt.Interfaces;
using lxwebapijwt.Models;
using lxwebapijwt.Repositories;
using lxwebapijwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lxwebapijwt.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/curso")]
    public class CursoController : ControllerBase
    {
        ICursoRepository _repository;
        public CursoController(ICursoRepository CursoRepository)
        {
            _repository = CursoRepository;
        } 

        [HttpGet]
        public async Task<ActionResult<List<Curso>>> Get()
        {
            return await Task.Run(() => _repository.Obter());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Curso>> GetById(long id)
        {
            if(id > 0)
            {
                var res = await _repository.ObterPorId(id);
                if(res == null) return NotFound();
                return res;
            } else {
                return BadRequest(new { message = "Id Inválido"});
            }
        }

        [HttpPost]
        [ClaimsAuthorize("Curso", "Incluir")]
        public async Task<ActionResult<Curso>> Post(Curso curso)
        {
            if(ModelState.IsValid)
            {
                return await _repository.Adicionar(curso);
            } else {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [ClaimsAuthorize("Curso", "Alterar")]
        public async Task<ActionResult<Curso>> Put(Curso curso)
        {
            if(ModelState.IsValid)
            {
                return await _repository.Alterar(curso);
            } else {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [ClaimsAuthorize("Curso", "Excluir")]
        public async Task<ActionResult<int>> Delete(Curso curso)
        {
            if(curso.Id > 0)
            {
                return await _repository.Excluir(curso.Id);
            } else {
                return BadRequest(new { message = "Curso Inválido"});
            }
        }
    }
}