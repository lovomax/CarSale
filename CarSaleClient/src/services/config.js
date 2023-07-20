import axios from "axios";
export const api = axios.create({
  baseURL: `https://localhost:7087`,
});

const setHeader = (config) => {
  const userData =
    "Bearer " + localStorage.getItem("data")?.replaceAll('"', "");
  if (userData) {
    config.headers.Authorization = userData;
  }

  return config;
};

const rejectPromise = (error) => {
  return Promise.reject(error);
};

api.interceptors.response.use(
  (config) => config,
  async (error) => {
    const token = window.localStorage.getItem("data")?.replaceAll('"', "")
    if (token && error?.response.status === 401) {
      window.localStorage.removeItem("data")
      window.location.reload()
      return Promise.reject(error)
    }
  }
)

api.interceptors.request.use(setHeader, rejectPromise);
