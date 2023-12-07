import { observer } from "mobx-react";
import { ConfirmDialog } from "../../../components/ConfirmDialog/ConfirmDialog";
import { useRootStoreContext } from "../../../store";
import { useNavigate } from "react-router-dom";

export const DeleteCompetitionDialog = observer(() => {
  const navigate = useNavigate();
  const {
    competitionStore: { selectedForDelete, isMutating, deleteCompetition },
  } = useRootStoreContext();

  if (!selectedForDelete) {
    navigate(-1);
    return null;
  }

  return (
    <ConfirmDialog
      title="competition"
      onConfirm={async () => {
        await deleteCompetition(selectedForDelete.id);

        if (!isMutating) {
          navigate(-1);
        }
      }}
      isLoading={isMutating}
      content={selectedForDelete.name}
    />
  );
});
