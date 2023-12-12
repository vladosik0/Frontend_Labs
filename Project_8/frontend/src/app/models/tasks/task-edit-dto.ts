import { TaskState } from './taskstate';

export interface TaskEditDto {
  projectId: number;
  performerId: number;
  name: string;
  description: string;
  state: TaskState;
  finishedAt?: Date;
}
