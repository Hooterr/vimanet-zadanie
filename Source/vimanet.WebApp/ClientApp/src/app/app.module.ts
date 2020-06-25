import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { TaskEditComponent } from './task-edit/task-edit.component';
import { NgbdSortableHeader, TaskOverviewComponent } from './task-overview/task-overview.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    TaskOverviewComponent,
    TaskEditComponent,
    NgbdSortableHeader,
  ],
  exports: [],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: TaskOverviewComponent, pathMatch: 'full' },
      { path: 'edit/:id', component: TaskEditComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
