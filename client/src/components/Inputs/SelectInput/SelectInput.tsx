import { useField } from "formik";
import classNames from "classnames";
import { useState } from "react";
import { TextField } from "@mui/material";

import { DropDownItem } from "../../../types/DropDownItem";

import "./SelectInput.scss";

interface Props {
  name: string;
  label: string;
  items: DropDownItem<string>[];
}

export const SelectInput = ({ label, items, name }: Props) => {
  const [active, setActive] = useState(false);
  const [field, meta, helpers] = useField(name);

  const handleSelect = (option: DropDownItem<string>) => {
    helpers.setValue(option.value);
  };

  const handleFocus = () => {
    setActive(true);
  };

  const handleBlur = () => {
    setActive(false);
  };

  return (
    <div
      tabIndex={5}
      onBlur={handleBlur}
      onFocus={handleFocus}
      className="drop-down"
    >
      <TextField
        InputLabelProps={{
          shrink: true,
        }}
        {...field}
        fullWidth
        type="text"
        label={label}
        error={meta.touched && !!meta.error}
        helperText={meta.touched && <pre>{meta.error}</pre>}
      />

      <ul
        onClick={handleBlur}
        className={classNames("drop-down-menu", {
          active: active,
        })}
      >
        {items
          .filter((item) => item.label.includes(field.value))
          .map((item) => (
            <li key={item.label} onClick={() => handleSelect(item)}>
              {item.label}
            </li>
          ))}
      </ul>
    </div>
  );
};
