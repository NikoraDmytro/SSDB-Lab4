import { createContext, useContext } from "react";
import { RootStore } from "./RootStore";

export default RootStore;

export const RootStoreContext = createContext<RootStore>({} as RootStore);

export const useRootStoreContext = (): RootStore =>
  useContext(RootStoreContext);
