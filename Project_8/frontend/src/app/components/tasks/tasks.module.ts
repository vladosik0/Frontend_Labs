import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { TaskDirective } from '../../directives/task.directive';
import { TaskService } from '../../services/tasks/task.service';
import { MaterialComponentsModule } from '../material-components.module';
import { TasksCreateComponent } from './tasks-create/tasks-create.component';
import { TasksEditComponent } from './tasks-edit/tasks-edit.component';
import { TasksViewComponent } from './tasks-view/tasks-view.component';

@NgModule({
  declarations: [
    TasksViewComponent,
    TasksEditComponent,
    TasksCreateComponent,
    TaskDirective,
  ],
  imports: [CommonModule, MaterialComponentsModule, RouterModule, FormsModule],
  providers: [TaskService],
})
export class TasksModule {}
