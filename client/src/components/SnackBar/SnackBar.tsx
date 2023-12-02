import { Box, Snackbar, Alert } from "@mui/material";
import { observer } from "mobx-react-lite";

import { useRootStoreContext } from "../../store";

import "./SnackBar.scss";

const SnackBar = observer(() => {
  const {
    snackBarStore: { snackBarOptions, closeSnackBar },
  } = useRootStoreContext();
  const { open, severity, message } = snackBarOptions;

  return (
    <Snackbar
      anchorOrigin={{
        vertical: "bottom",
        horizontal: "center",
      }}
      open={open}
      autoHideDuration={5000}
      onClose={closeSnackBar}
      ClickAwayListenerProps={{ onClickAway: () => null }}
    >
      <Alert severity={severity} variant={"filled"} color={severity}>
        <Box className="snackBarWrapper">
          {message}
          <Box className="imageContainer">
            <span className="closeBtn" onClick={closeSnackBar}>
              &times;
            </span>
          </Box>
        </Box>
      </Alert>
    </Snackbar>
  );
});

export { SnackBar };
