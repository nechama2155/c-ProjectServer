using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace SERVER2.Controllers
{


        [ApiController]
        [Route("[controller]")]
        public class ChatController : ControllerBase
        {

            Ibl bl;
            public ChatController(Ibl bl)
            {
                this.bl = bl;
            }

            [Route("GetAll")]
            [HttpGet]
            public List<BLChat> Get()
            {
                return bl.Chats.GetAll();
            }

            [Route("GetById/{id}")]
            [HttpGet]
            public BLChat Get(int id)
            {
                return bl.Chats.GetById(id);
            }

            [Route("Add")]
            [HttpPost]
            public IActionResult Post(BLChat blc)
            {
                try
                {
                    bl.Chats.Add(blc);
                    return Ok(bl.Chats.GetAll());
                }
                catch (Exception ex)
                {
                    return Ok(false);
                }

            }


            [Route("Update")]
            [HttpPut]

            public IActionResult Put(BLChat blc)
            {
                try
                {
                    bl.Chats.Update(blc);
                    return Ok(bl.Chats.GetAll());
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
                    bl.Chats.Delete(id);
                    return Ok(bl.Chats.GetAll());
                }
                catch
                {
                    return Ok(false);
                }
            }
        }
}
