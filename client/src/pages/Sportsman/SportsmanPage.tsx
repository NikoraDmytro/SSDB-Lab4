import { useEffect } from "react";
import { observer } from "mobx-react";
import { Route, Routes } from "react-router-dom";

import { useRootStoreContext } from "../../store";
import { SportsmanTable } from "./components/SportsmanTable";
import { DeleteSportsmanDialog } from "./components/DeleteSportsmanDialog";
import { SportsmanModal } from "./components/CompetitionModal/SportsmanModal";

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
        <Route path="confirm" element={<DeleteSportsmanDialog />} />
        <Route path="add" element={<SportsmanModal />} />
        <Route path="edit" element={<SportsmanModal isEdit />} />
      </Route>
    </Routes>
  );
});
