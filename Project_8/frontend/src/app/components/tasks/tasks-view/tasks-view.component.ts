import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { TaskDto } from 'src/app/models/tasks/task-dto';
import { TaskService } from 'src/app/services/tasks/task.service';

@Component({
  selector: 'app-tasks-view',
  templateUrl: './tasks-view.component.html',
})
export class TasksViewComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public loading = false;

  public tasks: MatTableDataSource<TaskDto>;
  public columnNames = [
    'id',
    'name',
    'description',
    'state',
    'createdAt',
    'finishedAt',
    'edit',
    'delete',
  ];

  constructor(
    private taskService: TaskService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.getTasks();
  }

  public delete(id: number) {
    this.taskService.deleteTask(id).subscribe(() => {
      this.getTasks();
    });
  }

  private getTasks() {
    this.loading = true;

    this.taskService.getAllTasks().subscribe(
      (tasks: TaskDto[]) => {
        this.tasks = new MatTableDataSource(tasks);

        this.tasks.paginator = this.paginator;
        this.tasks.sort = this.sort;

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
