import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { forkJoin } from 'rxjs';
import { Agent, Status, Ticket } from './models';
import { TicketService } from './ticket.service';

@Component({
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  template: `
    <a routerLink="/" class="back">← Back to tickets</a>
    <div class="loading" *ngIf="!ticket">Loading ticket…</div>
    <ng-container *ngIf="ticket as t">
      <section class="page-head">
        <div>
          <div class="title-row">
            <span class="badge priority" [attr.data-value]="t.priority">{{t.priority}}</span>
            <span class="badge status">{{label(t.status)}}</span>
            <span class="danger" *ngIf="t.isOverdue">Overdue</span>
          </div>
          <h1>{{t.title}}</h1><p>{{t.reference}}</p>
        </div>
        <div class="actions" *ngIf="!closed">
          <a [routerLink]="['/tickets',t.id,'edit']" class="button secondary">Edit</a>
          <button class="button danger-button" (click)="remove()">Delete</button>
        </div>
      </section>
      <p class="notice" *ngIf="closed">This ticket is closed and read-only.</p>
      <div class="detail-grid">
        <section class="panel content">
          <h2>Issue details</h2><p class="description">{{t.description}}</p>
          <div class="info-grid">
            <div><span>Customer</span><strong>{{t.customerName}}</strong><small>{{t.customerEmail}}</small></div>
            <div><span>Created</span><strong>{{t.createdDate|date:'medium'}}</strong></div>
            <div><span>Due date</span><strong [class.danger]="t.isOverdue">{{t.dueDate|date:'medium'}}</strong></div>
            <div><span>Last updated</span><strong>{{t.lastModifiedDate|date:'medium'}}</strong></div>
          </div>
        </section>
        <aside class="panel">
          <h2>Workflow</h2>
          <label>Assigned agent
            <select [formControl]="agentControl">
              <option [ngValue]="unassignedValue">Unassigned</option>
              <option *ngFor="let a of agents" [ngValue]="a.id">{{a.fullName}} · {{a.department}}</option>
            </select>
          </label>
          <div class="workflow">
            <span>Change status</span>
            <button *ngFor="let s of transitions[t.status]" (click)="change(s)" [disabled]="closed" class="button">Move to {{label(s)}}</button>
            <small *ngIf="!transitions[t.status].length">No further transitions available</small>
          </div>
          <p class="error" *ngIf="error">{{error}}</p>
        </aside>
      </div>
      <section class="panel comments">
        <h2>Conversation <span>{{t.comments?.length||0}}</span></h2>
        <div class="comment" *ngFor="let c of t.comments"><div class="avatar">{{c.authorName[0]}}</div><div><strong>{{c.authorName}}</strong><time>{{c.createdDate|date:'medium'}}</time><p>{{c.body}}</p></div></div>
        <div class="empty-comment" *ngIf="!t.comments?.length">No comments yet. Start the conversation below.</div>
        <form [formGroup]="form" (ngSubmit)="comment()" *ngIf="!closed">
          <div class="field-row"><label>Your name<input formControlName="authorName" placeholder="Support agent"></label></div>
          <label>Comment<textarea formControlName="body" rows="4" placeholder="Write an update…"></textarea></label>
          <button class="button" [disabled]="form.invalid">Add comment</button>
        </form>
      </section>
    </ng-container>`,
  styles: [`.back{display:inline-block;margin-bottom:22px}.detail-grid{display:grid;grid-template-columns:minmax(0,2fr) minmax(280px,1fr);gap:24px}.content{padding:32px}.description{font-size:17px;line-height:1.7}.info-grid{display:grid;grid-template-columns:1fr 1fr;gap:24px;margin-top:32px;padding-top:24px;border-top:1px solid var(--line)}.info-grid div{display:grid;gap:4px}.info-grid span,.workflow>span{color:var(--muted);font-size:12px;text-transform:uppercase;font-weight:700;letter-spacing:.06em}.info-grid small{color:var(--muted)}aside{padding:28px;height:max-content}aside label{display:grid;gap:8px}.workflow{display:grid;gap:10px;margin-top:24px}.comments{margin-top:24px;padding:28px}.comments h2 span{color:var(--muted)}.comment{display:flex;gap:14px;padding:20px 0;border-bottom:1px solid var(--line)}.comment time{margin-left:10px;color:var(--muted);font-size:12px}.comment p{margin:7px 0}.avatar{width:36px;height:36px;border-radius:50%;background:var(--red-soft);color:var(--red);display:grid;place-items:center;font-weight:800}.comments form{margin-top:28px;display:grid;gap:14px}.empty-comment{color:var(--muted);padding:20px 0}.notice{background:#fff8e8;border:1px solid #f0d99d;padding:14px 18px;border-radius:8px}.loading{padding:60px;text-align:center}@media(max-width:800px){.detail-grid{grid-template-columns:1fr}.info-grid{grid-template-columns:1fr}}`]
})
export class TicketDetailComponent implements OnInit {
  private api=inject(TicketService); private route=inject(ActivatedRoute); private router=inject(Router); private fb=inject(FormBuilder);
  ticket?:Ticket; agents:Agent[]=[]; error='';
  readonly unassignedValue = '';
  readonly agentControl = new FormControl<number|string>('');
  transitions:Record<Status,Status[]>={New:['InProgress'],InProgress:['Resolved'],Resolved:['Closed','InProgress'],Closed:[]};
  form=this.fb.nonNullable.group({authorName:['',[Validators.required,Validators.maxLength(120)]],body:['',[Validators.required,Validators.maxLength(2000)]]});
  get closed(){return this.ticket?.status==='Closed'}
  ngOnInit(){
    const id=+this.route.snapshot.params['id'];
    forkJoin({agents:this.api.agents(),ticket:this.api.get(id)}).subscribe(({agents,ticket})=>{
      this.agents=agents; this.ticket=ticket; this.syncAgentControl();
    });
    this.agentControl.valueChanges.subscribe(value=>this.assign(value===''||value===null?null:Number(value)));
  }
  load(){this.api.get(+this.route.snapshot.params['id']).subscribe(x=>{this.ticket=x;this.syncAgentControl()})}
  label(v:string){return v==='InProgress'?'In Progress':v}
  assign(agentId:number|null){if(!this.ticket)return;this.api.assign(this.ticket.id,agentId).subscribe({next:x=>{this.ticket=x;this.error='';this.syncAgentControl()},error:e=>{this.error=e.error?.detail||'Assignment failed.';this.syncAgentControl()}})}
  private syncAgentControl(){const id=this.ticket?.assignedAgent?.id??'';this.agentControl.setValue(id,{emitEvent:false});if(this.closed)this.agentControl.disable({emitEvent:false});else this.agentControl.enable({emitEvent:false})}
  change(s:Status){this.api.changeStatus(this.ticket!.id,s).subscribe({next:x=>{this.ticket=x;this.error=''},error:e=>this.error=e.error?.detail||'Status change failed.'})}
  comment(){if(this.form.invalid)return;const v=this.form.getRawValue();this.api.comment(this.ticket!.id,v.authorName,v.body).subscribe(()=>{this.form.controls.body.reset();this.load()})}
  remove(){if(confirm(`Delete ${this.ticket!.reference}? This cannot be undone.`))this.api.delete(this.ticket!.id).subscribe(()=>this.router.navigate(['/']))}
}
