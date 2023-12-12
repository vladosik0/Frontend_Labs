import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { ConfirmDialogComponent } from 'src/app/components/dialogs/confirm-dialog/confirm-dialog.component';

@Injectable({
  providedIn: 'root',
})
export class ConfirmDialogService {
  public constructor(private dialog: MatDialog) {}

  public openConfirmDialog(): Observable<boolean> {
    const dialog = this.dialog.open(ConfirmDialogComponent, {
      disableClose: true,
      minWidth: 300,
      autoFocus: true,
      backdropClass: 'dialog-backdrop',
      position: {
        top: '100px',
      },
    });

    return dialog.afterClosed();
  }
}
