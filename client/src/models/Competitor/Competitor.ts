import { Sex } from "../Sex";

export interface Competitor {
  id: number;
  fullName: string;
  birthDate: string;
  sex: Sex;
  weightingResult?: number;
  division?: string;
  lapNum: number;
}
