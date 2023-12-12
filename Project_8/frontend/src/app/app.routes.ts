import { Routes } from '@angular/router';

import { ProjectsCreateComponent } from './components/projects/projects-create/projects-create.component';
import { ProjectsEditComponent } from './components/projects/projects-edit/projects-edit.component';
import { ProjectsViewComponent } from './components/projects/projects-view/projects-view.component';
import { TasksCreateComponent } from './components/tasks/tasks-create/tasks-create.component';
import { TasksEditComponent } from './components/tasks/tasks-edit/tasks-edit.component';
import { TasksViewComponent } from './components/tasks/tasks-view/tasks-view.component';
import { TeamsCreateComponent } from './components/teams/teams-create/teams-create.component';
import { TeamsEditComponent } from './components/teams/teams-edit/teams-edit.component';
import { TeamsViewComponent } from './components/teams/teams-view/teams-view.component';
import { UsersCreateComponent } from './components/users/users-create/users-create.component';
import { UsersEditComponent } from './components/users/users-edit/users-edit.component';
import { UsersViewComponent } from './components/users/users-view/users-view.component';
import { formGuard } from './guards/form.guard';

const projectRoutes: Routes = [
  { path: 'projects', component: ProjectsViewComponent, pathMatch: 'full' },
  {
    path: 'projects/create',
    component: ProjectsCreateComponent,
    pathMatch: 'full',
    canDeactivate: [formGuard],
  },
  {
    path: 'projects/edit/:id',
    component: ProjectsEditComponent,
    pathMatch: 'full',
    canDeactivate: [formGuard],
  },
];

const tasksRoutes: Routes = [
  { path: 'tasks', component: TasksViewComponent, pathMatch: 'full' },
  {
    path: 'tasks/create',
    component: TasksCreateComponent,
    pathMatch: 'full',
    canDeactivate: [formGuard],
  },
  {
    path: 'tasks/edit/:id',
    component: TasksEditComponent,
    pathMatch: 'full',
    canDeactivate: [formGuard],
  },
];

const teamRoutes: Routes = [
  { path: 'teams', component: TeamsViewComponent, pathMatch: 'full' },
  {
    path: 'teams/create',
    component: TeamsCreateComponent,
    pathMatch: 'full',
    canDeactivate: [formGuard],
  },
  {
    path: 'teams/edit/:id',
    component: TeamsEditComponent,
    pathMatch: 'full',
    canDeactivate: [formGuard],
  },
];

const userRoutes: Routes = [
  { path: 'users', component: UsersViewComponent, pathMatch: 'full' },
  {
    path: 'users/create',
    component: UsersCreateComponent,
    pathMatch: 'full',
    canDeactivate: [formGuard],
  },
  {
    path: 'users/edit/:id',
    component: UsersEditComponent,
    pathMatch: 'full',
    canDeactivate: [formGuard],
  },
];

const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: '**', redirectTo: '/', pathMatch: 'full' },
];

export const AppRoutes: Routes = [
  ...projectRoutes,
  ...tasksRoutes,
  ...teamRoutes,
  ...userRoutes,
  ...routes,
];
