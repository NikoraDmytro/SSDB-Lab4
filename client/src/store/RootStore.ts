import SnackBarStore from "./SnackBarStore";
import CompetitionStore from "./CompetitionStore";
import SportsmanStore from "./SportsmanStore";

export class RootStore {
  snackBarStore = new SnackBarStore();
  sportsmanStore = new SportsmanStore(this);
  competitionStore = new CompetitionStore(this);
}
