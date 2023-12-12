/* 
public const string Base = "/api/Competitors/{CompetitorId}/competitors";
public const string GetAll = Base;
public const string GetById = $"{Base}/{{id}}";
public const string Create = Base;
public const string SetWeight = $"{Base}/{{id}}/weight";
public const string SetLapNum = $"{Base}/{{id}}/lap"; 
public const string Delete = $"{Base}/{{id}}";
public const string GetLogs = $"{Base}/logs";
public const string GetFailedInsertLogs =
    $"{Base}/failed"; 
    */

import http from "./index";
import { Paged } from "../types/Paged";
import { Competitor } from "../models/Competitor/Competitor";
import { RequestParameters } from "../types/RequestParameters";

const BASE_URL = "competitions/";

const getBaseUrl = (competitionId: number) => {
  return BASE_URL + competitionId + "/competitors";
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

  deleteCompetitor: async (competitionId: number, id: number) => {
    return await http.delete(getBaseUrl(competitionId) + id);
  },
};

export default CompetitorService;
