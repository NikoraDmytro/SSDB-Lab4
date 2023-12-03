import axios from "axios";
import { AxiosResponse } from "axios";

const getResponseData = (response: AxiosResponse): AxiosResponse =>
  response.data;

const http = axios.create({
  baseURL: "http://localhost:5083/api/",
});

http.interceptors.response.use(getResponseData);

export {

};

export default http;
