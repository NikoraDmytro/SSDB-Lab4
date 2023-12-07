import http from "./index";
import { Paged } from "../types/Paged";
import { Sportsman } from "../models/Sportsman/Sportsman";
import { CreateSportsman } from "../models/Sportsman/CreateSportsman";
import { RequestParameters } from "../types/RequestParameters";

const BASE_URL = "sportsmen/";

const SportsmanService = {
  getAllSportsmen: async (
    params: RequestParameters
  ): Promise<Paged<Sportsman>> => {
    return await http.get(BASE_URL, { params: params });
  },

  createSportsman: async (Sportsman: CreateSportsman) => {
    return await http.post(BASE_URL, Sportsman);
  },

  updateSportsman: async (id: number, Sportsman: CreateSportsman) => {
    return await http.put(BASE_URL + id, Sportsman);
  },

  deleteSportsman: async (id: number) => {
    return await http.delete(BASE_URL + id);
  },
};

export default SportsmanService;
