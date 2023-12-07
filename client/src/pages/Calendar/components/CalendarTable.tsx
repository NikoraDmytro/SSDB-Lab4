import { observer } from "mobx-react";
import { Outlet, useNavigate } from "react-router-dom";
import { Button, LinearProgress } from "@mui/material";

import deleteIcon from "../../../assets/icons/delete.svg";
import editIcon from "../../../assets/icons/edit.svg";

import { useRootStoreContext } from "../../../store";
import { Competition } from "../../../models/Competition";
import { TableColumns } from "../../../types/DataTableTypes";
import { PagedDataTable } from "../../../components/DataTable";
import { IsoToLocale } from "../../../utils/dateUtils";

type ColumnType = Competition & { controls: string };

export const CalendarTable = observer(() => {
  const navigate = useNavigate();
  const {
    competitionStore: {
      total,
      pageSize,
      isLoading,
      currentPage,
      setPageSize,
      competitions,
      setCurrentPage,
      selectForDelete,
      selectForEdit,
    },
  } = useRootStoreContext();

  const columns: TableColumns<Competition, ColumnType>[] = [
    {
      name: "name",
      label: "Name",
    },
    {
      name: "startDate",
      label: "Start Date",
      renderItem: (item) => IsoToLocale(item.startDate),
    },
    {
      name: "duration",
      label: "Duration",
    },
    {
      name: "city",
      label: "City",
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
    <div className="calendar-wrapper">
      <div className="calendar-menu">
        <Button
          className="add-button"
          variant="contained"
          color="inherit"
          onClick={() => navigate("add")}
        >
          Add Competition
        </Button>
      </div>
      {isLoading ? (
        <LinearProgress />
      ) : (
        <PagedDataTable
          tableData={{
            totalCount: total,
            pageSize: pageSize,
            items: competitions,
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
