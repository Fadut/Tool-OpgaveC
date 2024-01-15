using Microsoft.AspNetCore.Mvc;
using ToolLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly ToolsRepository _toolsRepository;

        public ToolsController(ToolsRepository toolRepository)
        {
            _toolsRepository = toolRepository;
        }

        // GET: api/<ToolsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IEnumerable<Tool> GetAll()
        {
            return _toolsRepository.GetAll();
        }

        // GET api/<ToolsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Tool> GetById(int id)
        {
            Tool tool = _toolsRepository.GetById(id);
            if (tool == null)
            {
                return NotFound("Couldn't find Tool with ID " + id);  
            }
            return Ok(tool);
        }

        // POST api/<ToolsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Tool> Add([FromBody] Tool tool)
        {
            try
            {
                Tool newTool = _toolsRepository.Add(tool);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + newTool.Id;
                return Created(uri, newTool);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request");
            }
        }

        // PUT api/<ToolsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Tool> Update(int id, [FromBody] Tool tool)
        {
            try
            {
                Tool updatedTool = _toolsRepository.Update(id, tool);
                if (updatedTool == null)
                {
                    return NotFound("Couldn't find Tool with the id: " + id);
                }

                return Ok(updatedTool);

            }
            catch (ArgumentException ex)
            {
                return BadRequest("Bad request");
            }
        }

        // DELETE api/<ToolsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
