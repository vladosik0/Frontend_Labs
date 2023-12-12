import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { UserDto } from 'src/app/models/users/user-dto';
import { UserService } from 'src/app/services/users/user.service';

@Component({
  selector: 'app-users-view',
  templateUrl: './users-view.component.html',
})
export class UsersViewComponent {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public loading = false;

  public users: MatTableDataSource<UserDto>;
  public columnNames = [
    'id',
    'firstName',
    'lastName',
    'email',
    'registeredAt',
    'birthDay',
    'edit',
    'delete',
  ];

  constructor(
    private userService: UserService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.loading = true;
    this.getUsers();
  }

  public delete(id: number) {
    this.userService.deleteUser(id).subscribe(() => {
      this.getUsers();
    });
  }

  private getUsers() {
    this.userService.getAllUsers().subscribe(
      (users: UserDto[]) => {
        this.users = new MatTableDataSource(users);

        this.users.paginator = this.paginator;
        this.users.sort = this.sort;

        this.loading = false;
      },
      (errors) => {
        this.toastr.error(errors, 'Error occured', {
          closeButton: true,
          positionClass: 'toast-bottom-center',
          timeOut: 5000,
        });
      }
    );
  }
}
