import SnackBarStore from "./SnackBarStore";
import CompetitionStore from "./CompetitionStore";
import SportsmanStore from "./SportsmanStore";
import DivisionStore from "./DivisionStore";

export class RootStore {
  snackBarStore = new SnackBarStore();
  divisionStore = new DivisionStore(this);
  sportsmanStore = new SportsmanStore(this);
  competitionStore = new CompetitionStore(this);
}
