import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TeamDto } from 'src/app/models/teams/team-dto';
import { TeamEditDto } from 'src/app/models/teams/team-edit-dto';
import { TeamService } from 'src/app/services/teams/team.service';

@Component({
  selector: 'app-teams-edit',
  templateUrl: './teams-edit.component.html',
})
export class TeamsEditComponent {
  @ViewChild('teamForm') teamForm: NgForm;

  public loading = false;

  public validationBackendErrors: string[];

  public team: TeamEditDto = {
    name: '',
  };

  public id: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private teamService: TeamService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.loading = true;

    this.route.paramMap.subscribe((params) => {
      this.id = Number(params.get('id'));
    });

    this.teamService.getTeamById(this.id).subscribe((response: TeamDto) => {
      this.team = {
        name: response.name,
      };

      this.loading = false;
    });
  }

  public isFormDirty(): boolean | null {
    return this.teamForm.dirty;
  }

  public editTeam(form: NgForm): void {
    if (form.valid) {
      this.teamForm.form.markAsPristine();

      const teamToEdit: TeamEditDto = {
        name: this.team.name,
      };

      this.teamService.editTeam(teamToEdit, this.id).subscribe(
        () => {
          this.router.navigate(['/teams']);
          this.toastr.success(
            'You have successfully edited the team!',
            'Team edited',
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
