using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SERVER2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationsController : ControllerBase
    {

        Ibl bl;

        public ApplicationsController(Ibl bl)
        {
            this.bl = bl;
        }

        [Route("GetAll")]
        [HttpGet]
        public List<BLApplications>Get()
        {
           return bl.Applications.GetAll();
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public BLApplications Get(int id)
        {
            return bl.Applications.GetById(id);  
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post (BlFull full) 
        {
             try
            {
                int code = bl.Applications.GetCode();
                var a =  bl.Applications.Add(full, code);
              return   Ok(a );
            }

            catch(Exception ex)     
            {
                return Ok(false);
            }
          
        }

        [Route("Update")]
        [HttpPut]

        public IActionResult Put(BLApplications bla)
        {
            try
            {
            bl.Applications.Update(bla);
            return Ok(bl.Applications.GetAll());
            }
            catch (Exception ex)
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
                bl.Applications.Delete(id);
                return Ok(true);
            }
           
            catch { 
            return Ok(false);
            }
        }




    }
}
