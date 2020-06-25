import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskOverviewItem } from './task-overview/task-overview.component';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Task } from './task-edit/task-edit.component';

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  private baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  
  public getTaskOverview(): Observable<TaskOverviewItem[]> {
    return this.http.get<TaskOverviewItem[]>(this.baseUrl + 'taskgroup/overview')
  }

  public deleteTaskGroup(id: number) {
    return this.http.delete<string>(this.baseUrl + 'taskgroup/delete/' + id, { responseType: 'text' as 'json' });
  }

  public updateTaskGroup(id: number, group: TaskGroup) {
    return this.http.put(this.baseUrl + 'taskgroup/update/' + id, group);
  }

  public getTaskGroup(id: number): Observable<TaskGroup> {
    return this.http.get<TaskGroup>(this.baseUrl + 'taskgroup/getgroupcontext/' + id); 
  }

  public updateTask(id: number, task: Task) {
    return this.http.put(this.baseUrl + 'usertask/update/' + id, task);
  }

  public deleteTask(id: number) {
    return this.http.delete(this.baseUrl + 'usertask/delete/' + id);
  }

}

export interface TaskGroup {
  id: number,
  name: string,
  userTasks: Task[];
}
