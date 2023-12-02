import { Routes, Route, Navigate } from "react-router-dom";
import routes, { competitionRoutes, divisionRoutes } from "./const/routes";
import { Calendar } from "./pages/Calendar";
import { Placeholder } from "./pages/Placeholder";
import { SideBar } from "./components/SideBar";
import { SnackBar } from "./components/SnackBar";

import "./App.scss";

function App() {
  return (
    <>
      <SideBar />
      <div className="page-wrapper">
        <Routes>
          <Route path="/" element={<Navigate to={routes.CALENDAR} />} />
          <Route path={routes.CALENDAR} element={<Calendar />} />
          <Route path={routes.DIVISIONS} element={<Placeholder />} />
          <Route path={routes.SPORTSMAN} element={<Placeholder />} />

          <Route path={routes.COMPETITION} element={<Placeholder />}>
            <Route
              path={competitionRoutes.COMPETITORS}
              element={<Placeholder />}
            />

            <Route path={competitionRoutes.DIVISIONS} element={<Placeholder />}>
              <Route path={divisionRoutes.SHUFFLE} element={<Placeholder />} />
            </Route>
          </Route>
        </Routes>
      </div>
      <SnackBar />
    </>
  );
}

export default App;
