import { TaskState } from './taskstate';

export interface TaskCreateDto {
  projectId: number;
  performerId: number;
  name: string;
  description: string;
  state: TaskState;
}
