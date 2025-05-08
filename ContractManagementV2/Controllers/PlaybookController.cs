using ContractManagementV2.Model;
using ContractManagementV2.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContractManagementV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaybookController : ControllerBase
    {
        private readonly IPlaybookRepository _playbookRepository;
        public PlaybookController(IPlaybookRepository playbookRepository)
        {
            _playbookRepository = playbookRepository;
        }

        // GET: api/<PlaybookController>
        [HttpGet("GetPlaybooksByFirmId/{firmId}")]
        public IEnumerable<Playbook> Get(string firmId)
        {
            return _playbookRepository.GetEntityByFirmId(firmId);
        }
        // GET: api/<PlaybookController>
        [HttpGet("GetPlaybooksByUserId/{userId}")]
        public IEnumerable<Playbook> GetEntityByUserId(string userId)
        {
            return _playbookRepository.GetEntityByUserId(userId);
        }

        // GET api/<PlaybookController>/5
        [HttpGet("{playbookId}")]
        public Playbook Get(int playbookId)
        {
            return _playbookRepository.GetEntityById(playbookId);
        }

        // POST api/<PlaybookController>
        [HttpPost]
        public void Post([FromBody] Playbook playbook)
        {
            _playbookRepository.AddPlaybook(playbook);
        }

        // PUT api/<PlaybookController>/5
        [HttpPut("{playbookId}")]
        public void Put(int playbookId, [FromBody] Playbook playbook)
        {
            Playbook playbook1 = _playbookRepository.GetEntityById(playbookId);
            if (playbook1 != null) { 
                _playbookRepository.UpdatePlaybook(playbook);
            }
        }

        // DELETE api/<PlaybookController>/5
        [HttpDelete("{playbookId}")]
        public void Delete(int playbookId)
        {
            Playbook playbook = _playbookRepository.GetEntityById(playbookId);
            if (playbook != null)
            {
                _playbookRepository.DeletePlaybook(playbook);
            }
        }

        // 🟢 Add a PlaybookItem
        [HttpPost("{playbookId}/items")]
        public IActionResult AddPlaybookItem(int playbookId, [FromBody] PlaybookItem playbookItem)
        {
            if (playbookItem == null || playbookId != playbookItem.PlaybookId)
            {
                return BadRequest("Invalid PlaybookItem data.");
            }

            var playbook = _playbookRepository.GetEntityById(playbookId);
            if (playbook == null)
            {
                return NotFound($"Playbook with ID {playbookId} not found.");
            }

            _playbookRepository.AddPlaybookItem(playbookItem);
            return Ok(new { message = "PlaybookItem added successfully." });
        }

        // 🔹 Get PlaybookItems by Playbook ID
        [HttpGet("{playbookId}/items")]
        public IActionResult GetPlaybookItems(int playbookId)
        {
            var items = _playbookRepository.GetPlaybookItemsByPlaybookId(playbookId);
            if (items == null || !items.Any())
            {
                return NotFound(new { message = $"No PlaybookItems found for Playbook ID {playbookId}." });
            }
            return Ok(items);
        }

        [HttpPut("items/{itemId}")]
        public IActionResult PutPlaybookItem(int itemId, [FromBody] PlaybookItem playbookItem)
        {
            if (playbookItem == null || itemId != playbookItem.Id)
            {
                return BadRequest("Invalid PlaybookItem data.");
            }

            var existingItem = _playbookRepository.GetPlaybookItemsByPlaybookItemId(itemId);

            if (existingItem == null)
            {
                return NotFound($"PlaybookItem with ID {itemId} not found.");
            }

            _playbookRepository.UpdatePlaybookItem(playbookItem);
            return Ok(new { message = "PlaybookItem updated successfully."});
        }


        // 🔴 Delete a PlaybookItem
        [HttpDelete("items/{itemId}")]
        public IActionResult DeletePlaybookItem(int itemId)
        {
            var item = _playbookRepository.GetPlaybookItemsByPlaybookItemId(itemId);
            if (item == null)
            {
                return NotFound(new { message = $"PlaybookItem with ID {itemId} not found." });
                //return NotFound($"PlaybookItem with ID {itemId} not found.");
            }

            _playbookRepository.DeletePlaybookItem(item);
            return Ok(new { message = "PlaybookItem deleted successfully." });
        }
    }
}
