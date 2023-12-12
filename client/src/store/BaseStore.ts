import RootStore from ".";
import axios from "axios";
import { makeObservable, observable, action } from "mobx";

import { Paged } from "../types/Paged";
import { RequestParameters } from "../types/RequestParameters";

abstract class BaseStore<T> {
  rootStore: RootStore;

  total: number = 0;
  pageSize: number = 10;
  currentPage: number = 1;

  isLoading: boolean = false;

  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
    makeObservable(this, {
      rootStore: observable,
      total: observable,
      pageSize: observable,
      currentPage: observable,
      isLoading: observable,
      setTotal: action,
      setCurrentPage: action,
      setPageSize: action,
      setLoading: action,
      setPagedData: action,
      getPagedData: action,
      fetchPagedData: action,
    });
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

  abstract setPagedData(data: T[]): void;

  abstract getPagedData(params: RequestParameters): Promise<Paged<T>>;

  fetchPagedData = async () => {
    try {
      this.setLoading(true);

      const result = await this.getPagedData({
        pageSize: this.pageSize,
        pageNumber: this.currentPage,
      });
      this.setPagedData(result.items);

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
}

export default BaseStore;
