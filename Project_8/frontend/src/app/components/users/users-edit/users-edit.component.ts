import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { forkJoin } from 'rxjs';
import { TeamDto } from 'src/app/models/teams/team-dto';
import { UserDto } from 'src/app/models/users/user-dto';
import { UserEditDto } from 'src/app/models/users/user-edit.dto';
import { TeamService } from 'src/app/services/teams/team.service';
import { UserService } from 'src/app/services/users/user.service';

@Component({
  selector: 'app-users-edit',
  templateUrl: './users-edit.component.html',
})
export class UsersEditComponent {
  @ViewChild('userForm') userForm: NgForm;

  public loading = false;

  public user: UserEditDto = {
    birthDay: new Date(),
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
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private teamService: TeamService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.loading = true;

    this.route.paramMap.subscribe(
      (params: ParamMap) => (this.id = Number(params.get('id')))
    );

    forkJoin([
      this.userService.getUserById(this.id),
      this.teamService.getAllTeams(),
    ]).subscribe(
      ([user, teams]: [UserDto, TeamDto[]]) => {
        this.user = {
          birthDay: user.birthDay,
          email: user.email,
          firstName: user.firstName,
          lastName: user.lastName,
          teamId: user.teamId,
        };

        this.teams = teams;

        const team = this.teams.find((t) => t.id === this.user.teamId);
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

  public editUser(form: NgForm): void {
    if (form.valid) {
      this.userForm.form.markAsPristine();

      const userToEdit: UserEditDto = {
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

      this.userService.editUser(userToEdit, this.id).subscribe(
        () => {
          this.router.navigate(['/users']);
          this.toastr.success(
            'You have successfully edited the user!',
            'User edited',
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
