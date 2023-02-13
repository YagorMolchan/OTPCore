using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using OTPCore.DAL.Interfaces;
using OTPCore.BLL.DTO;
using OTPCore.DAL.Entities;

namespace OTPCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOTPUnitOfWork _unitOfWork;

        public PositionsController(IMapper mapper, IOTPUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<List<PositionDTO>> GetPositions()
        {
            var positions = _unitOfWork.Positions.GetAll();
            return Ok(_mapper.Map<List<PositionDTO>>(positions));
        }

        [HttpGet("{id}")]
        public ActionResult<PositionDTO> GetPosition(int id)
        {
            var position = _unitOfWork.Positions.Get(id);

            if (position == null)
            {
                return NotFound("The position with the Id " + id + " does not exist");
            }

            var positionDTO = _mapper.Map<PositionDTO>(position);
            return Ok(positionDTO);
        }

        [HttpPost]
        public ActionResult PostPosition([FromBody] PositionDTO positionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var position = _mapper.Map<Position>(positionDTO);
            _unitOfWork.Positions.Create(position);
            _unitOfWork.Save();
            return CreatedAtAction("GetPosition", new { id = position.Id }, position);
        }

        [HttpPut("{id}")]
        public ActionResult PutPosition(int id, [FromBody] PositionDTO positionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != positionDTO.Id)
            {
                return BadRequest("The value of Id must not be changed");
            }

            var position = _mapper.Map<Position>(positionDTO);            
            _unitOfWork.Positions.Update(position);
            _unitOfWork.Save();
            return Ok(position);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePosition(int id)
        {
            var position = _unitOfWork.Positions.Get(id);
            if (position == null)
            {
                return NotFound("The position with the Id " + id + " does not exist");
            }
            if (position.Employees.Count > 0)
            {
                return BadRequest("Deleting positions to which employees are attached is forbidden");
            }

            _unitOfWork.Positions.Delete(position);
            _unitOfWork.Save();
            return NoContent();
        }



    }
}
