import RootStore from ".";
import axios from "axios";
import { makeObservable, action, observable } from "mobx";

import BaseStore from "./BaseStore";
import { Competition } from "../models/Competition/Competition";
import CompetitionService from "../services/CompetitionService";
import { CreateCompetition } from "../models/Competition/CreateCompetition";
import { ResponseError } from "../types/AxiosErrorTypes";
import { RequestParameters } from "../types/RequestParameters";
import { Paged } from "../types/Paged";

class CompetitionStore extends BaseStore<Competition> {
  competitions: Competition[] = [];

  isMutating: boolean = false;

  mutationError?: ResponseError;

  selected?: Competition;
  selectedForEdit?: Competition;
  selectedForDelete?: Competition;

  constructor(rootStore: RootStore) {
    super(rootStore);
    makeObservable(this, {
      competitions: observable,
      isMutating: observable,
      mutationError: observable,
      selected: observable,
      selectedForEdit: observable,
      selectedForDelete: observable,
      selectForEdit: action,
      setSelected: action,
      setMutationError: action,
      createCompetition: action,
      updateCompetition: action,
      deleteCompetition: action,
    });
  }

  setMutating = (mutating: boolean) => {
    this.isMutating = mutating;
  };

  setSelected = (competition: Competition) => {
    this.selected = competition;
  };

  selectForDelete = (competition: Competition) => {
    this.selectedForDelete = competition;
  };

  selectForEdit = (competition: Competition) => {
    this.selectedForEdit = competition;
  };

  setMutationError = (error?: ResponseError) => {
    this.mutationError = error;
  };

  setPagedData(competitions: Competition[]): void {
    this.competitions = competitions;
  }

  async getPagedData(params: RequestParameters): Promise<Paged<Competition>> {
    return await CompetitionService.getAllCompetitions(params);
  }

  fetchCompetitionDetails = async (id: number) => {
    try {
      this.setLoading(true);
      const result = await CompetitionService.getCompetition(id);
      this.setSelected(result);
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

  fetchLargestCompetition = async () => {
    try {
      this.setLoading(true);
      const result = await CompetitionService.getLargestCompetition();
      this.setSelected(result);
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

  createCompetition = async (competition: CreateCompetition) => {
    try {
      this.setMutating(true);
      await CompetitionService.createCompetition(competition);
      this.fetchPagedData();
    } catch (error) {
      if (axios.isAxiosError(error)) {
        if (error.status == 400 || error.response?.status == 400) {
          this.setMutationError(error);
        } else {
          this.rootStore.snackBarStore.showSnackBar(
            error.response?.data.title || error.response?.data.message,
            "error"
          );
        }
      }
      return false;
    } finally {
      this.setMutating(false);
    }
    return true;
  };

  updateCompetition = async (id: number, competition: CreateCompetition) => {
    try {
      this.setMutating(true);
      await CompetitionService.updateCompetition(id, competition);
      this.fetchPagedData();
    } catch (error) {
      if (axios.isAxiosError(error)) {
        if (error.status == 400 || error.response?.status == 400) {
          this.setMutationError(error);
        } else {
          this.rootStore.snackBarStore.showSnackBar(
            error.response?.data.message,
            "error"
          );
        }
      }
      return false;
    } finally {
      this.setMutating(false);
    }
    return true;
  };

  deleteCompetition = async (id: number) => {
    try {
      this.setLoading(true);
      await CompetitionService.deleteCompetition(id);
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

export default CompetitionStore;
