import RootStore from ".";
import axios from "axios";
import { makeAutoObservable } from "mobx";

import { Competition } from "../models/Competition";
import CompetitionService from "../services/CompetitionService";

class CompetitionStore {
  rootStore: RootStore;

  total: number = 0;
  pageSize: number = 10;
  currentPage: number = 1;
  competitions: Competition[] = [];

  isLoading: boolean = false;
  isMutating: boolean = false;

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

  fetchCompetitions = async () => {
    try {
      this.setLoading(true);

      const result = await CompetitionService.getAllCompetitions({
        pageSize: this.pageSize,
        pageNumber: this.currentPage,
      });

      this.competitions = result.items;
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
      console.error("Error fetching competitions", error);
    } finally {
      this.setLoading(false);
    }
  };

  createCompetition = async (competition: Competition) => {
    try {
      this.isMutating = true;
      await CompetitionService.createCompetition(competition);
      this.fetchCompetitions();
    } catch (error) {
      console.error("Error creating competition:", error);
    } finally {
      this.isMutating = false;
    }
  };

  updateCompetition = async (id: number, competition: Competition) => {
    try {
      this.isMutating = true;
      await CompetitionService.updateCompetition(id, competition);
      this.fetchCompetitions();
    } catch (error) {
      console.error("Error updating competition:", error);
    } finally {
      this.isMutating = false;
    }
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
      console.error("Error deleting competition:", error);
    } finally {
      this.setLoading(false);
    }
  };
}

export default CompetitionStore;
