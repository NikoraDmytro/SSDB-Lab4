import { format, parseISO } from "date-fns";

export const IsoToLocale = (IsoDateString: string) => {
  return format(parseISO(IsoDateString), "P");
};

export const FormatIso = (IsoDateString: string, dateFormat = "yyyy-MM-dd") => {
  return format(parseISO(IsoDateString), dateFormat);
};
