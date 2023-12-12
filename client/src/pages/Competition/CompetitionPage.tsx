import { observer } from "mobx-react";
import { useEffect } from "react";
import { CircularProgress } from "@mui/material";
import {
  Routes,
  Route,
  useNavigate,
  useParams,
  Navigate,
} from "react-router-dom";

import { useRootStoreContext } from "../../store";
import { CompetitorsPage } from "./pages/Competitors";
import { NavTabs } from "../../components/NavTabs/NavTabs";

import "./Competition.scss";

const CompetitionPage = observer(() => {
  const {
    competitionStore: { selected, fetchCompetitionDetails, isLoading },
  } = useRootStoreContext();
  const navigate = useNavigate();
  const { id } = useParams();

  useEffect(() => {
    if (!id || !parseInt(id)) {
      navigate(-1);
    }
    if (!selected) {
      fetchCompetitionDetails(parseInt(id!));
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return isLoading ? (
    <CircularProgress size={80} />
  ) : (
    <div className="wrapper">
      <div className="competition-name">{selected?.name}</div>

      <NavTabs
        tabLabels={[
          { label: "Competitors", link: "competitors" },
          { label: "Divisions", link: "divisions" },
        ]}
      />

      <Routes>
        <Route path="" element={<Navigate to="competitors" replace />} />
        <Route path="competitors/*" element={<CompetitorsPage />} />
        <Route path="divisions/*" element={<h1>Divisions</h1>} />
      </Routes>
    </div>
  );
});

export { CompetitionPage };
