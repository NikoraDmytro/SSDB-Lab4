import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from "@mui/material";

import { WithId, TableColumns } from "../../types/DataTableTypes";

interface TableProps<T extends WithId, P extends T> {
  tableData: T[];
  onClick?: (item: T) => void;
  tableColumns: TableColumns<T, P>[];
}

const DataTable = <T extends WithId, P extends T>(props: TableProps<T, P>) => {
  const { tableData, tableColumns } = props;

  return (
    <>
      <Table stickyHeader>
        <TableHead>
          <TableRow>
            {tableColumns.map((column) => (
              <TableCell key={String(column.name)}>{column.label}</TableCell>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {tableData.map((item) => (
            <TableRow
              key={item.id}
              onClick={props.onClick && (() => props.onClick!(item))}
              sx={
                props.onClick && {
                  cursor: "pointer",
                  transition: "all 0.25s",
                  ":hover": { background: "rgba(100, 95, 95, 0.4)" },
                }
              }
            >
              {tableColumns.map((column) => (
                <TableCell key={String(column.name)}>
                  {column.renderItem
                    ? column.renderItem(item)
                    : (item[column.name as keyof T] as string) || "-"}
                </TableCell>
              ))}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </>
  );
};

export { DataTable };
