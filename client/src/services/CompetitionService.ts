import http from "./index";
import { Paged } from "../types/Paged";
import { Competition } from "../models/Competition/Competition";
import { RequestParameters } from "../types/RequestParameters";
import { CreateCompetition } from "../models/Competition/CreateCompetition";

const BASE_URL = "competitions/";

const CompetitionService = {
  getAllCompetitions: async (
    params: RequestParameters
  ): Promise<Paged<Competition>> => {
    return await http.get(BASE_URL, { params: params });
  },

  getCompetition: async (id: number): Promise<Competition> => {
    return await http.get(BASE_URL + id);
  },

  getLargestCompetition: async (): Promise<Competition> => {
    return await http.get(BASE_URL + "largest");
  },

  createCompetition: async (competition: CreateCompetition) => {
    return await http.post(BASE_URL, competition);
  },

  updateCompetition: async (id: number, competition: CreateCompetition) => {
    return await http.put(BASE_URL + id, competition);
  },

  deleteCompetition: async (id: number) => {
    return await http.delete(BASE_URL + id);
  },
};

export default CompetitionService;
