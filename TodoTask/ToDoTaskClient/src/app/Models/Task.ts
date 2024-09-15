export interface TaskModel {
  id: string;
  name: string;
  description: string;
  isDone: boolean;
  endDate: string;
}

export interface ResponseModel {
  statusCode: number;
  body: string;
}
