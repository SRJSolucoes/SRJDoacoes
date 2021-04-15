using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs.ParametroDTO;
using Domain.Entidades;
using Service.Interfaces;

namespace AcessoWebApi.Controllers
{
  [Route("api/[controller]")] 
  [ApiController] 
  public class ParametroController : ControllerBase 
  { 
      private IParametroService _service; 
      public  ParametroController(IParametroService service) 
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
        [Route("Parametro/GetAllGrupo")]
        public async Task<ActionResult> GetAll([FromHeader] Guid idgrupo)
        {                                                       
            if (!ModelState.IsValid)                             
            {                                                   
                return BadRequest(ModelState);                   
            }                                                   
            try                                                  
            {                                                   
                return Ok(await _service.GetAll(idgrupo));
            }                                                   
            catch (ArgumentException ex)                         
            {                                                   
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            } 
        }      

        [Authorize(Policy = "User")]
        [HttpGet]
        [Route("Parametro/GetById")]
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
        [Route("Parametro/GetInativos")]
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
        public async Task<ActionResult> Post([FromBody] ParametroDTOCreate parametro) 
        {
            if (!ModelState.IsValid)  
            { 
                return BadRequest(ModelState); 
            } 
           try 
           { 
                var result = await _service.Post(parametro); 
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
        public async Task<ActionResult> Put([FromBody] ParametroDTOUpdate parametro) 
        { 
           if (!ModelState.IsValid) 
           { 
                return BadRequest(ModelState); 
           } 
           try  
           {   
                var result = await _service.Put(parametro); 
                if (result != null) 
                { 
                    return Ok(await _service.Get(result.Idparametro)); 
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
