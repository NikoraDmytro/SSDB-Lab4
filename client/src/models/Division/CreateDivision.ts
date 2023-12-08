import { Sex } from "../Sex";

export interface CreateDivision {
  name: string;
  minWeight?: number;
  maxWeight?: number;
  minAge?: number;
  maxAge?: number;
  sex: Sex;
}
