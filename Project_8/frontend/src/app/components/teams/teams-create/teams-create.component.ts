import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TeamCreateDto } from 'src/app/models/teams/team-create-dto';
import { TeamService } from 'src/app/services/teams/team.service';

@Component({
  selector: 'app-teams-create',
  templateUrl: './teams-create.component.html',
})
export class TeamsCreateComponent {
  @ViewChild('teamForm') teamForm: NgForm;

  public validationBackendErrors: string[];

  public team: TeamCreateDto = {
    name: '',
  };

  public id: number;

  constructor(
    private router: Router,
    private teamService: TeamService,
    private toastr: ToastrService
  ) {}

  public isFormDirty(): boolean | null {
    return this.teamForm.dirty;
  }

  public createTeam(form: NgForm): void {
    if (form.valid) {
      this.teamForm.form.markAsPristine();

      const teamToCreate: TeamCreateDto = {
        name: this.team.name,
      };

      this.teamService.createTeam(teamToCreate).subscribe(
        () => {
          this.router.navigate(['/teams']);
          this.toastr.success(
            'You have successfully created new team!',
            'Team created',
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
    this.router.navigate(['/teams']);
  }
}
