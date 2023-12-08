import { observer } from "mobx-react";
import { ConfirmDialog } from "../../../components/ConfirmDialog/ConfirmDialog";
import { useRootStoreContext } from "../../../store";
import { useNavigate } from "react-router-dom";

export const DeleteDivisionDialog = observer(() => {
  const navigate = useNavigate();
  const {
    divisionStore: { selectedForDelete, isMutating, deleteDivision },
  } = useRootStoreContext();

  if (!selectedForDelete) {
    navigate(-1);
    return null;
  }

  return (
    <ConfirmDialog
      title="division"
      onConfirm={async () => {
        await deleteDivision(selectedForDelete.id);

        if (!isMutating) {
          navigate(-1);
        }
      }}
      isLoading={isMutating}
      content={selectedForDelete.name}
    />
  );
});
