import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { ResponseModel, TaskModel } from '../Models/Task';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  private http = inject(HttpClient);
  private uri: string = appsettings.apiUriBase;

  constructor() {}

  list() {
    return this.http.get<ResponseModel>(`${this.uri}/todo_task`);
  }

  get(id: string) {
    return this.http.get<ResponseModel>(`${this.uri}/todo_task?id=${id}`);
  }

  create(model: TaskModel) {
    return this.http.post(`${this.uri}/todo_task`, model);
  }

  delete(id: string) {
    return this.http.delete<any>(`${this.uri}/todo_task/${id}`);
  }
}
