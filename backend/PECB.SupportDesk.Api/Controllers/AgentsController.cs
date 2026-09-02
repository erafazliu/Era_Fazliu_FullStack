using Microsoft.AspNetCore.Mvc; using Microsoft.EntityFrameworkCore; using PECB.SupportDesk.Api.Contracts; using PECB.SupportDesk.Api.Data;
namespace PECB.SupportDesk.Api.Controllers;
[ApiController,Route("api/agents")]
public sealed class AgentsController(SupportDeskDbContext db):ControllerBase {
 [HttpGet] public async Task<IReadOnlyCollection<AgentDto>> List([FromQuery]string? search=null,[FromQuery]bool? active=null){var q=db.Agents.AsNoTracking();if(!string.IsNullOrWhiteSpace(search))q=q.Where(x=>x.FullName.Contains(search)||x.Email.Contains(search));if(active.HasValue)q=q.Where(x=>x.Active==active);return await q.OrderBy(x=>x.FullName).Select(x=>new AgentDto(x.Id,x.FullName,x.Email,x.Department,x.Active)).ToArrayAsync();}
 [HttpGet("{id:int}")] public async Task<ActionResult<AgentDto>> Get(int id){var a=await db.Agents.FindAsync(id);return a is null?NotFound():new AgentDto(a.Id,a.FullName,a.Email,a.Department,a.Active);}
}
