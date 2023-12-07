import { Routes, Route, Navigate } from "react-router-dom";
import routes from "./const/routes";

import { SideBar } from "./components/SideBar";
import { SnackBar } from "./components/SnackBar";

import { Calendar } from "./pages/Calendar";
import { Placeholder } from "./pages/Placeholder";
import { SportsmanPage } from "./pages/Sportsman";

import "./App.scss";

function App() {
  return (
    <>
      <SideBar />
      <div className="page-wrapper">
        <Routes>
          <Route path="/" element={<Navigate to={routes.CALENDAR} />} />
          <Route path={`${routes.CALENDAR}/*`} element={<Calendar />} />
          <Route path={`${routes.SPORTSMAN}/*`} element={<SportsmanPage />} />
          <Route path={`${routes.DIVISIONS}/*`} element={<Placeholder />} />
        </Routes>
      </div>
      <SnackBar />
    </>
  );
}

export default App;
