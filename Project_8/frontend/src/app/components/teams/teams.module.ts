import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { TeamService } from '../../services/teams/team.service';
import { MaterialComponentsModule } from '../material-components.module';
import { TeamsCreateComponent } from './teams-create/teams-create.component';
import { TeamsEditComponent } from './teams-edit/teams-edit.component';
import { TeamsViewComponent } from './teams-view/teams-view.component';

@NgModule({
  declarations: [TeamsViewComponent, TeamsEditComponent, TeamsCreateComponent],
  imports: [CommonModule, MaterialComponentsModule, RouterModule, FormsModule],
  providers: [TeamService],
})
export class TeamsModule {}
