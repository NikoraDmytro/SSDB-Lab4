import { useEffect } from "react";
import { Formik, Form, FormikHelpers } from "formik";
import { Button, CircularProgress, Typography } from "@mui/material";
import { observer } from "mobx-react";
import { useNavigate } from "react-router-dom";

import { useRootStoreContext } from "../../../../store";
import { AppModal } from "../../../../components/AppModal";
import { InputFormField } from "../../../../components/Inputs/InputFormField";
import { CreateCompetition } from "../../../../models/CreateCompetition";

import regionalCenters from "../../../../const/cities";
import { FormatIso } from "../../../../utils/dateUtils";
import { isBadRequestError } from "../../../../utils/checkResponseErrorType";
import { getValidationErrors } from "../../../../utils/getValidationErrors";
import { competitionValidationSchema } from "../../utils/competitionValidation";
import { SelectInput } from "../../../../components/Inputs/SelectInput";

import "./CompetitionModal.scss";

interface Props {
  isEdit?: boolean;
}

let initialValues: CreateCompetition = {
  name: "",
  startDate: "",
  duration: 1,
  city: "",
};

export const CompetitionModal = observer(({ isEdit }: Props) => {
  const navigate = useNavigate();
  const {
    competitionStore: {
      selectedForEdit,
      updateCompetition,
      createCompetition,
      mutationError,
      setMutationError,
      isMutating,
    },
  } = useRootStoreContext();

  useEffect(() => {
    return () => {
      setMutationError();
    };
  }, [setMutationError]);

  if (isEdit && !selectedForEdit) {
    navigate(-1);
    return null;
  }

  if (isEdit && selectedForEdit) {
    initialValues = {
      ...selectedForEdit,
      startDate: FormatIso(selectedForEdit.startDate),
    };
  }

  const submitHandler = async (
    values: CreateCompetition,
    { setSubmitting }: FormikHelpers<CreateCompetition>
  ) => {
    setMutationError();

    let success;
    if (isEdit && selectedForEdit) {
      success = await updateCompetition(selectedForEdit.id, values);
    } else {
      success = await createCompetition(values);
    }
    if (success) {
      navigate(-1);
      setSubmitting(false);
    } else {
      setSubmitting(false);
    }
  };

  return (
    <AppModal visible={true} close={() => navigate(-1)}>
      <Formik
        initialValues={initialValues}
        validationSchema={competitionValidationSchema}
        onSubmit={submitHandler}
      >
        {({ setErrors }) => {
          if (mutationError) {
            setErrors(getValidationErrors(mutationError));
          }
          return (
            <Form className="form">
              <InputFormField
                label="Competition name"
                name="name"
                type="text"
              />
              <div className="inputs-group">
                <InputFormField
                  label="Start date"
                  name="startDate"
                  type="date"
                />
                <InputFormField
                  label="Duration"
                  name="duration"
                  type="number"
                />
              </div>
              <SelectInput
                label="City"
                name="city"
                items={regionalCenters.map((city) => ({
                  label: city,
                  value: city,
                }))}
              />
              <Button
                type="submit"
                variant="contained"
                color="primary"
                size="large"
                disabled={isMutating}
                sx={{ width: "60%" }}
              >
                {isMutating ? <CircularProgress /> : "Save"}
              </Button>
              {mutationError && isBadRequestError(mutationError) && (
                <Typography variant="h6" color="red">
                  {mutationError.response?.data.message}
                </Typography>
              )}
            </Form>
          );
        }}
      </Formik>
    </AppModal>
  );
});
