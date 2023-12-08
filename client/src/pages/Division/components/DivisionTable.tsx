import { observer } from "mobx-react";
import { Outlet, useNavigate } from "react-router-dom";
import { Button, LinearProgress } from "@mui/material";

import deleteIcon from "../../../assets/icons/delete.svg";
import editIcon from "../../../assets/icons/edit.svg";

import { useRootStoreContext } from "../../../store";
import { Division } from "../../../models/Division/Division";
import { TableColumns } from "../../../types/DataTableTypes";
import { DataTable } from "../../../components/DataTable";

type ColumnType = Division & { controls: string };

export const DivisionTable = observer(() => {
  const navigate = useNavigate();
  const {
    divisionStore: { isLoading, divisions, selectForDelete, selectForEdit },
  } = useRootStoreContext();

  const columns: TableColumns<Division, ColumnType>[] = [
    {
      name: "name",
      label: "Division Name",
    },
    {
      name: "minWeight",
      label: "Min Weight",
      renderItem: (item) => item.minWeight || "-",
    },
    {
      name: "maxWeight",
      label: "Max Weight",
      renderItem: (item) => item.maxWeight || "-",
    },
    {
      name: "minAge",
      label: "Min Age",
    },
    {
      name: "maxAge",
      label: "Max Age",
    },
    {
      name: "sex",
      label: "Sex",
      renderItem: (item) => (item.sex == "M" ? "Male" : "Female"),
    },
    {
      name: "controls",
      renderItem: (item) => (
        <div className="control-buttons">
          <img
            src={editIcon}
            alt="Edit"
            onClick={() => {
              selectForEdit(item);
              navigate("edit");
            }}
          />
          <img
            src={deleteIcon}
            alt="Delete"
            onClick={() => {
              selectForDelete(item);
              navigate("confirm");
            }}
          />
        </div>
      ),
    },
  ];

  return (
    <div className="table-wrapper">
      <div className="table-menu">
        <Button
          className="add-button"
          variant="contained"
          color="inherit"
          onClick={() => navigate("add")}
        >
          Add Division
        </Button>
      </div>
      {isLoading ? (
        <LinearProgress />
      ) : (
        <DataTable tableData={divisions} tableColumns={columns} />
      )}
      <Outlet />
    </div>
  );
});
