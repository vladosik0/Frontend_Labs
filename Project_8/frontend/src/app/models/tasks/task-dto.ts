export interface TaskDto {
  id: number;
  projectId: number;
  performerId: number;
  name: string;
  description: string;
  state: string;
  createdAt: Date;
  finishedAt?: Date;
}
