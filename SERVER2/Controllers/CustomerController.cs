using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace SERVER2.Controllers
{  
    [ApiController]
        [Route("[controller]")]
    public class CustomerController:ControllerBase
    {

        Ibl bl;
        public CustomerController(Ibl bl)
        {
            this.bl = bl;   
        }

        [Route("GetAll")]
        [HttpGet]
        public List<BLCustomer>Get()
        {
            return bl.Customers.GetAll();  
        }
        ////////
        [Route("GetApplications/{id}")]
        [HttpGet]
        public List<BLApplications> GetApplication(string id)
        {

            return bl.Customers.GetApplication(id);


        }
        [Route("GetAssessments/{id}")]
        [HttpGet]
        public List<BLAssessment> GetAssessment(string id)
        {

            return bl.Customers.GetAssessment(id);


        }

        [Route("GetApartmentsDetails/{id}")]
        [HttpGet]
        public List<BLApartmentDetails> GetApartmentDetails(string id)
        {

            return bl.Customers.GetApartmentDetails(id);


        }
        [Route("GetAssessors/{id}")]
        [HttpGet]
        public List<BLAssessor> GetAssessor(string id)
        {

            return bl.Customers.GetAssessor(id);


        }
        ///

        [Route("GetById/{id}")]
        [HttpGet]
        public BLCustomer Get(string id)
        {
            return bl.Customers.GetById(id);  
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Post(BLCustomer blc)
        {
            try
            {
                bl.Customers.Add(blc);
                return Ok(bl.Customers.GetAll());
            }
            catch(Exception ex)
            {
                return Ok(false);
            }
            
        }


        [Route("Update")]
        [HttpPut]

        public IActionResult Put(BLCustomer blc)
        {
            try
            {
                bl.Customers.Update(blc);
                return Ok(bl.Customers.GetAll());
            }
            catch (Exception ex)
            {
                return Ok(false);

            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]

        public IActionResult Delete(string id)
        {
            try
            {
             bl.Customers.Delete(id);
                return Ok(bl.Customers.GetAll());
            }
            catch
            {
                return Ok(false) ;
            }
        }

        [Route("GetfullC/{id}")]
        [HttpGet]

        public IActionResult full(string id)
        {
            try
            {
                BLFullAll blFullAll = new BLFullAll()
                {
                    apartmentsDetails = bl.Customers.GetApartmentDetails(id),
                    applications = bl.Customers.GetApplication(id),
                    assessments = bl.Customers.GetAssessment(id),
                    assessors = bl.Customers.GetAssessor(id),
                    chats = bl.Customers.GetChat(id),
                };
                return Ok(blFullAll);
            }
            catch
            {
                return Ok(false);
            }
        }
    }
}
