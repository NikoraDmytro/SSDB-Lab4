import { Sex } from "../Sex";

export interface Division {
  id: number;
  name: string;
  minWeight?: number;
  maxWeight?: number;
  minAge: number;
  maxAge: number;
  sex: Sex;
}
