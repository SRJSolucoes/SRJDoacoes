using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs.O2sicontroleDTO;
using Domain.Entidades;
using Service.Interfaces;

namespace AcessoWebApi.Controllers
{
  [Route("api/[controller]")] 
  [ApiController] 
  public class O2sicontroleController : ControllerBase 
  { 
      private IO2sicontroleService _service; 
      public  O2sicontroleController(IO2sicontroleService service) 
      { 
          _service = service; 
       } 
        [Authorize(Policy = "User")]                  
        [HttpGet]                                               
        public async Task<ActionResult> GetAll()                
        {                                                       
            if (!ModelState.IsValid)                            
            {                                                   
                return BadRequest(ModelState);                  
            }                                                   
            try                                                  
            {                                                    
                return Ok(await _service.GetAll());              
            }                                                    
            catch (ArgumentException ex)                         
            {                                                    
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            } 
        }      


        [Authorize(Policy = "User")]
        [HttpGet]
        [Route("O2sicontrole/GetById")]
        public async Task<ActionResult> Get([FromHeader] Guid id) 
        { 
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            } 
            try 
            {  
                return Ok(await _service.Get(id));  
            } 
            catch (ArgumentException ex) 
            { 
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); 
            } 
        } 

        [Authorize(Policy = "UserAdmin")]
        [HttpGet]
        [Route("O2sicontrole/GetInativos")]
        public async Task<ActionResult> GetAllInactives()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.GetAllInactives());
            }
           catch (ArgumentException ex)
           {
               return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);  
           }
        }

        [Authorize(Policy = "User")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] O2sicontroleDTOCreate o2sicontrole) 
        {
            if (!ModelState.IsValid)  
            { 
                return BadRequest(ModelState); 
            } 
           try 
           { 
                var result = await _service.Post(o2sicontrole); 
                if (result != null) 
                { 
                    return Ok(result); 
                } 
                else 
                { 
                    return BadRequest(); 
                } 
             } 
             catch (Exception ex) 
             { 
                 return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message + " - " + ex.InnerException); 
             } 
        } 

        [Authorize(Policy = "User")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] O2sicontroleDTOUpdate o2sicontrole) 
        { 
           if (!ModelState.IsValid) 
           { 
                return BadRequest(ModelState); 
           } 
           try  
           {   
                var result = await _service.Put(o2sicontrole); 
                if (result != null) 
                { 
                    return Ok(await _service.Get(result.Ido2sicontrole)); 
                } 
                else 
                { 
                    return BadRequest(); 
                } 
             }  
             catch (ArgumentException ex) 
             { 
                 return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
             } 
         } 

        [Authorize(Policy = "User")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromHeader] Guid Id) 
        { 
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState); 
            } 
            try 
            { 
                return Ok(await _service.Delete(Id)); 
            } 
            catch (ArgumentException ex) 
            { 
               return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);  
            } 
        } 

        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("DeleteAdmin")] 
        public async Task<ActionResult> DeleteAdmin([FromHeader] Guid Id) 
        { 
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState); 
            } 
            try 
            { 
                return Ok(await _service.DeleteAdmin(Id)); 
            } 
            catch (ArgumentException ex) 
            { 
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); 
            } 
        } 

  }
}
