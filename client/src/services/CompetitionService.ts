import http from "./index";
import { Paged } from "../types/Paged";
import { Competition } from "../models/Competition";
import { RequestParameters } from "../types/RequestParameters";

const BASE_URL = "competitions/";

const CompetitionService = {
  getAllCompetitions: async (
    params: RequestParameters
  ): Promise<Paged<Competition>> => {
    return await http.get(BASE_URL, { params: params });
  },

  createCompetition: async (competition: Competition) => {
    return await http.post(BASE_URL, competition);
  },

  updateCompetition: async (id: number, competition: Competition) => {
    return await http.put(BASE_URL + id, competition);
  },

  deleteCompetition: async (id: number) => {
    return await http.delete(BASE_URL + id);
  },
};

export default CompetitionService;