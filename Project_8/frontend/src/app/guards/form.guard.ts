import { inject } from '@angular/core';
import { CanDeactivateFn } from '@angular/router';

import { ProjectsEditComponent } from '../components/projects/projects-edit/projects-edit.component';
import { TasksEditComponent } from '../components/tasks/tasks-edit/tasks-edit.component';
import { TeamsEditComponent } from '../components/teams/teams-edit/teams-edit.component';
import { UsersEditComponent } from '../components/users/users-edit/users-edit.component';
import { ConfirmDialogService } from '../services/dialogs/confirm-dialog.service';

export const formGuard: CanDeactivateFn<
  | ProjectsEditComponent
  | TasksEditComponent
  | TeamsEditComponent
  | UsersEditComponent
> = async (component) => {
  if (component.isFormDirty()) {
    const confirmDialogService = inject(ConfirmDialogService);

    return await new Promise<boolean>((resolve) => {
      confirmDialogService
        .openConfirmDialog()
        .subscribe((response: boolean) => resolve(response));
    });
  }
  return true;
};
