import { observer } from "mobx-react";
import { ConfirmDialog } from "../../../components/ConfirmDialog/ConfirmDialog";
import { useRootStoreContext } from "../../../store";
import { useNavigate } from "react-router-dom";

export const DeleteSportsmanDialog = observer(() => {
  const navigate = useNavigate();
  const {
    sportsmanStore: { selectedForDelete, isMutating, deleteSportsman },
  } = useRootStoreContext();

  if (!selectedForDelete) {
    navigate(-1);
    return null;
  }

  return (
    <ConfirmDialog
      title="sportsman"
      onConfirm={async () => {
        await deleteSportsman(selectedForDelete.id);

        if (!isMutating) {
          navigate(-1);
        }
      }}
      isLoading={isMutating}
      content={selectedForDelete.fullName}
    />
  );
});
