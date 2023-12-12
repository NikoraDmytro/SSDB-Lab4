import { useEffect } from "react";
import { useRootStoreContext } from "../../../../store";
import { Route, Routes } from "react-router-dom";
import { CompetitorsTable } from "./CompetitorsTable";
import { observer } from "mobx-react";

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
        {/* <Route path="confirm" element={<DeleteCompetitionDialog />} />
        <Route path="add" element={<CompetitionModal />} />
        <Route path="edit" element={<CompetitionModal isEdit />} /> */}
      </Route>
    </Routes>
  );
});

export { CompetitorsPage };
