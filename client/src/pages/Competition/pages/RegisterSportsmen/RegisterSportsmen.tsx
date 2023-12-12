import { Button, Checkbox, CircularProgress } from "@mui/material";
import { Sportsman } from "../../../../models/Sportsman/Sportsman";
import { TableColumns } from "../../../../types/DataTableTypes";
import { useRootStoreContext } from "../../../../store";
import { useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { PagedDataTable } from "../../../../components/DataTable";
import { IsoToLocale } from "../../../../utils/dateUtils";
import { observer } from "mobx-react";

type ColumnsType = Sportsman & { checkbox: string };

const RegisterSportsmen = observer(() => {
  const navigate = useNavigate();
  const {
    competitionStore: {
      fetchAvailableSportsmen,
      availableSportsmen,
      total,
      pageSize,
      isMutating,
      currentPage,
      setPageSize,
      setCurrentPage,
      clearSelected,
      selectSportsmen,
      selectedSportsmenIds,
    },
    competitorStore: { registerCompetitors },
  } = useRootStoreContext();
  const { id } = useParams();

  useEffect(() => {
    if (!id || !parseInt(id)) {
      navigate(-1);
    }
    fetchAvailableSportsmen(parseInt(id!));

    return () => {
      clearSelected();
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [pageSize, currentPage]);

  const columns: TableColumns<Sportsman, ColumnsType>[] = [
    {
      name: "checkbox",
      renderItem: (item) => (
        <Checkbox
          checked={selectedSportsmenIds.includes(item.id)}
          onClick={() => selectSportsmen(item.id)}
        />
      ),
    },
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
  ];

  const handleRegister = async () => {
    const success = await registerCompetitors(
      parseInt(id!),
      selectedSportsmenIds
    );

    if (success) {
      navigate(-1);
    }
  };

  return (
    <div>
      <div className="competitors-menu">
        <Button
          className="add-button"
          variant="contained"
          color="inherit"
          onClick={handleRegister}
        >
          {isMutating ? <CircularProgress /> : "Зареєструвати"}
        </Button>
      </div>

      <PagedDataTable
        tableData={{
          totalCount: total,
          pageSize: pageSize,
          items: availableSportsmen,
          currentPage: currentPage - 1,
        }}
        tableColumns={columns}
        onChangePageSize={setPageSize}
        onPageChange={setCurrentPage}
      />
    </div>
  );
});

export { RegisterSportsmen };
