export type Priority='Low'|'Normal'|'High'|'Critical'; export type Status='New'|'InProgress'|'Resolved'|'Closed';
export interface Agent {id:number;fullName:string;email:string;department:string;active:boolean}
export interface Comment {id:number;authorName:string;body:string;createdDate:string}
export interface Ticket {id:number;reference:string;title:string;description?:string;customerName:string;customerEmail?:string;priority:Priority;status:Status;assignedAgent:Agent|null;dueDate:string;createdDate:string;lastModifiedDate?:string;resolvedDate?:string;closedDate?:string;isOverdue:boolean;comments?:Comment[]}
export interface Paged<T>{items:T[];page:number;pageSize:number;totalCount:number;totalPages:number}
export interface TicketQuery {search?:string;status?:string;priority?:string;agentId?:number;overdueOnly?:boolean;page:number;pageSize:number;sortBy?:string;sortDirection?:'asc'|'desc'}
export interface TicketInput {title:string;description:string;customerName:string;customerEmail:string;priority:Priority}
