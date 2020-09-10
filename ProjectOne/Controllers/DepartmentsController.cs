using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectOne.Models;
using ProjectOne.Repository;

namespace ProjectOne.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILogger<DepartmentsController> logger;

        public DepartmentsController(IDepartmentRepository departmentRepository,ILogger<DepartmentsController> logger)
        {
            this.departmentRepository = departmentRepository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //throw new Exception("Error in Department");

            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");


            var result = departmentRepository.GetAllDepartment();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetbyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be more then zero");
            }
            var dep = departmentRepository.GetDepartment(id);
            if (dep == null)
            {
                return NotFound();
            }
            return Ok(dep);
        }

        [HttpPost]
        public IActionResult PostDepartment([FromBody] Department dep)
        {
            if (ModelState.IsValid)
            {
                var isSaved = departmentRepository.Add(dep);
                if (isSaved != null)
                {
                    return CreatedAtRoute("GetById", new { id = isSaved.Id },dep);
                }
                else
                {
                    return BadRequest("Department Could not be Saved!");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPut("{id}")]
        public IActionResult PutDepartment(int id, [FromBody]Department dep)
        {
            try
            {
                var extDep = departmentRepository.GetDepartment(id);
                if (extDep == null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                extDep.Name = dep.Name;
                var isUpdate = departmentRepository.Update(extDep);

                if (isUpdate != null)
                {
                    return CreatedAtRoute("GetById", new { id = isUpdate.Id }, dep);
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