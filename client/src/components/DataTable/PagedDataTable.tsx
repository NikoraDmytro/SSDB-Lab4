import React from "react";
import { TablePagination } from "@mui/material";

import { DataTable } from "./DataTable";

import { Paged } from "../../types/Paged";
import { WithId, TableColumns } from "../../types/DataTableTypes";

interface PagedTableProps<T extends WithId, P extends T> {
  tableData: Paged<T>;
  tableColumns: TableColumns<T, P>[];
  onPageChange: (page: number) => void;
  onChangePageSize: (pageSize: number) => void;
}

const PagedDataTable = <T extends WithId, P extends T>(
  props: PagedTableProps<T, P>
) => {
  const { tableData, tableColumns } = props;

  const handleChangePage = (_: unknown, newPage: number) => {
    props.onPageChange(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    const pageSize = parseInt(event.target.value);
    props.onChangePageSize(pageSize);
  };

  return (
    <>
      <DataTable tableData={tableData.items} tableColumns={tableColumns} />
      <TablePagination
        rowsPerPageOptions={[5, 10, 25]}
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
