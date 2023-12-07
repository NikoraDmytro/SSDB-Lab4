import { useField } from "formik";
import { TextField } from "@mui/material";

interface Props {
  name: string;
  type: string;
  label: string;
}

const InputFormField = (props: Props): JSX.Element => {
  const [field, meta] = useField(props.name);
  return (
    <TextField
      InputLabelProps={{
        shrink: true,
      }}
      {...field}
      fullWidth
      type={props.type}
      label={props.label}
      error={meta.touched && !!meta.error}
      helperText={meta.touched && <pre>{meta.error}</pre>}
    />
  );
};

export { InputFormField };
