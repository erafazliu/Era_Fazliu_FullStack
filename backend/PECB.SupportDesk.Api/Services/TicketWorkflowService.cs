using PECB.SupportDesk.Api.Models;
namespace PECB.SupportDesk.Api.Services;
public interface ITicketWorkflowService { DateTimeOffset CalculateDueDate(DateTimeOffset created, TicketPriority priority); void ChangeStatus(Ticket ticket, TicketStatus next, DateTimeOffset now); }
public sealed class TicketWorkflowException(string code,string message):Exception(message){public string Code{get;}=code;}
public sealed class TicketWorkflowService:ITicketWorkflowService {
 public DateTimeOffset CalculateDueDate(DateTimeOffset c,TicketPriority p)=>c.Add(p switch{TicketPriority.Critical=>TimeSpan.FromHours(4),TicketPriority.High=>TimeSpan.FromDays(1),TicketPriority.Normal=>TimeSpan.FromDays(3),TicketPriority.Low=>TimeSpan.FromDays(7),_=>throw new ArgumentOutOfRangeException(nameof(p))});
 public void ChangeStatus(Ticket t,TicketStatus n,DateTimeOffset now){EnsureEditable(t);var ok=(t.Status,n) is (TicketStatus.New,TicketStatus.InProgress) or (TicketStatus.InProgress,TicketStatus.Resolved) or (TicketStatus.Resolved,TicketStatus.Closed) or (TicketStatus.Resolved,TicketStatus.InProgress);if(!ok)throw new TicketWorkflowException("invalid_status_transition",$"A ticket cannot move from {t.Status} to {n}.");if(n==TicketStatus.InProgress&&(t.AssignedAgent is null||!t.AssignedAgent.Active))throw new TicketWorkflowException("active_agent_required","An active agent must be assigned before work can start.");t.Status=n;if(n==TicketStatus.Resolved)t.ResolvedDate=now;if(n==TicketStatus.InProgress&&t.ResolvedDate is not null)t.ResolvedDate=null;if(n==TicketStatus.Closed)t.ClosedDate=now;t.LastModifiedDate=now;}
 public static void EnsureEditable(Ticket t){if(t.Status==TicketStatus.Closed)throw new TicketWorkflowException("ticket_closed","Closed tickets are read-only.");}
}
