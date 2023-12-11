import React from "react";
import { TablePagination } from "@mui/material";

import { DataTable } from "./DataTable";

import { Paged } from "../../types/Paged";
import { WithId, TableColumns } from "../../types/DataTableTypes";

interface PagedTableProps<T extends WithId, P extends T> {
  tableData: Paged<T>;
  onClick?: (item: T) => void;
  tableColumns: TableColumns<T, P>[];
  onPageChange: (page: number) => void;
  onChangePageSize: (pageSize: number) => void;
}

const PagedDataTable = <T extends WithId, P extends T>(
  props: PagedTableProps<T, P>
) => {
  const { tableData, tableColumns, onClick } = props;

  const handleChangePage = (_: unknown, newPage: number) => {
    props.onPageChange(newPage + 1);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    const pageSize = parseInt(event.target.value);
    props.onChangePageSize(pageSize);
  };

  return (
    <>
      <DataTable
        onClick={onClick}
        tableData={tableData.items}
        tableColumns={tableColumns}
      />
      <TablePagination
        rowsPerPageOptions={[10, 15, 20]}
        component="div"
        count={tableData.totalCount}
        page={tableData.currentPage}
        rowsPerPage={tableData.pageSize}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
    </>
  );
};

export { PagedDataTable };
