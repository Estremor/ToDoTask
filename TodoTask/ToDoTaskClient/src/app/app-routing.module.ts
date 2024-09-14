import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskComponent } from './Pages/task/task.component';
import { InitComponent } from './Pages/init/init.component';

export const routes: Routes = [
  { path: '', component: InitComponent },
  { path: 'init', component: InitComponent },
  { path: 'task/:id', component: TaskComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
