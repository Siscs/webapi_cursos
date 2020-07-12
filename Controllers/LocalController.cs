using System.Collections.Generic;
using System.Threading.Tasks;
using lxwebapijwt.Interfaces;
using lxwebapijwt.Models;
using lxwebapijwt.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lxwebapijwt.Controllers
{
    [ApiController]
    [Route("v1/local")]
    [Authorize]
    public class LocalController : ControllerBase
    {
        ILocalRepository _repository;
        public LocalController(ILocalRepository localRepository)
        {
            _repository = localRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Local>>> Get()
        {
            return await Task.Run(() => _repository.Obter());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Local>> GetById(long id)
        {
            if (id > 0)
            {
                var res = await _repository.ObterPorId(id);
                if (res == null) return NotFound();
                return res;
            }
            else
            {
                return BadRequest(new { message = "Id Inválido" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Local>> Post(Local local)
        {
            return await _repository.Adicionar(local);
        }

        [HttpPut]
        public async Task<ActionResult<Local>> Put(Local local)
        {
            return await _repository.Alterar(local);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(Local local)
        {
            if (local.Id > 0)
            {
                return await _repository.Excluir(local.Id);
            }
            else
            {
                return BadRequest(new { message = "Local Inválido" });
            }
        }
    }
}