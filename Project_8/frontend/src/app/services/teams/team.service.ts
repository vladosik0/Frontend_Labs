import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TeamCreateDto } from 'src/app/models/teams/team-create-dto';
import { TeamDto } from 'src/app/models/teams/team-dto';
import { TeamEditDto } from 'src/app/models/teams/team-edit-dto';
import { environment } from 'src/environments/environment';

@Injectable()
export class TeamService {
  private url = 'api/teams';

  constructor(private http: HttpClient) {}

  public getAllTeams(): Observable<TeamDto[]> {
    return this.http.get<TeamDto[]>(`${environment.apiUrl}/${this.url}`);
  }

  public getTeamById(id: number): Observable<TeamDto> {
    return this.http.get<TeamDto>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public createTeam(team: TeamCreateDto): Observable<TeamCreateDto> {
    return this.http.post<TeamCreateDto>(
      `${environment.apiUrl}/${this.url}`,
      team
    );
  }

  public editTeam(team: TeamEditDto, id: number): Observable<TeamEditDto> {
    return this.http.put<TeamEditDto>(
      `${environment.apiUrl}/${this.url}/${id}`,
      team
    );
  }

  public deleteTeam(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/${this.url}/${id}`);
  }
}
