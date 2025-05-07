using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace SERVER2.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class ApartmentDetailsController : ControllerBase
    {

        Ibl bl;

        public ApartmentDetailsController(Ibl bl)
        {
            this.bl = bl;
        }

        [Route("GetAll")]
        [HttpGet]
        public List<BLApartmentDetails> Get()
        {

            return bl.ApartmentDetails.GetAll();  
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public BLApartmentDetails Get(int id)
        {

            return bl.ApartmentDetails.GetById(id);  
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Post(BLApartmentDetails bla)
        {
            try
            {
                bl.ApartmentDetails.Add(bla);
                return Ok(bl.ApartmentDetails.GetAll());
            }
            catch 
            {
                return Ok(false);
            }
           
        }

        [Route("Update")]
        [HttpPut]

        public IActionResult Put(BLApartmentDetails bla)
        {
            try
            {
            bl.ApartmentDetails.Update(bla);
            return Ok(bl.ApartmentDetails.GetAll());
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
                bl.ApartmentDetails.Delete(id);
                return Ok(true);
            }
            catch 
            {
                return Ok(false);   
            }
            

        }
    }
}
