export interface ProjectDto {
  id: number;
  authorId: number;
  teamId: number;
  name: string;
  description: string;
  createdAt: Date;
  deadline: Date;
}
