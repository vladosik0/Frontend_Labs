import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProjectCreateDto } from 'src/app/models/projects/project-create-dto';
import { ProjectDto } from 'src/app/models/projects/project-dto';
import { ProjectEditDto } from 'src/app/models/projects/project-edit-dto';
import { environment } from 'src/environments/environment';

@Injectable()
export class ProjectService {
  private url = 'api/projects';

  constructor(private http: HttpClient) {}

  public getAllProjects(): Observable<ProjectDto[]> {
    return this.http.get<ProjectDto[]>(`${environment.apiUrl}/${this.url}`);
  }

  public getProjectById(id: number): Observable<ProjectDto> {
    return this.http.get<ProjectDto>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public createProject(
    project: ProjectCreateDto
  ): Observable<ProjectCreateDto> {
    return this.http.post<ProjectCreateDto>(
      `${environment.apiUrl}/${this.url}`,
      project
    );
  }

  public editProject(
    project: ProjectEditDto,
    id: number
  ): Observable<ProjectEditDto> {
    return this.http.put<ProjectEditDto>(
      `${environment.apiUrl}/${this.url}/${id}`,
      project
    );
  }

  public deleteProject(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/${this.url}/${id}`);
  }
}
