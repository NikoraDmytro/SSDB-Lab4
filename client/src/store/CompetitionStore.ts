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
import { Sportsman } from "../models/Sportsman/Sportsman";

class CompetitionStore extends BaseStore<Competition> {
  competitions: Competition[] = [];

  isMutating: boolean = false;

  mutationError?: ResponseError;

  selected?: Competition;
  selectedForEdit?: Competition;
  selectedForDelete?: Competition;

  selectedSportsmenIds: number[] = [];
  availableSportsmen: Sportsman[] = [];
  isLoadingSportsmen: boolean = false;

  constructor(rootStore: RootStore) {
    super(rootStore);
    makeObservable(this, {
      selectedSportsmenIds: observable,
      availableSportsmen: observable,
      isLoadingSportsmen: observable,
      competitions: observable,
      isMutating: observable,
      mutationError: observable,
      selected: observable,
      selectedForEdit: observable,
      selectedForDelete: observable,
      fetchCompetitionDetails: action,
      fetchLargestCompetition: action,
      selectSportsmen: action,
      selectForEdit: action,
      setSelected: action,
      clearSelected: action,
      setMutationError: action,
      createCompetition: action,
      updateCompetition: action,
      deleteCompetition: action,
      setAvailableSportsmen: action,
      fetchAvailableSportsmen: action,
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

  setLoadingSportsmen = (loading: boolean) => {
    this.isLoadingSportsmen = loading;
  };

  setAvailableSportsmen = (sportsmen: Sportsman[]) => {
    this.availableSportsmen = sportsmen;
  };

  selectSportsmen = (sportsmanId: number) => {
    if (this.selectedSportsmenIds.includes(sportsmanId)) {
      this.selectedSportsmenIds = this.selectedSportsmenIds.filter(
        (id) => id != sportsmanId
      );
    } else {
      this.selectedSportsmenIds = [...this.selectedSportsmenIds, sportsmanId];
    }
  };

  clearSelected = () => {
    this.selectedSportsmenIds = [];
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

  fetchAvailableSportsmen = async (id: number) => {
    try {
      this.setLoadingSportsmen(true);

      const result = await CompetitionService.getAvailableSportsmen(id, {
        pageNumber: this.currentPage,
        pageSize: this.pageSize,
      });

      this.setAvailableSportsmen(result.items);
      this.setPageSize(result.pageSize || 10);
      this.setCurrentPage(result.currentPage || 1);
      this.setTotal(result.totalCount);
    } catch (error) {
      if (axios.isAxiosError(error)) {
        this.rootStore.snackBarStore.showSnackBar(
          error.response?.data.title,
          "error"
        );
      }
    } finally {
      this.setLoadingSportsmen(false);
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
