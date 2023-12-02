export interface WithId {
  id: string | number;
}

export interface TableColumns<T extends WithId, P extends T> {
  name: keyof P;
  label?: string;
  renderItem?: (item: T) => React.ReactNode;
}
