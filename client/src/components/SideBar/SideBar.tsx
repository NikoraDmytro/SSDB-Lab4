import { useNavigate } from "react-router-dom";
import routes from "../../const/routes";
import "./SideBar.scss";

import logo from "../../assets/img/logo.png";

import divisionIcon from "../../assets/icons/divisionIcon.svg";
import calendarIcon from "../../assets/icons/calendarIcon.svg";
import sportsmanIcon from "../../assets/icons/sportsmanIcon.svg";

import { SideBarNavLink } from "./SideBarNavLink";

const SideBar = (): JSX.Element => {
  const navigate = useNavigate();

  return (
    <div className="container">
      <div className="logo" onClick={() => navigate(routes.CALENDAR)}>
        <img src={logo} alt="logo" />

        <h1>Taekwon-do</h1>
      </div>

      <div className="navbar">
        <SideBarNavLink
          to={routes.CALENDAR}
          label="Calendar"
          iconSrc={calendarIcon}
          iconAlt="calendar-icon"
        />
        <SideBarNavLink
          to={routes.SPORTSMAN}
          label="Sportsmen"
          iconSrc={sportsmanIcon}
          iconAlt="sportsman-icon"
        />
        <SideBarNavLink
          to={routes.DIVISIONS}
          label="Divisions"
          iconSrc={divisionIcon}
          iconAlt="division-icon"
        />
      </div>
    </div>
  );
};

export { SideBar };
