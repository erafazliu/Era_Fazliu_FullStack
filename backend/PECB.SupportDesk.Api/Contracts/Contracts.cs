using System.ComponentModel.DataAnnotations;
using PECB.SupportDesk.Api.Models;
namespace PECB.SupportDesk.Api.Contracts;
public sealed record AgentDto(int Id, string FullName, string Email, Department Department, bool Active);
public sealed record CommentDto(int Id, string AuthorName, string Body, DateTimeOffset CreatedDate);
public sealed record TicketListDto(int Id, string Reference, string Title, string CustomerName, TicketPriority Priority, TicketStatus Status, AgentDto? AssignedAgent, DateTimeOffset DueDate, DateTimeOffset CreatedDate, bool IsOverdue);
public sealed record TicketDetailDto(int Id, string Reference, string Title, string Description, string CustomerName, string CustomerEmail, TicketPriority Priority, TicketStatus Status, AgentDto? AssignedAgent, DateTimeOffset CreatedDate, DateTimeOffset LastModifiedDate, DateTimeOffset? ResolvedDate, DateTimeOffset? ClosedDate, DateTimeOffset DueDate, bool IsOverdue, IReadOnlyCollection<CommentDto> Comments);
public sealed record PagedResult<T>(IReadOnlyCollection<T> Items, int Page, int PageSize, int TotalCount, int TotalPages);
public class CreateTicketRequest { [Required,StringLength(160)] public string Title { get; init; }=""; [Required,StringLength(4000)] public string Description { get; init; }=""; [Required,StringLength(120)] public string CustomerName { get; init; }=""; [Required,EmailAddress,StringLength(254)] public string CustomerEmail { get; init; }=""; [EnumDataType(typeof(TicketPriority))] public TicketPriority Priority { get; init; } }
public sealed class UpdateTicketRequest : CreateTicketRequest { }
public sealed record AssignAgentRequest(int? AgentId);
public sealed record ChangeStatusRequest(TicketStatus Status);
public sealed class AddCommentRequest { [Required,StringLength(120)] public string AuthorName { get; init; }=""; [Required,StringLength(2000)] public string Body { get; init; }=""; }
