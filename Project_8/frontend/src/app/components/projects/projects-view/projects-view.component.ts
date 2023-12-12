import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { ProjectDto } from 'src/app/models/projects/project-dto';
import { ProjectService } from 'src/app/services/projects/project.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects-view.component.html',
})
export class ProjectsViewComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public loading = false;

  public projects: MatTableDataSource<ProjectDto>;
  public columnNames = [
    'id',
    'name',
    'description',
    'createdAt',
    'deadline',
    'edit',
    'delete',
  ];

  constructor(
    private projectService: ProjectService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.getProjects();
  }

  public delete(id: number) {
    this.projectService.deleteProject(id).subscribe(() => {
      this.getProjects();
    });
  }

  private getProjects() {
    this.loading = true;

    this.projectService.getAllProjects().subscribe(
      (projects: ProjectDto[]) => {
        this.loading = false;
        this.projects = new MatTableDataSource(projects);

        this.projects.paginator = this.paginator;
        this.projects.sort = this.sort;
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
