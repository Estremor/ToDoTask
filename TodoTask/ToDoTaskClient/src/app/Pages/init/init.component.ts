import { Component, inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { TaskService } from '../../Services/task.service';
import { TaskModel } from '../../Models/Task';
import { Router } from '@angular/router';

@Component({
  selector: 'app-init',
  templateUrl: './init.component.html',
  styleUrl: './init.component.css',
  imports: [MatCardModule, MatTableModule, MatIconModule, MatButtonModule],
})
export class InitComponent {
  private taskService = inject(TaskService);
  public listTask: TaskModel[] = [];
  public displayColumns: string[] = [
    'TaskName',
    'Description',
    'IsDone',
    'CreationDate',
  ];

  getTask() {
    this.taskService.list().subscribe({
      next: (data) => {
        if (data.length > 0) {
          this.listTask = data;
        }
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  constructor(private route: Router) {}

  Create() {
    this.route.navigate(['/tastk', 0]);
  }

  detail(model: TaskModel) {
    this.route.navigate(['/tastk', model.taskId]);
  }

  delete(model: TaskModel) {
    if (confirm('Do you want to delete the record? ' + model.taskName)) {
      this.taskService.delete(model.taskId).subscribe({
        next: (data) => {
          if (data.isDone) {
            this.getTask();
          } else {
            alert('the record cannot be delete');
          }
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }
}
