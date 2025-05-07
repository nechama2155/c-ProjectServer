using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace SERVER2.Controllers
{  
    [ApiController]
    [Route("[controller]")]
    public class AssessorController:ControllerBase
    {

        Ibl bl;
        public AssessorController(Ibl bl)
        {
            this.bl = bl;   
        }

        [Route("GetAll")]
        [HttpGet]
        public List<BLAssessor>Get()
        {// dependency injection

            return bl.Assessors.GetAll();  //  new List<string>() { "apple", "orange" };
        }
        [Route("GetCustomers/{id}")]
        [HttpGet]
        public List<BLCustomer> GetCustomers(string id)
        {
            return bl.Assessors.GetCustomers(id);
            
        }
        [Route("GetApplications/{id}")]
        [HttpGet]
        public List<BLApplications> GetApplication(string id)
        {

            return bl.Assessors.GetApplication(id);

           
        }
        [Route("GetAssessments/{id}")]
        [HttpGet]
        public List<BLAssessment> GetAssessment(string id)
        {

            return bl.Assessors.GetAssessment(id);


        }

        [Route("GetApartmentsDetails/{id}")]
        [HttpGet]
        public List<BLApartmentDetails> GetApartmentDetails(string id)
        {

            return bl.Assessors.GetApartmentDetails(id);


        }

        [Route("GetById/{id}")]
        [HttpGet]
        public BLAssessor Get(string id)
        {// dependency injection

           return bl.Assessors.GetById(id);   //  new List<string>() { "apple", "orange" };
        }

        [Route("whichType/{id}")]
        [HttpGet]
        public IActionResult GetType(string id)
        {
            try
            {
                BLAssessor o1 = bl.Assessors.GetById(id);
                if(o1 != null)
                    return Ok("a");           
                else
                {
                    BLCustomer o2 = bl.Customers.GetById(id);
                    if (o2 != null)
                        return Ok("c");
                    else return Ok("u");
                }
            }
            catch 
            {
                return Ok("u");
            }
        }
        [Route("Add")]
        [HttpPost]
        public IActionResult Post(BLAssessor bla)
        {
            try
            {
                bl.Assessors.Add(bla); 
                return Ok(bl.Assessors.GetAll());
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [Route("Update")]
        [HttpPut]

        public IActionResult Put(BLAssessor bla)
        {
            try
            {
                bl.Assessors.Update(bla);
                return Ok(bl.Assessors.GetAll());
            }
            catch (Exception ex){
             return Ok(false);
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]

        public IActionResult Delete(string id)
        {
            try
            {
                bl.Assessors.Delete(id);
                return Ok(bl.Assessors.GetAll());
        }
            catch(Exception ex)
            {
                return Ok(false);
    }
}

        [Route("getFullA/{id}")]
        [HttpGet]

        public IActionResult fullAssessor(string id)
        {
            try
            {
                BLFullAll bLFullAll = new BLFullAll()
                {
                    assessments = bl.Assessors.GetAssessment(id),
                    apartmentsDetails = bl.Assessors.GetApartmentDetails(id),
                    customers = bl.Assessors.GetCustomers(id),
                    applications = bl.Assessors.GetApplication(id),
                    chats = bl.Assessors.GetChat(id)
                };

                return Ok(bLFullAll);
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [Route("getFullM")]
        [HttpGet]

        public IActionResult fullManager()
        {
            try
            {
                BLFullAll blFullAll = new BLFullAll()
                {
                    assessments = bl.Assessments.GetAll(),
                    apartmentsDetails = bl.ApartmentDetails.GetAll(),
                    customers = bl.Customers.GetAll(),
                    applications = bl.Applications.GetAll(),
                    assessors = bl.Assessors.GetAll(),
                    chats = bl.Chats.GetAll()
                };

                return Ok(blFullAll);
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

    }
}
