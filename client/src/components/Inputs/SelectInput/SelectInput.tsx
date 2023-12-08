import { useField } from "formik";
import classNames from "classnames";
import { ChangeEvent, useEffect, useState } from "react";
import { TextField } from "@mui/material";

import { DropDownItem } from "../../../types/DropDownItem";

import "./SelectInput.scss";

interface Props {
  name: string;
  label: string;
  filterable?: boolean;
  items: DropDownItem<string>[];
}

export const SelectInput = ({ label, items, name, filterable }: Props) => {
  const [active, setActive] = useState(false);
  const [field, meta, helpers] = useField(name);
  const [visibleText, setVisibleText] = useState("");

  useEffect(() => {
    const item = items.find((item) => item.value == field.value);

    if (item) {
      setVisibleText(item.label);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleSelect = (item: DropDownItem<string>) => {
    setVisibleText(item.label);
    helpers.setValue(item.value);
  };

  const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;
    const item = items.find((item) => item.label == value);

    if (item) {
      field.onChange(item.value);
    }
    setVisibleText(value);
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
        value={visibleText}
        onChange={handleChange}
        error={meta.touched && !!meta.error}
        helperText={meta.touched && <pre>{meta.error}</pre>}
      />

      <ul
        onClick={handleBlur}
        className={classNames("drop-down-menu", {
          active: active,
        })}
      >
        {(filterable
          ? items.filter((item) => item.label.includes(visibleText))
          : items
        ).map((item) => (
          <li key={item.label} onClick={() => handleSelect(item)}>
            {item.label}
          </li>
        ))}
      </ul>
    </div>
  );
};
