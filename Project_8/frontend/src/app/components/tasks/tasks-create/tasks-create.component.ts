import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { forkJoin } from 'rxjs';
import { ProjectDto } from 'src/app/models/projects/project-dto';
import { TaskCreateDto } from 'src/app/models/tasks/task-create-dto';
import { TaskState } from 'src/app/models/tasks/taskstate';
import { UserDto } from 'src/app/models/users/user-dto';
import { ProjectService } from 'src/app/services/projects/project.service';
import { TaskService } from 'src/app/services/tasks/task.service';
import { UserService } from 'src/app/services/users/user.service';

@Component({
  selector: 'app-tasks-create',
  templateUrl: './tasks-create.component.html',
})
export class TasksCreateComponent implements OnInit {
  @ViewChild('taskForm') taskForm: NgForm;

  public loading = false;
  public validationBackendErrors: string[];

  public task: TaskCreateDto = {
    description: '',
    name: '',
    performerId: 0,
    projectId: 0,
    state: TaskState.ToDo,
  };

  public id: number;
  public projectName: string;
  public performerName: string;
  public projects: ProjectDto[];
  public performers: UserDto[];

  public taskStates = [
    TaskState.ToDo,
    TaskState.InProgress,
    TaskState.Done,
    TaskState.Canceled,
  ];
  public selectedTaskState: TaskState;

  constructor(
    private router: Router,
    public taskService: TaskService,
    private projectService: ProjectService,
    private userService: UserService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.loading = true;

    forkJoin([
      this.userService.getAllUsers(),
      this.projectService.getAllProjects(),
    ]).subscribe(
      ([users, projects]: [UserDto[], ProjectDto[]]) => {
        this.performers = users;
        this.projects = projects;

        const perfomer = this.performers.find(
          (p) => p.id === this.task.performerId
        );
        this.performerName =
          `[${perfomer?.id}]. ` +
          perfomer?.firstName +
          ' ' +
          perfomer?.lastName;

        const project = this.projects.find((p) => p.id === this.task.projectId);
        this.projectName = `[${project?.id}]. ` + project?.name;

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
    return this.taskForm.dirty;
  }

  public createTask(form: NgForm): void {
    if (form.valid) {
      this.taskForm.form.markAsPristine();

      const taskToCreate: TaskCreateDto = {
        performerId: Number(
          this.performerName.substring(
            this.performerName.indexOf('[') + 1,
            this.performerName.indexOf(']')
          )
        ),
        projectId: Number(
          this.projectName.substring(
            this.projectName.indexOf('[') + 1,
            this.projectName.indexOf(']')
          )
        ),
        description: this.task.description,
        name: this.task.name,
        state: this.selectedTaskState,
      };

      this.taskService.createTask(taskToCreate).subscribe(
        () => {
          this.router.navigate(['/tasks']);
          this.toastr.success(
            'You have successfully created new task!',
            'Task created',
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
    this.router.navigate(['/tasks']);
  }
}
