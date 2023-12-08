import * as yup from "yup";

export const divisionValidationSchema = new yup.ObjectSchema({
  name: yup
    .string()
    .max(50, "Must be less than 50 characters long!")
    .required("Required field!"),
  minWeight: yup
    .number()
    .positive("Must be a positive number!")
    .test(
      "max",
      "Must be smaller than max weight!",
      (value, context) =>
        !value || !context.parent.maxWeight || value < context.parent.maxWeight
    )
    .when("maxWeight", ([maxWeight], schema) =>
      maxWeight == undefined
        ? schema.required("Max and min weight can't both be empty!")
        : schema
    ),
  maxWeight: yup
    .number()
    .positive("Must be a positive number!")
    .max(1000, "Must be a realistic human weight in kilograms!"),
  minAge: yup
    .number()
    .required("Required field!")
    .positive("Must be a positive number!")
    .test(
      "max",
      "Must be smaller than max age!",
      (value, context) => value <= context.parent.maxAge
    ),
  maxAge: yup
    .number()
    .required("Required field!")
    .positive("Must be a positive number!")
    .max(100, "Must be a realistic human age!"),
  sex: yup
    .string()
    .oneOf(["M", "F"], "Can be either Male or Female")
    .required("Required field!"),
});
