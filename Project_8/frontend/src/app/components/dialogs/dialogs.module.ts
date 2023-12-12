import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ConfirmDialogService } from '../../services/dialogs/confirm-dialog.service';
import { MaterialComponentsModule } from '../material-components.module';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';

@NgModule({
  declarations: [ConfirmDialogComponent],
  imports: [CommonModule, MaterialComponentsModule],
  providers: [ConfirmDialogService],
})
export class DialogsModule {}
