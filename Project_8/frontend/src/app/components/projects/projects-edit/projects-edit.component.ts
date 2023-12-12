import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { forkJoin } from 'rxjs';
import { ProjectDto } from 'src/app/models/projects/project-dto';
import { ProjectEditDto } from 'src/app/models/projects/project-edit-dto';
import { TeamDto } from 'src/app/models/teams/team-dto';
import { UserDto } from 'src/app/models/users/user-dto';
import { ProjectService } from 'src/app/services/projects/project.service';
import { TeamService } from 'src/app/services/teams/team.service';
import { UserService } from 'src/app/services/users/user.service';

@Component({
  selector: 'app-projects-edit',
  templateUrl: './projects-edit.component.html',
})
export class ProjectsEditComponent implements OnInit {
  @ViewChild('projectForm') projectForm: NgForm;

  public loading = false;
  public validationBackendErrors: string[];

  public project: ProjectEditDto = {
    authorId: 0,
    teamId: 0,
    deadline: new Date(),
    description: '',
    name: '',
  };

  public id: number;
  public teamName: string;
  public authorName: string;
  public authors: UserDto[];
  public teams: TeamDto[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private projectService: ProjectService,
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
      this.projectService.getProjectById(this.id),
      this.userService.getAllUsers(),
      this.teamService.getAllTeams(),
    ]).subscribe(
      ([project, users, teams]: [ProjectDto, UserDto[], TeamDto[]]) => {
        this.project = {
          authorId: project.authorId,
          deadline: project.deadline,
          description: project.description,
          name: project.name,
          teamId: project.teamId,
        };

        this.authors = users;
        this.teams = teams;

        const author = this.authors.find((a) => a.id === this.project.authorId);
        this.authorName =
          `[${author?.id}]. ` + author?.firstName + ' ' + author?.lastName;

        const team = this.teams.find((t) => t.id === this.project.teamId);
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
    return this.projectForm.dirty;
  }

  public editProject(form: NgForm): void {
    if (form.valid) {
      this.projectForm.form.markAsPristine();

      const projectToEdit: ProjectEditDto = {
        authorId: Number(
          this.authorName.substring(
            this.authorName.indexOf('[') + 1,
            this.authorName.indexOf(']')
          )
        ),
        teamId: Number(
          this.teamName.substring(
            this.teamName.indexOf('[') + 1,
            this.teamName.indexOf(']')
          )
        ),
        deadline: this.project.deadline,
        description: this.project.description,
        name: this.project.name,
      };

      this.projectService.editProject(projectToEdit, this.id).subscribe(
        () => {
          this.router.navigate(['/projects']);
          this.toastr.success(
            'You have successfully edited the project!',
            'Project edited',
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
    this.router.navigate(['/projects']);
  }
}
