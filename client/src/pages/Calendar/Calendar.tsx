import { useEffect } from "react";
import { observer } from "mobx-react";
import { Route, Routes } from "react-router-dom";

import { useRootStoreContext } from "../../store";

import { CompetitionPage } from "../Competition";
import { CalendarTable } from "./components/CalendarTable";
import { DeleteCompetitionDialog } from "./components/DeleteCompetitionDialog";
import { CompetitionModal } from "./components/CompetitionModal/CompetitionModal";

import "./Calendar.scss";

export const Calendar = observer(() => {
  const {
    competitionStore: { fetchCompetitions, pageSize, currentPage },
  } = useRootStoreContext();

  useEffect(() => {
    fetchCompetitions();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [pageSize, currentPage]);

  return (
    <Routes>
      <Route path="/" element={<CalendarTable />}>
        <Route path="confirm" element={<DeleteCompetitionDialog />} />
        <Route path="add" element={<CompetitionModal />} />
        <Route path="edit" element={<CompetitionModal isEdit />} />
      </Route>
      <Route path="/:id/*" element={<CompetitionPage />} />
    </Routes>
  );
});
