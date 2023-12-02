export const routes = {
  CALENDAR: "/calendar",
  DIVISIONS: "/divisions",
  SPORTSMAN: "/sportsmen",
  COMPETITION: "/calendar/:competitionId/*",
};

export const competitionRoutes = {
  SPORTSMEN: "sportsmen",
  COMPETITORS: "competitors",
  DIVISIONS: "divisions/*",
};

export const divisionRoutes = {
  SHUFFLE: ":divisionId",
};

export default routes;
