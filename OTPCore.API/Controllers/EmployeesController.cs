using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTPCore.BLL.DTO;
using OTPCore.DAL.Interfaces;
using AutoMapper;
using OTPCore.DAL.Entities;

namespace OTPCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOTPUnitOfWork _unitOfWork;

        public EmployeesController(IMapper mapper, IOTPUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<List<EmployeeDTO>> GetEmployees()
        {
            var employees = _unitOfWork.Employees.GetAll();
            return Ok(_mapper.Map<List<EmployeeDTO>>(employees));
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> GetEmployee(int id)
        {
            var employee = _unitOfWork.Employees.Get(id);

            if (employee == null)
            {
                return NotFound("The employee with the Id " + id + " does not exist");
            }

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }

        [HttpPost]
        public ActionResult PostEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _mapper.Map<Employee>(employeeDTO);
            _unitOfWork.Employees.Create(employee);
            _unitOfWork.Save();
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpPut("id")]
        public ActionResult PutEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != employeeDTO.Id)
            {
                return BadRequest("The value of Id must not be changed");
            }

            var employeeOld = _unitOfWork.Employees.Get(id);            
            _unitOfWork.Employees.Update(employeeOld);
            _unitOfWork.Save();
            return Ok(employeeOld);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _unitOfWork.Employees.Get(id);
            if (employee != null)
            {
                return NotFound("The employee with the Id " + id + " does not exist");
            }

            _unitOfWork.Employees.Delete(employee);
            _unitOfWork.Save();
            return NoContent();
        }

    }
}
