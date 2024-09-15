import { Component, Input, OnInit, inject, input } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { TaskService } from '../../Services/task.service';
import { Route, Router } from '@angular/router';
import { TaskModel } from '../../Models/Task';
@Component({
  selector: 'app-task',
  standalone: true,
  templateUrl: './task.component.html',
  styleUrl: './task.component.css',
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
  ],
})
export class TaskComponent implements OnInit {
  @Input('id') idTask!: string;
  private taskServices = inject(TaskService);
  public formBuild = inject(FormBuilder);

  public formTask: FormGroup = this.formBuild.group({
    id: [''],
    name: [''],
    description: [''],
    isDone: [false],
    endDate: [''],
  });

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.taskServices.get(this.idTask).subscribe({
      next: (data) => {
        this.formTask.patchValue({
          name: '',
          description: '',
          isDone: false,
          enDate: '',
        });
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  save() {
    const mObject: TaskModel = {
      id: this.formTask.value.id,
      name: this.formTask.value.name,
      description: this.formTask.value.description,
      isDone: this.formTask.value.isDone,
      endDate: this.formTask.value.endDate,
    };

    if (this.idTask == '' && this.idTask.length < 0) {
      this.taskServices.create(mObject).subscribe({
        next: (data) => {
          console.log(data);
          this.router.navigate(['/']);
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }

  back() {
    this.router.navigate(['/']);
  }
}
