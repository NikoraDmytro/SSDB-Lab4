import { useEffect } from "react";
import { observer } from "mobx-react";
import { Route, Routes } from "react-router-dom";

import { useRootStoreContext } from "../../store";
import { SportsmanTable } from "./components/SportsmanTable";

import "./SportsmanPage.scss";

export const SportsmanPage = observer(() => {
  const {
    sportsmanStore: { fetchSportsmen, pageSize, currentPage },
  } = useRootStoreContext();

  useEffect(() => {
    fetchSportsmen();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [pageSize, currentPage]);

  return (
    <Routes>
      <Route path="/" element={<SportsmanTable />}>
        {/* <Route path="confirm" element={<DeleteCompetitionDialog />} />
        <Route path="add" element={<CompetitionModal />} />
        <Route path="edit" element={<CompetitionModal isEdit />} /> */}
      </Route>
    </Routes>
  );
});
