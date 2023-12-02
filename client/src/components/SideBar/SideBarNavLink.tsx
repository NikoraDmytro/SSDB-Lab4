import { NavLink, To } from "react-router-dom";

export interface Props {
  to: To;
  iconSrc: string;
  iconAlt: string;
  label: string;
}

export const SideBarNavLink = ({ to, iconSrc, iconAlt, label }: Props) => {
  return (
    <NavLink to={to} className={({ isActive }) => (isActive ? "active" : "")}>
      <img src={iconSrc} alt={iconAlt} />
      <p>{label}</p>
    </NavLink>
  );
};
