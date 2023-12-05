import { observer } from "mobx-react";
import { ConfirmDialog } from "../../components/ConfirmDialog/ConfirmDialog";
import { useRootStoreContext } from "../../store";

export const DeleteCompetitionDialog = observer(() => {
  const {
    competitionStore: { selectedForDelete, isMutating },
  } = useRootStoreContext();

  return (
    <ConfirmDialog
      title="competition"
      onConfirm={() => {}}
      isLoading={isMutating}
      content={selectedForDelete?.name || ""}
    />
  );
});
