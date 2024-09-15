import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { TaskModel } from '../Models/Task';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  private http = inject(HttpClient);
  private uri: string = appsettings.apiUriBase;

  constructor() {}

  list() {
    return this.http.get<TaskModel[]>(`${this.uri}/Get_TodoTask`);
  }

  get(id: string) {
    return this.http.get<TaskModel>(`${this.uri}/${id}`);
  }

  create(model: TaskModel) {
    return this.http.post(this.uri, model);
  }

  delete(id: string) {
    return this.http.delete<TaskModel>(`${this.uri}/${id}`);
  }
}

// add the corects urls and create its in appsettings models
