import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TeamDto } from 'src/app/models/teams/team-dto';
import { UserCreateDto } from 'src/app/models/users/user-create-dto';
import { TeamService } from 'src/app/services/teams/team.service';
import { UserService } from 'src/app/services/users/user.service';

@Component({
  selector: 'app-users-create',
  templateUrl: './users-create.component.html',
})
export class UsersCreateComponent {
  @ViewChild('userForm') userForm: NgForm;

  public loading = false;

  public user: UserCreateDto = {
    birthDay: new Date(2000, 1, 1),
    email: '',
    firstName: '',
    lastName: '',
    teamId: undefined,
  };

  public id: number;
  public teamName?: string;
  public teams: TeamDto[];

  public validationBackendErrors: string[];

  constructor(
    private router: Router,
    private userService: UserService,
    private teamService: TeamService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.loading = true;

    this.teamService.getAllTeams().subscribe(
      (response: TeamDto[]) => {
        this.teams = response;
        const team = this.teams.find((p) => p.id === this.user.teamId);
        this.teamName = `[${team?.id}]. ` + team?.name;

        this.loading = false;
      },
      (error) => {
        this.toastr.error(error, 'Error occured', {
          closeButton: true,
          positionClass: 'toast-bottom-center',
          timeOut: 5000,
        });
      }
    );
  }

  public isFormDirty(): boolean | null {
    return this.userForm.dirty;
  }

  public createUser(form: NgForm): void {
    if (form.valid) {
      this.userForm.form.markAsPristine();

      const userToCreate: UserCreateDto = {
        teamId: this.teamName
          ? Number(
              this.teamName.substring(
                this.teamName.indexOf('[') + 1,
                this.teamName.indexOf(']')
              )
            )
          : undefined,
        birthDay: this.user.birthDay,
        email: this.user.email,
        firstName: this.user.firstName,
        lastName: this.user.lastName,
      };

      this.userService.createUser(userToCreate).subscribe(
        () => {
          this.router.navigate(['/users']);
          this.toastr.success(
            'You have successfully created new user!',
            'User created',
            {
              closeButton: true,
              positionClass: 'toast-bottom-center',
              timeOut: 5000,
            }
          );
        },
        (errors: string[]) => {
          this.validationBackendErrors = errors;
        }
      );
    }
  }
  public cancel(): void {
    this.router.navigate(['/users']);
  }
}
