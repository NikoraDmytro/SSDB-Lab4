import RootStore from ".";
import axios from "axios";
import { makeObservable, action, observable } from "mobx";

import BaseStore from "./BaseStore";
import { ResponseError } from "../types/AxiosErrorTypes";
import { Sportsman } from "../models/Sportsman/Sportsman";
import SportsmanService from "../services/SportsmanService";
import { CreateSportsman } from "../models/Sportsman/CreateSportsman";
import { Paged } from "../types/Paged";
import { RequestParameters } from "../types/RequestParameters";

class SportsmanStore extends BaseStore<Sportsman> {
  sportsmen: Sportsman[] = [];

  isMutating: boolean = false;

  mutationError?: ResponseError;

  selectedForEdit?: Sportsman;
  selectedForDelete?: Sportsman;

  constructor(rootStore: RootStore) {
    super(rootStore);
    makeObservable(this, {
      sportsmen: observable,
      isMutating: observable,
      mutationError: observable,
      selectedForEdit: observable,
      selectedForDelete: observable,
      selectForEdit: action,
      setMutationError: action,
      createSportsman: action,
      updateSportsman: action,
      deleteSportsman: action,
    });
  }

  setMutating = (mutating: boolean) => {
    this.isMutating = mutating;
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

  setPagedData(sportsmen: Sportsman[]): void {
    this.sportsmen = sportsmen;
  }

  async getPagedData(params: RequestParameters): Promise<Paged<Sportsman>> {
    return await SportsmanService.getAllSportsmen(params);
  }

  createSportsman = async (sportsman: CreateSportsman) => {
    try {
      this.setMutating(true);
      await SportsmanService.createSportsman(sportsman);
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

  updateSportsman = async (id: number, sportsman: CreateSportsman) => {
    try {
      this.setMutating(true);
      await SportsmanService.updateSportsman(id, sportsman);
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

  deleteSportsman = async (id: number) => {
    try {
      this.setLoading(true);
      await SportsmanService.deleteSportsman(id);
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

export default SportsmanStore;
