using Ass1.DTOs;
using Ass1.Models;
using Ass1.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ass1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        private readonly IGoodRepository _repository;
        private readonly IMapper _mapper;

        public GoodController(IGoodRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoodDTO>>> GetAll()
        {
            var goods = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GoodDTO>>(goods));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoodDTO>> GetById(string id)
        {
            var hangHoa = await _repository.GetByIdAsync(id);
            if (hangHoa == null) return NotFound();
            return Ok(_mapper.Map<GoodDTO>(hangHoa));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] GoodDTO hangHoaDTO)
        {
            var hangHoa = _mapper.Map<Good>(hangHoaDTO);
            await _repository.AddAsync(hangHoa);
            return CreatedAtAction(nameof(GetById), new { id = hangHoa.MaHangHoa }, hangHoaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] GoodDTO hangHoaDTO)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(hangHoaDTO, existing);
            await _repository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
