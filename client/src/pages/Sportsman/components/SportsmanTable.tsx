import { observer } from "mobx-react";
import { Outlet, useNavigate } from "react-router-dom";
import { Button, LinearProgress } from "@mui/material";

import deleteIcon from "../../../assets/icons/delete.svg";
import editIcon from "../../../assets/icons/edit.svg";

import { useRootStoreContext } from "../../../store";
import { Sportsman } from "../../../models/Sportsman/Sportsman";
import { IsoToLocale } from "../../../utils/dateUtils";
import { TableColumns } from "../../../types/DataTableTypes";
import { PagedDataTable } from "../../../components/DataTable";

type ColumnType = Sportsman & { controls: string };

export const SportsmanTable = observer(() => {
  const navigate = useNavigate();
  const {
    sportsmanStore: {
      total,
      pageSize,
      isLoading,
      currentPage,
      setPageSize,
      sportsmen,
      setCurrentPage,
      selectForDelete,
      selectForEdit,
    },
  } = useRootStoreContext();

  const columns: TableColumns<Sportsman, ColumnType>[] = [
    {
      name: "fullName",
      label: "Full Name",
    },
    {
      name: "birthDate",
      label: "Birth Date",
      renderItem: (item) => IsoToLocale(item.birthDate),
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
          Add Sportsman
        </Button>
      </div>
      {isLoading ? (
        <LinearProgress />
      ) : (
        <PagedDataTable
          tableData={{
            totalCount: total,
            pageSize: pageSize,
            items: sportsmen,
            currentPage: currentPage - 1,
          }}
          tableColumns={columns}
          onChangePageSize={setPageSize}
          onPageChange={setCurrentPage}
        />
      )}
      <Outlet />
    </div>
  );
});
