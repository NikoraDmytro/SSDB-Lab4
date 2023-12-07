import { AxiosError, AxiosResponse } from "axios";
import {
  BadRequestError,
  ResponseError,
  ValidationError,
} from "../types/AxiosErrorTypes";

// eslint-disable-next-line @typescript-eslint/no-explicit-any
type WithResponse<T, D = any> = AxiosError<T, D> & {
  response: AxiosResponse<T, D>;
};

export const isValidationError = (
  error: ResponseError
): error is WithResponse<ValidationError> => {
  if ((error.response?.data as ValidationError).errors) {
    return true;
  }
  return false;
};

export const isBadRequestError = (
  error: ResponseError
): error is WithResponse<BadRequestError> => {
  if ((error.response?.data as BadRequestError).message) {
    return true;
  }
  return false;
};
