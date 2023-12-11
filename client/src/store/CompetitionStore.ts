import RootStore from ".";
import axios from "axios";
import { makeAutoObservable } from "mobx";

import { Competition } from "../models/Competition/Competition";
import CompetitionService from "../services/CompetitionService";
import { CreateCompetition } from "../models/Competition/CreateCompetition";
import { ResponseError } from "../types/AxiosErrorTypes";

class CompetitionStore {
  rootStore: RootStore;

  total: number = 0;
  pageSize: number = 10;
  currentPage: number = 1;
  competitions: Competition[] = [];

  isLoading: boolean = false;
  isMutating: boolean = false;

  mutationError?: ResponseError;

  selected?: Competition;
  selectedForEdit?: Competition;
  selectedForDelete?: Competition;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);
  }

  setTotal = (total: number) => {
    this.total = total;
  };

  setCurrentPage = (page: number) => {
    this.currentPage = page;
  };

  setPageSize = (size: number) => {
    this.pageSize = size;
  };

  setLoading = (loading: boolean) => {
    this.isLoading = loading;
  };

  setMutating = (mutating: boolean) => {
    this.isMutating = mutating;
  };

  setCompetitions = (competitions: Competition[]) => {
    this.competitions = competitions;
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

  fetchCompetitions = async () => {
    try {
      this.setLoading(true);

      const result = await CompetitionService.getAllCompetitions({
        pageSize: this.pageSize,
        pageNumber: this.currentPage,
      });

      this.setCompetitions(result.items);
      this.setPageSize(result.pageSize);
      this.setCurrentPage(result.currentPage);
      this.setTotal(result.totalCount);
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
      this.fetchCompetitions();
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
      this.fetchCompetitions();
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
      this.fetchCompetitions();
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
