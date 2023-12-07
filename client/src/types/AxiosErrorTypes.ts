import { AxiosError } from "axios";

export type ResponseError = AxiosError<
  ValidationError | BadRequestError,
  Record<string, unknown>
>;

export interface ValidationError {
  title: string;
  errors: Record<string, string[]>;
}

export interface BadRequestError {
  message: string;
}
