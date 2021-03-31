using ExamAPITrail.Models;
using ExamAPITrail.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAPITrail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IDataRepository<Examination> _dataRepository;
        public ExaminationController(IDataRepository<Examination> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Examination> examinations = _dataRepository.GetAll();
            return Ok(examinations);
        }
        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Examination examination = _dataRepository.Get(id);
            if (examination == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(examination);
        }
        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Examination examination)
        {
            if (examination == null)
            {
                return BadRequest("Employee is null.");
            }
            _dataRepository.Add(examination);
            return CreatedAtRoute(
                  "Get",
                  new { Id = examination.Id },
                  examination);
        }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Examination examination)
        {
            if (examination == null)
            {
                return BadRequest("Employee is null.");
            }
            Examination examinationToUpdate = _dataRepository.Get(id);
            if (examinationToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _dataRepository.Update(examinationToUpdate, examination);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Examination examination = _dataRepository.Get(id);
            if (examination == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _dataRepository.Delete(examination);
            return NoContent();
        }
    }
}

