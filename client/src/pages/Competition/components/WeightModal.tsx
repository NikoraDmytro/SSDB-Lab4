import { useEffect } from "react";
import { observer } from "mobx-react";
import { Formik, Form, FormikHelpers } from "formik";
import { useNavigate, useParams } from "react-router-dom";
import { Button, CircularProgress, Typography } from "@mui/material";

import { useRootStoreContext } from "../../../store";
import { AppModal } from "../../../components/AppModal";
import { UpdateCompetitorWeight } from "../../../models/Competitor/UpdateCompetitorWeight";
import { InputFormField } from "../../../components/Inputs/InputFormField";
import { isBadRequestError } from "../../../utils/checkResponseErrorType";
import { getValidationErrors } from "../../../utils/getValidationErrors";

let initialValues: UpdateCompetitorWeight = {
  weightingResult: 0,
};

const WeightModal = observer(() => {
  const navigate = useNavigate();
  const {
    competitorStore: {
      selectedForEdit,
      updateCompetitorWeight,
      mutationError,
      isMutating,
      setMutationError,
    },
  } = useRootStoreContext();
  const { id: competitionId } = useParams();

  useEffect(() => {
    if (!competitionId || !parseInt(competitionId) || !selectedForEdit) {
      navigate(-1);
    }
    return () => {
      setMutationError();
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  if (selectedForEdit?.weightingResult) {
    initialValues = {
      weightingResult: selectedForEdit.weightingResult,
    };
  }

  const submitHandler = async (
    values: UpdateCompetitorWeight,
    { setSubmitting }: FormikHelpers<UpdateCompetitorWeight>
  ) => {
    setMutationError();

    const success = await updateCompetitorWeight(
      parseInt(competitionId!),
      selectedForEdit!.id,
      values
    );

    if (success) {
      navigate(-1);
      setSubmitting(false);
    } else {
      setSubmitting(false);
    }
  };

  console.log(mutationError);

  return (
    <AppModal visible={true} close={() => navigate(-1)}>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {({ setErrors }) => {
          if (mutationError) {
            setErrors(getValidationErrors(mutationError));
          }

          return (
            <Form className="form">
              <InputFormField
                label="Weight"
                name="weightingResult"
                type="number"
              />

              <Button
                type="submit"
                variant="contained"
                color="primary"
                size="large"
                sx={{ width: "60%" }}
              >
                {isMutating ? <CircularProgress /> : "Зберегти"}
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

export { WeightModal };
