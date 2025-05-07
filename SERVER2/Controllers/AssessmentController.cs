using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace SERVER2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssessmentController : ControllerBase
    {
        Ibl bl;

        public AssessmentController(Ibl bl)
        {
            this.bl = bl;
        }

        [Route("GetAll")]
        [HttpGet]
        public List<BLAssessment> Get() {
            return bl.Assessments.GetAll();
        }

        [Route("GetById/{id}")]
        [HttpGet]

        public BLAssessment Get(int id)
        {
            return bl.Assessments.GetById(id);  
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Post(int id)
        {
            try
            {
                bl.Assessments.Add(id);
                return Ok(bl.Assessments.GetAll());
            }
            catch
            {
                return Ok(false);
            }
            
        }

        [Route("Update")]
        [HttpPut]

        public IActionResult Update(BLAssessment bla)
        {
            try
            {
                bl.Assessments.Update(bla);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
            
            
        }

        [Route("Delete/{id}")]
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            try
            {
                bl.Assessments.Delete(id);
                return Ok(bl.Assessments.GetAll());
            }
            catch
            {
                return Ok(false) ;
            }
            

        }

    }
}
