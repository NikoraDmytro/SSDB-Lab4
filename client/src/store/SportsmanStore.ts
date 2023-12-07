import RootStore from ".";
import axios from "axios";
import { makeAutoObservable } from "mobx";

import { ResponseError } from "../types/AxiosErrorTypes";
import { Sportsman } from "../models/Sportsman/Sportsman";
import SportsmanService from "../services/SportsmanService";
import { CreateSportsman } from "../models/Sportsman/CreateSportsman";

class SportsmanStore {
  rootStore: RootStore;

  total: number = 0;
  pageSize: number = 10;
  currentPage: number = 1;
  sportsmen: Sportsman[] = [];

  isLoading: boolean = false;
  isMutating: boolean = false;

  mutationError?: ResponseError;

  selectedForEdit?: Sportsman;
  selectedForDelete?: Sportsman;

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

  setSportsmen = (sportsmen: Sportsman[]) => {
    this.sportsmen = sportsmen;
  };

  selectForDelete = (sportsmen: Sportsman) => {
    this.selectedForDelete = sportsmen;
  };

  selectForEdit = (sportsmen: Sportsman) => {
    this.selectedForEdit = sportsmen;
  };

  setMutationError = (error?: ResponseError) => {
    this.mutationError = error;
  };

  fetchSportsmen = async () => {
    try {
      this.setLoading(true);

      const result = await SportsmanService.getAllSportsmen({
        pageSize: this.pageSize,
        pageNumber: this.currentPage,
      });

      this.setSportsmen(result.items);
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

  createSportsman = async (sportsman: CreateSportsman) => {
    try {
      this.setMutating(true);
      await SportsmanService.createSportsman(sportsman);
      this.fetchSportsmen();
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

  updateSportsman = async (id: number, sportsman: CreateSportsman) => {
    try {
      this.setMutating(true);
      await SportsmanService.updateSportsman(id, sportsman);
      this.fetchSportsmen();
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

  deleteSportsman = async (id: number) => {
    try {
      this.setLoading(true);
      await SportsmanService.deleteSportsman(id);
      this.fetchSportsmen();
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

export default SportsmanStore;
