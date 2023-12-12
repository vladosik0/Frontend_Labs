import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserCreateDto } from 'src/app/models/users/user-create-dto';
import { UserDto } from 'src/app/models/users/user-dto';
import { UserEditDto } from 'src/app/models/users/user-edit.dto';
import { environment } from 'src/environments/environment';

@Injectable()
export class UserService {
  private url = 'api/users';

  constructor(private http: HttpClient) {}

  public getAllUsers(): Observable<UserDto[]> {
    return this.http.get<UserDto[]>(`${environment.apiUrl}/${this.url}`);
  }

  public getUserById(id: number): Observable<UserDto> {
    return this.http.get<UserDto>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public createUser(user: UserCreateDto): Observable<UserCreateDto> {
    return this.http.post<UserCreateDto>(
      `${environment.apiUrl}/${this.url}`,
      user
    );
  }

  public editUser(user: UserEditDto, id: number): Observable<UserEditDto> {
    return this.http.put<UserEditDto>(
      `${environment.apiUrl}/${this.url}/${id}`,
      user
    );
  }

  public deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/${this.url}/${id}`);
  }
}
