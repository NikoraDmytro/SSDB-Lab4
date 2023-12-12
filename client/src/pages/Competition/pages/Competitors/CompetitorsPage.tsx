import { useEffect } from "react";
import { useRootStoreContext } from "../../../../store";
import { Route, Routes } from "react-router-dom";
import { CompetitorsTable } from "./CompetitorsTable";
import { observer } from "mobx-react";
import { RegisterSportsmen } from "../RegisterSportsmen";
import { WeightModal } from "../../components/WeightModal";
import { DeleteCompetitorDialog } from "../../components/DeleteCompetitorDialog";

const CompetitorsPage = observer(() => {
  const {
    competitorStore: { fetchPagedData, pageSize, currentPage },
  } = useRootStoreContext();

  useEffect(() => {
    fetchPagedData();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [pageSize, currentPage]);

  return (
    <Routes>
      <Route path="/" element={<CompetitorsTable />}>
        <Route path="confirm" element={<DeleteCompetitorDialog />} />
        <Route path="edit" element={<WeightModal />} />
      </Route>
      <Route path="add" element={<RegisterSportsmen />} />
    </Routes>
  );
});

export { CompetitorsPage };
