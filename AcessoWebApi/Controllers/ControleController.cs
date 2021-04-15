using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs.ControleDTO;
using Domain.Entidades;
using Service.Interfaces;

namespace AcessoWebApi.Controllers
{
  [Route("api/[controller]")] 
  [ApiController] 
  public class ControleController : ControllerBase 
  { 
      private IControleService _service; 
      public  ControleController(IControleService service) 
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
        [Route("Controle/GetAllVenda")]
        public async Task<ActionResult> GetAll([FromHeader] Guid idvenda)
        {                                                       
            if (!ModelState.IsValid)                             
            {                                                   
                return BadRequest(ModelState);                   
            }                                                   
            try                                                  
            {                                                   
                return Ok(await _service.GetAll(idvenda));
            }                                                   
            catch (ArgumentException ex)                         
            {                                                   
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            } 
        }      

        [Authorize(Policy = "User")]
        [HttpGet]
        [Route("Controle/GetById")]
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
        [Route("Controle/GetInativos")]
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
        public async Task<ActionResult> Post([FromBody] ControleDTOCreate controle) 
        {
            if (!ModelState.IsValid)  
            { 
                return BadRequest(ModelState); 
            } 
           try 
           { 
                var result = await _service.Post(controle); 
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
        public async Task<ActionResult> Put([FromBody] ControleDTOUpdate controle) 
        { 
           if (!ModelState.IsValid) 
           { 
                return BadRequest(ModelState); 
           } 
           try  
           {   
                var result = await _service.Put(controle); 
                if (result != null) 
                { 
                    return Ok(await _service.Get(result.Idcontrole)); 
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
