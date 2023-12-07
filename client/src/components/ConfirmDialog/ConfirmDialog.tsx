import {
  Button,
  CircularProgress,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
} from "@mui/material";
import { useNavigate } from "react-router-dom";

interface Props {
  title: string;
  content: string;
  isLoading: boolean;
  onConfirm: () => void;
}

export const ConfirmDialog = (props: Props) => {
  const navigate = useNavigate();

  const handleClose = () => {
    navigate(-1);
  };

  return (
    <Dialog open={true} onClose={handleClose}>
      <DialogTitle sx={{ textTransform: "uppercase" }}>
        Remove {props.title}
      </DialogTitle>
      <DialogContent>{props.content}</DialogContent>
      <DialogActions>
        <Button color="error" onClick={handleClose}>
          Cancel
        </Button>
        <Button onClick={props.onConfirm}>
          {props.isLoading ? <CircularProgress /> : "Confirm"}
        </Button>
      </DialogActions>
    </Dialog>
  );
};
