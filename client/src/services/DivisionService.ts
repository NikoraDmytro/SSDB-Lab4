import http from "./index";
import { Division } from "../models/Division/Division";
import { CreateDivision } from "../models/Division/CreateDivision";

const BASE_URL = "divisions/";

const DivisionService = {
  getAllDivisions: async (): Promise<Division[]> => {
    return await http.get(BASE_URL);
  },

  createDivision: async (division: CreateDivision) => {
    return await http.post(BASE_URL, division);
  },

  updateDivision: async (id: number, division: CreateDivision) => {
    return await http.put(BASE_URL + id, division);
  },

  deleteDivision: async (id: number) => {
    return await http.delete(BASE_URL + id);
  },
};

export default DivisionService;
