import * as yup from "yup";
import regionalCenters from "../../../const/cities";

export const competitionValidationSchema = new yup.ObjectSchema({
  name: yup
    .string()
    .min(10, "Must be more that 10 characters long!")
    .max(100, "Must be less than 100 characters long!")
    .required("Required field!"),
  city: yup
    .string()
    .oneOf(regionalCenters, "Unknown city!")
    .required("Required field!"),
  startDate: yup.date().required("Required field!"),
  duration: yup
    .number()
    .min(1, "Can't be zero or negative!")
    .max(7, "Max duration is 7 days!")
    .required("Required field!"),
});
