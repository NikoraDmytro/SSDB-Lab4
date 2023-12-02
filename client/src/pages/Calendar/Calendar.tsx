import { Button } from "@mui/material";

import deleteIcon from "../../assets/icons/delete.svg";
import editIcon from "../../assets/icons/edit.svg";

import { PagedDataTable } from "../../components/DataTable";

import { Competition } from "../../models/Competition";
import { TableColumns } from "../../types/DataTableTypes";
import { Paged } from "../../types/Paged";

import "./Calendar.scss";

type ColumnType = Competition & { controls: string };

const columns: TableColumns<Competition, ColumnType>[] = [
  {
    name: "name",
    label: "Name",
  },
  {
    name: "startDate",
    label: "Start Date",
    renderItem: (item) => item.startDate.toLocaleDateString(),
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

export const Calendar = () => {
  const competitions: Paged<Competition> = {
    pageSize: 5,
    totalCount: 5,
    currentPage: 0,
    items: [
      {
        id: 1,
        duration: 2,
        city: "Kharkiv",
        name: "Bla-Bla",
        startDate: new Date(),
      },
      {
        id: 2,
        duration: 2,
        city: "Kharkiv",
        name: "Bla-Bla",
        startDate: new Date(),
      },
      {
        id: 3,
        duration: 2,
        city: "Kharkiv",
        name: "Bla-Bla",
        startDate: new Date(),
      },
      {
        id: 4,
        duration: 2,
        city: "Kharkiv",
        name: "Bla-Bla",
        startDate: new Date(),
      },
      {
        id: 5,
        duration: 2,
        city: "Kharkiv",
        name: "Bla-Bla",
        startDate: new Date(),
      },
    ],
  };

  return (
    <div className="calendar-wrapper">
      <div className="calendar-menu">
        <Button className="add-button" variant="contained" color="inherit">
          Add Competition
        </Button>
      </div>
      <PagedDataTable
        tableData={competitions}
        tableColumns={columns}
        onChangePageSize={() => null}
        onPageChange={() => null}
      />
    </div>
  );
};
