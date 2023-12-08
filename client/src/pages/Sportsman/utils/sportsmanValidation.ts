import { sub } from "date-fns";
import * as yup from "yup";

const fiveYearsAgo = sub(new Date(), { years: 5 });

export const sportsmanValidationSchema = new yup.ObjectSchema({
  firstName: yup
    .string()
    .max(60, "Must be less than 60 characters long!")
    .required("Required field!"),
  lastName: yup
    .string()
    .max(60, "Must be less than 60 characters long!")
    .required("Required field!"),
  birthDate: yup
    .date()
    .max(fiveYearsAgo, "Sportsman must be at least 5 years old!")
    .required("Required field!"),
  sex: yup
    .string()
    .oneOf(["M", "F"], "Can be either Male or Female")
    .required("Required field!"),
});
