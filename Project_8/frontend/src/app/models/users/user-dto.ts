export interface UserDto {
  id: number;
  teamId?: number;
  firstName: string;
  lastName: string;
  email: string;
  registeredAt: Date;
  birthDay: Date;
}
