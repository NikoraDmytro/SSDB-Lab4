import RootStore from ".";
import axios from "axios";
import { makeAutoObservable } from "mobx";

import { Division } from "../models/Division/Division";
import DivisionService from "../services/DivisionService";
import { CreateDivision } from "../models/Division/CreateDivision";
import { ResponseError } from "../types/AxiosErrorTypes";

class DivisionStore {
  rootStore: RootStore;

  divisions: Division[] = [];

  isLoading: boolean = false;
  isMutating: boolean = false;

  mutationError?: ResponseError;

  selectedForEdit?: Division;
  selectedForDelete?: Division;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeAutoObservable(this);
  }

  setLoading = (loading: boolean) => {
    this.isLoading = loading;
  };

  setMutating = (mutating: boolean) => {
    this.isMutating = mutating;
  };

  setDivisions = (divisions: Division[]) => {
    this.divisions = divisions;
  };

  selectForDelete = (Division: Division) => {
    this.selectedForDelete = Division;
  };

  selectForEdit = (Division: Division) => {
    this.selectedForEdit = Division;
  };

  setMutationError = (error?: ResponseError) => {
    this.mutationError = error;
  };

  fetchDivisions = async () => {
    try {
      this.setLoading(true);

      const result = await DivisionService.getAllDivisions();
      this.setDivisions(result);
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

  createDivision = async (division: CreateDivision) => {
    try {
      this.setMutating(true);
      await DivisionService.createDivision(division);
      this.fetchDivisions();
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

  updateDivision = async (id: number, division: CreateDivision) => {
    try {
      this.setMutating(true);
      await DivisionService.updateDivision(id, division);
      this.fetchDivisions();
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

  deleteDivision = async (id: number) => {
    try {
      this.setLoading(true);
      await DivisionService.deleteDivision(id);
      this.fetchDivisions();
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

export default DivisionStore;
