import { observer } from "mobx-react";
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";

import scalesIcon from "../../../../assets/icons/scalesIcon.svg";
import personRemoveIcon from "../../../../assets/icons/personRemoveIcon.svg";

import { IsoToLocale } from "../../../../utils/dateUtils";
import { Competitor } from "../../../../models/Competitor/Competitor";
import { TableColumns } from "../../../../types/DataTableTypes";
import { PagedDataTable } from "../../../../components/DataTable";
import { useRootStoreContext } from "../../../../store";

type ColumnsType = Competitor & { controls: string };

export const CompetitorsTable = observer(() => {
  const navigate = useNavigate();
  const {
    competitorStore: {
      competitors,
      setPageSize,
      setCurrentPage,
      selectForDelete,
      total,
      pageSize,
      currentPage,
    },
  } = useRootStoreContext();

  const columns: TableColumns<Competitor, ColumnsType>[] = [
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
    },
    {
      name: "weightingResult",
      label: "Weight",
    },
    {
      name: "division",
      label: "Division",
    },
    {
      name: "controls",
      renderItem: (item) => (
        <div className="control-buttons">
          <img
            src={personRemoveIcon}
            alt="Remove"
            onClick={() => {
              selectForDelete(item);
              navigate("confirm");
            }}
          />
          <img
            src={scalesIcon}
            alt="Set weight"
            /* onClick={() => {
              selectForDelete(item);
              navigate("confirm");
            }} */
          />
        </div>
      ),
    },
  ];
  return (
    <div>
      <div className="competitors-menu">
        <Button className="add-button" variant="contained" color="inherit">
          Зареєструвати
        </Button>
      </div>

      <PagedDataTable
        tableData={{
          totalCount: total,
          pageSize: pageSize,
          items: competitors,
          currentPage: currentPage - 1,
        }}
        tableColumns={columns}
        onChangePageSize={setPageSize}
        onPageChange={setCurrentPage}
      />
    </div>
  );
});
