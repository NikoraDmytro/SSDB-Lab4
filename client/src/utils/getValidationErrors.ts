import camelcase from "camelcase";
import { ResponseError } from "../types/AxiosErrorTypes";
import { isValidationError } from "./checkResponseErrorType";

export const getValidationErrors = (error: ResponseError) => {
  if (!isValidationError(error)) {
    return {};
  }

  return Object.entries(error.response.data.errors).reduce(
    (errors, [key, value]) => {
      errors[camelcase(key)] = value.join("\n");

      return errors;
    },
    {} as Record<string, string>
  );
};
