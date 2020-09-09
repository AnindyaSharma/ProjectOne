using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOne.Models;
using ProjectOne.Repository;

namespace ProjectOne.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = studentRepository.GetAllStudent();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        //api/customers/1
        [HttpGet("{id}", Name = "GetByIdTwo")]
        public IActionResult GetbyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be more then zero");
            }
            var student = studentRepository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostStudent([FromBody]StudentCreateDTO studentDTO)
        {
            if (ModelState.IsValid)
            {
                //map to customer entry
                var stuEntry = mapper.Map<Student>(studentDTO);
                //manager layer > db save custoemr
                var isSaved = studentRepository.Add(stuEntry);
                if (isSaved != null)
                {
                    studentDTO.Id = isSaved.Id;
                    //if sucess result show
                    return CreatedAtRoute("GetByIdTwo", new { id = studentDTO.Id }, studentDTO);
                }
                else
                {
                    return BadRequest("Customer could not be Save!");
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // api/customers/1
        [HttpPut("{Id}")]
        public IActionResult PutStudent(int id, [FromBody] StudentCreateDTO studentDTO)
        {
            try
            {
                var existingStudent = studentRepository.GetStudent(id);

                if (existingStudent == null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                // map update dto data to existing customer data
                var customer = mapper.Map(studentDTO, existingStudent);

                var isUpdate = studentRepository.Update(customer);

                if (isUpdate != null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Update Faild!");
                }

            }
            catch (Exception)
            {
                return BadRequest("System error occurred please contact vendor!");
            }


        }
    }
}