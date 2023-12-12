import SnackBarStore from "./SnackBarStore";
import CompetitionStore from "./CompetitionStore";
import SportsmanStore from "./SportsmanStore";
import DivisionStore from "./DivisionStore";
import CompetitorStore from "./CompetitorStore";

export class RootStore {
  snackBarStore = new SnackBarStore();
  divisionStore = new DivisionStore(this);
  sportsmanStore = new SportsmanStore(this);
  competitionStore = new CompetitionStore(this);
  competitorStore = new CompetitorStore(this);
}
