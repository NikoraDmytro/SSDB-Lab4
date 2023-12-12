import RootStore from ".";
import axios from "axios";
import { makeObservable, action, observable, computed } from "mobx";

import BaseStore from "./BaseStore";
import { Competitor } from "../models/Competitor/Competitor";
import CompetitorService from "../services/CompetitorService";
import { ResponseError } from "../types/AxiosErrorTypes";
import { RequestParameters } from "../types/RequestParameters";
import { Paged } from "../types/Paged";

class CompetitorStore extends BaseStore<Competitor> {
  competitors: Competitor[] = [];

  isMutating: boolean = false;

  mutationError?: ResponseError;

  selectedForDelete?: Competitor;

  get competitionId() {
    return this.rootStore.competitionStore.selected?.id ?? -1;
  }

  constructor(rootStore: RootStore) {
    super(rootStore);
    makeObservable(this, {
      competitors: observable,
      isMutating: observable,
      mutationError: observable,
      selectedForDelete: observable,
      competitionId: computed,
      setMutationError: action,
      deleteCompetitor: action,
    });
  }

  setMutating = (mutating: boolean) => {
    this.isMutating = mutating;
  };

  selectForDelete = (Competitor: Competitor) => {
    this.selectedForDelete = Competitor;
  };

  setMutationError = (error?: ResponseError) => {
    this.mutationError = error;
  };

  setPagedData(Competitors: Competitor[]): void {
    this.competitors = Competitors;
  }

  async getPagedData(params: RequestParameters): Promise<Paged<Competitor>> {
    return await CompetitorService.getAllCompetitors(
      this.competitionId,
      params
    );
  }

  deleteCompetitor = async (id: number) => {
    try {
      this.setLoading(true);
      await CompetitorService.deleteCompetitor(this.competitionId, id);
      this.fetchPagedData();
    } catch (error) {
      if (axios.isAxiosError(error)) {
        this.rootStore.snackBarStore.showSnackBar(
          error.response?.data.title,
          "error"
        );
      }
    } finally {
      this.setLoading(false);
    }
  };
}

export default CompetitorStore;
