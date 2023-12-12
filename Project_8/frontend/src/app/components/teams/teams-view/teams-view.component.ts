import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { TeamDto } from 'src/app/models/teams/team-dto';
import { TeamService } from 'src/app/services/teams/team.service';

@Component({
  selector: 'app-teams-view',
  templateUrl: './teams-view.component.html',
})
export class TeamsViewComponent {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public loading = false;

  public teams: MatTableDataSource<TeamDto>;
  public columnNames = ['id', 'name', 'createdAt', 'edit', 'delete'];

  constructor(
    private teamService: TeamService,
    private toastr: ToastrService
  ) {}

  public ngOnInit(): void {
    this.loading = true;
    this.getTeams();
  }

  public delete(id: number) {
    this.teamService.deleteTeam(id).subscribe(() => {
      this.getTeams();
    });
  }

  private getTeams() {
    this.teamService.getAllTeams().subscribe(
      (teams: TeamDto[]) => {
        this.teams = new MatTableDataSource(teams);

        this.teams.paginator = this.paginator;
        this.teams.sort = this.sort;

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
