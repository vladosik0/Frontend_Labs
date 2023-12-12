import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { UserService } from '../../services/users/user.service';
import { MaterialComponentsModule } from '../material-components.module';
import { UsersCreateComponent } from './users-create/users-create.component';
import { UsersEditComponent } from './users-edit/users-edit.component';
import { UsersViewComponent } from './users-view/users-view.component';

@NgModule({
  declarations: [UsersViewComponent, UsersEditComponent, UsersCreateComponent],
  imports: [CommonModule, MaterialComponentsModule, RouterModule, FormsModule],
  providers: [UserService],
})
export class UsersModule {}
