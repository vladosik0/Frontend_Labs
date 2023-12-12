export interface UserCreateDto {
  teamId?: number;
  firstName: string;
  lastName: string;
  email: string;
  birthDay: Date;
}
