import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { forkJoin } from 'rxjs';
import { ProjectCreateDto } from 'src/app/models/projects/project-create-dto';
import { TeamDto } from 'src/app/models/teams/team-dto';
import { UserDto } from 'src/app/models/users/user-dto';
import { ProjectService } from 'src/app/services/projects/project.service';
import { TeamService } from 'src/app/services/teams/team.service';
import { UserService } from 'src/app/services/users/user.service';

@Component({
  selector: 'app-projects-create',
  templateUrl: './projects-create.component.html',
})
export class ProjectsCreateComponent implements OnInit {
  @ViewChild('projectForm') projectForm: NgForm;

  public loading = false;
  public validationBackendErrors: string[];

  public project: ProjectCreateDto = {
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
    private router: Router,
    private projectService: ProjectService,
    private userService: UserService,
    private teamService: TeamService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.loading = true;

    forkJoin([
      this.userService.getAllUsers(),
      this.teamService.getAllTeams(),
    ]).subscribe(
      ([users, teams]: [UserDto[], TeamDto[]]) => {
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

    this.loading = false;
  }

  public isFormDirty(): boolean | null {
    return this.projectForm.dirty;
  }

  public createProject(): void {
    this.projectForm.form.markAsPristine();

    const projectToCreate: ProjectCreateDto = {
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

    this.projectService.createProject(projectToCreate).subscribe(
      () => {
        this.router.navigate(['/projects']);
        this.toastr.success(
          'You have successfully created new project!',
          'Project created',
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

  public cancel(): void {
    this.router.navigate(['/projects']);
  }
}
