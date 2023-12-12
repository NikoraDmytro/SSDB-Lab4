import http from "./index";
import { Paged } from "../types/Paged";
import { Competitor } from "../models/Competitor/Competitor";
import { RequestParameters } from "../types/RequestParameters";
import { UpdateCompetitorWeight } from "../models/Competitor/UpdateCompetitorWeight";

const getBaseUrl = (competitionId: number) => {
  return "competitions/" + competitionId + "/competitors/";
};

const CompetitorService = {
  getAllCompetitors: async (
    competitionId: number,
    params: RequestParameters
  ): Promise<Paged<Competitor>> => {
    return await http.get(getBaseUrl(competitionId), { params: params });
  },

  getCompetitor: async (
    competitionId: number,
    id: number
  ): Promise<Competitor> => {
    return await http.get(getBaseUrl(competitionId) + id);
  },

  createCompetitors: async (competitionId: number, sportsmanIds: number[]) => {
    return await http.post(
      getBaseUrl(competitionId),
      sportsmanIds.map((id) => ({
        sportsmanId: id,
      }))
    );
  },

  updateWeight: async (
    competitionId: number,
    id: number,
    updateWeight: UpdateCompetitorWeight
  ) => {
    return await http.put(
      getBaseUrl(competitionId) + id + "/weight",
      updateWeight
    );
  },

  deleteCompetitor: async (competitionId: number, id: number) => {
    return await http.delete(getBaseUrl(competitionId) + id);
  },
};

export default CompetitorService;
