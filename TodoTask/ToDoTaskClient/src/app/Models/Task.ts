export interface TaskModel {
  id: string;
  name: string;
  description: string;
  isDone: boolean;
}

export interface ResponseModel {
  statusCode: number;
  body: string;
}
