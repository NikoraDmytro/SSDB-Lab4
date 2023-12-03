import SnackBarStore from "./SnackBarStore";
import CompetitionStore from "./CompetitionStore";

export class RootStore {
  snackBarStore = new SnackBarStore();
  competitionStore = new CompetitionStore(this);
}
