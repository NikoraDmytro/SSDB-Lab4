import { observer } from "mobx-react";
import { ConfirmDialog } from "../../../components/ConfirmDialog/ConfirmDialog";
import { useRootStoreContext } from "../../../store";
import { useNavigate } from "react-router-dom";

export const DeleteCompetitorDialog = observer(() => {
  const navigate = useNavigate();
  const {
    competitorStore: { selectedForDelete, isMutating, deleteCompetitor },
  } = useRootStoreContext();

  if (!selectedForDelete) {
    navigate(-1);
    return null;
  }

  return (
    <ConfirmDialog
      title="competitor"
      onConfirm={async () => {
        await deleteCompetitor(selectedForDelete.id);

        if (!isMutating) {
          navigate(-1);
        }
      }}
      isLoading={isMutating}
      content={selectedForDelete.fullName}
    />
  );
});
