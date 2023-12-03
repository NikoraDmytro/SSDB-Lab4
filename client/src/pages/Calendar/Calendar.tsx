import { useEffect } from "react";
import { Button, LinearProgress } from "@mui/material";

import deleteIcon from "../../assets/icons/delete.svg";
import editIcon from "../../assets/icons/edit.svg";

import { useRootStoreContext } from "../../store";
import { PagedDataTable } from "../../components/DataTable";

import { Competition } from "../../models/Competition";
import { TableColumns } from "../../types/DataTableTypes";

import "./Calendar.scss";
import { observer } from "mobx-react";

type ColumnType = Competition & { controls: string };

const columns: TableColumns<Competition, ColumnType>[] = [
  {
    name: "name",
    label: "Name",
  },
  {
    name: "startDate",
    label: "Start Date",
    renderItem: (item) => new Date(item.startDate).toLocaleDateString(),
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
    renderItem: () => (
      <div className="control-buttons">
        <img src={editIcon} alt="Edit" />
        <img src={deleteIcon} alt="Delete" />
      </div>
    ),
  },
];

export const Calendar = observer(() => {
  const {
    competitionStore: {
      total,
      competitions,
      fetchCompetitions,
      pageSize,
      isLoading,
      currentPage,
      setPageSize,
      setCurrentPage,
    },
  } = useRootStoreContext();

  useEffect(() => {
    fetchCompetitions();
  }, [pageSize, currentPage]);

  return (
    <div className="calendar-wrapper">
      <div className="calendar-menu">
        <Button className="add-button" variant="contained" color="inherit">
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
    </div>
  );
});
