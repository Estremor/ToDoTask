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
  standalone: true,
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
        console.log(data);
        if (data.length > 0) {
          this.listTask = data;
        }
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  constructor(private route: Router) {
    this.getTask();
  }

  create() {
    this.route.navigate(['/tastk', 0]);
  }

  detail(model: TaskModel) {
    this.route.navigate(['/tastk', model.id]);
  }

  delete(model: TaskModel) {
    if (confirm('Do you want to delete the record? ' + model.name)) {
      this.taskService.delete(model.id).subscribe({
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
