import { Component, Input, OnInit, inject } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatRadioModule } from '@angular/material/radio';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { TaskService } from '../../Services/task.service';
import { Router } from '@angular/router';
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
    MatRadioModule,
    ReactiveFormsModule,
  ],
})
export class TaskComponent implements OnInit {
  @Input('id') id!: string;
  private taskServices = inject(TaskService);
  public formBuild = inject(FormBuilder);

  public formTask: FormGroup = this.formBuild.group({
    name: [''],
    description: [''],
    isDone: [false],
  });

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.taskServices.get(this.id).subscribe({
      next: (data) => {
        if (data.statusCode == 200) {
          const responsestr: any = JSON.parse(data.body);
          const result = (responsestr as TaskModel[]).filter(
            (x) => x.id == this.id
          )[0];

          this.formTask.patchValue({
            name: result.name,
            description: result.description,
            isDone: result.isDone,
          });
        }
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
    };

    if (this.id == '0') {
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
