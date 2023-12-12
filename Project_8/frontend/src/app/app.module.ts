import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { AppRoutes } from './app.routes';
import { DialogsModule } from './components/dialogs/dialogs.module';
import { MaterialComponentsModule } from './components/material-components.module';
import { ProjectsModule } from './components/projects/projects.module';
import { TasksModule } from './components/tasks/tasks.module';
import { TeamsModule } from './components/teams/teams.module';
import { UsersModule } from './components/users/users.module';
import { ErrorInterceptor } from './helpers/error.interceptor';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    HttpClientModule,
    MaterialComponentsModule,
    ProjectsModule,
    TasksModule,
    TeamsModule,
    UsersModule,
    DialogsModule,
    RouterModule.forRoot(AppRoutes),
  ],
  exports: [MaterialComponentsModule],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
