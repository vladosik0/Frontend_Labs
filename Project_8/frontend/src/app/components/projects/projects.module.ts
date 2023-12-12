import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { ProjectService } from '../../services/projects/project.service';
import { MaterialComponentsModule } from '../material-components.module';
import { ProjectsCreateComponent } from './projects-create/projects-create.component';
import { ProjectsEditComponent } from './projects-edit/projects-edit.component';
import { ProjectsViewComponent } from './projects-view/projects-view.component';

@NgModule({
  declarations: [
    ProjectsViewComponent,
    ProjectsEditComponent,
    ProjectsCreateComponent,
  ],
  imports: [CommonModule, MaterialComponentsModule, RouterModule, FormsModule],
  exports: [ProjectsViewComponent],
  providers: [ProjectService],
})
export class ProjectsModule {}
