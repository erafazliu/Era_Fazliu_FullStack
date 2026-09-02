using PECB.SupportDesk.Api.Models; using PECB.SupportDesk.Api.Services;
namespace PECB.SupportDesk.Tests;
public sealed class TicketWorkflowServiceTests {
 private readonly TicketWorkflowService sut=new(); private static readonly DateTimeOffset Created=new(2026,1,1,8,0,0,TimeSpan.Zero);
 [Theory][InlineData(TicketPriority.Critical,4)][InlineData(TicketPriority.High,24)][InlineData(TicketPriority.Normal,72)][InlineData(TicketPriority.Low,168)] public void Due_date_matches_priority_sla(TicketPriority p,int hours)=>Assert.Equal(Created.AddHours(hours),sut.CalculateDueDate(Created,p));
 [Fact] public void New_cannot_skip_to_resolved(){var t=Ticket(TicketStatus.New,true);var ex=Assert.Throws<TicketWorkflowException>(()=>sut.ChangeStatus(t,TicketStatus.Resolved,Created));Assert.Equal("invalid_status_transition",ex.Code);}
 [Fact] public void Work_cannot_start_without_active_agent(){var t=Ticket(TicketStatus.New,false);var ex=Assert.Throws<TicketWorkflowException>(()=>sut.ChangeStatus(t,TicketStatus.InProgress,Created));Assert.Equal("active_agent_required",ex.Code);}
 [Fact] public void Resolved_ticket_can_reopen_and_clears_resolved_date(){var t=Ticket(TicketStatus.Resolved,true);t.ResolvedDate=Created.AddHours(-1);sut.ChangeStatus(t,TicketStatus.InProgress,Created);Assert.Equal(TicketStatus.InProgress,t.Status);Assert.Null(t.ResolvedDate);}
 [Fact] public void Closed_ticket_is_immutable(){var t=Ticket(TicketStatus.Closed,true);var ex=Assert.Throws<TicketWorkflowException>(()=>sut.ChangeStatus(t,TicketStatus.InProgress,Created));Assert.Equal("ticket_closed",ex.Code);}
 [Fact] public void Resolve_and_close_dates_are_system_owned(){var t=Ticket(TicketStatus.InProgress,true);sut.ChangeStatus(t,TicketStatus.Resolved,Created);Assert.Equal(Created,t.ResolvedDate);sut.ChangeStatus(t,TicketStatus.Closed,Created.AddHours(1));Assert.Equal(Created.AddHours(1),t.ClosedDate);}
 private static Ticket Ticket(TicketStatus s,bool active)=>new(){Reference="TCK-2026-0001",Title="Test",Description="Test",CustomerName="Test",CustomerEmail="test@example.com",Priority=TicketPriority.Normal,Status=s,CreatedDate=Created,LastModifiedDate=Created,DueDate=Created.AddDays(3),AssignedAgent=active?new Agent{FullName="Agent",Email="agent@example.com",Active=true}:null};
}
