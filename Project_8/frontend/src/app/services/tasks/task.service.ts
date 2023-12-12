import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskCreateDto } from 'src/app/models/tasks/task-create-dto';
import { TaskDto } from 'src/app/models/tasks/task-dto';
import { TaskEditDto } from 'src/app/models/tasks/task-edit-dto';
import { TaskState } from 'src/app/models/tasks/taskstate';
import { environment } from 'src/environments/environment';

@Injectable()
export class TaskService {
  private url = 'api/tasks';

  constructor(private http: HttpClient) {}

  public getAllTasks(): Observable<TaskDto[]> {
    return this.http.get<TaskDto[]>(`${environment.apiUrl}/${this.url}`);
  }

  public getTaskById(id: number): Observable<TaskDto> {
    return this.http.get<TaskDto>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public createTask(task: TaskCreateDto): Observable<TaskCreateDto> {
    return this.http.post<TaskCreateDto>(
      `${environment.apiUrl}/${this.url}`,
      task
    );
  }

  public editTask(task: TaskEditDto, id: number): Observable<TaskEditDto> {
    return this.http.put<TaskEditDto>(
      `${environment.apiUrl}/${this.url}/${id}`,
      task
    );
  }

  public deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public taskStateToString(state: TaskState): string {
    switch (state) {
      case TaskState.ToDo:
        return 'To Do';
      case TaskState.InProgress:
        return 'In Progress';
      case TaskState.Done:
        return 'Done';
      case TaskState.Canceled:
        return 'Canceled';
    }
  }

  public stringToTaskState(state: string): TaskState {
    switch (state) {
      case 'To Do':
        return TaskState.ToDo;
      case 'In Progress':
        return TaskState.InProgress;
      case 'Done':
        return TaskState.Done;
      case 'Canceled':
        return TaskState.Canceled;
    }

    throw Error('No such state');
  }
}
