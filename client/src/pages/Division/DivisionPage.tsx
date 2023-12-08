import { useEffect } from "react";
import { observer } from "mobx-react";
import { Route, Routes } from "react-router-dom";

import { useRootStoreContext } from "../../store";
import { DivisionTable } from "./components/DivisionTable";
import { DeleteDivisionDialog } from "./components/DeleteDivisionDialog";
import { DivisionModal } from "./components/DivisionModal/DivisionModal";

import "./DivisionPage.scss";

export const DivisionPage = observer(() => {
  const {
    divisionStore: { fetchDivisions },
  } = useRootStoreContext();

  useEffect(() => {
    fetchDivisions();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <Routes>
      <Route path="/" element={<DivisionTable />}>
        <Route path="confirm" element={<DeleteDivisionDialog />} />
        <Route path="add" element={<DivisionModal />} />
        <Route path="edit" element={<DivisionModal isEdit />} />
      </Route>
    </Routes>
  );
});
