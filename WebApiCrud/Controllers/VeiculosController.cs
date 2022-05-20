using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCrud.Data;
using WebApiCrud.DTO;
using WebApiCrud.Entities;

namespace WebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly WebApiCrudContext _context;

        public VeiculosController(WebApiCrudContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var veiculos = _context.Veiculos.ToList();
            var veiculosDTO = veiculos.Select(x => new VeiculoDTO
            {
                VeiculoId = x.VeiculoId,
                Placa = x.Placa,
                AnoFabricacao = x.AnoFabricacao
            });
            return Ok(veiculosDTO);
        }

        [HttpPost]
        public IActionResult Insert(VeiculoDTO veiculoDTO)
        {
            var veiculo = new Veiculo
            {
                Placa = veiculoDTO.Placa,
                AnoFabricacao = veiculoDTO.AnoFabricacao
            };
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
            veiculoDTO.VeiculoId = veiculo.VeiculoId;
            return Ok(veiculoDTO);
        }

        [HttpPut]
        public IActionResult Update(VeiculoDTO veiculoDTO)
        {
            var VeiculoUpdate = _context.Veiculos.FirstOrDefault(x => x.VeiculoId == veiculoDTO.VeiculoId);
            if (VeiculoUpdate == null)
                return NotFound();

           VeiculoUpdate.Placa = veiculoDTO.Placa;
            VeiculoUpdate.Marca = veiculoDTO.Marca;
            VeiculoUpdate.AnoFabricacao = veiculoDTO.AnoFabricacao;

            _context.Veiculos.Update(VeiculoUpdate);
            _context.SaveChanges();
            return Ok(veiculoDTO);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var veiculo = _context.Veiculos.Find(id);
            if (veiculo == null)
                return NotFound();

            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();
            return Ok("Veiculo " + id + " excluído com sucesso!");
        }

        [HttpGet("GetById", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var veiculo = _context.Veiculos.Find(id);
            if (veiculo == null)
                return NotFound();

            var veiculoDTO = new VeiculoDTO
            {
                VeiculoId = veiculo.VeiculoId,
                Placa = veiculo.Placa,
                AnoFabricacao = veiculo.AnoFabricacao
            };

            return Ok(veiculoDTO);
        }
    }
}
