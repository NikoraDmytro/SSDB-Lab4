import { useEffect } from "react";
import { Formik, Form, FormikHelpers } from "formik";
import { Button, CircularProgress, Typography } from "@mui/material";
import { observer } from "mobx-react";
import { useNavigate } from "react-router-dom";

import { useRootStoreContext } from "../../../../store";
import { AppModal } from "../../../../components/AppModal";
import { InputFormField } from "../../../../components/Inputs/InputFormField";

import { isBadRequestError } from "../../../../utils/checkResponseErrorType";
import { getValidationErrors } from "../../../../utils/getValidationErrors";
import { CreateDivision } from "../../../../models/Division/CreateDivision";
import { divisionValidationSchema } from "../../utils/divisionValidation";
import { SelectInput } from "../../../../components/Inputs/SelectInput";

import "./DivisionModal.scss";

interface Props {
  isEdit?: boolean;
}

let initialValues: CreateDivision = {
  name: "",
  minWeight: undefined,
  maxWeight: undefined,
  minAge: undefined,
  maxAge: undefined,
  sex: "M",
};

export const DivisionModal = observer(({ isEdit }: Props) => {
  const navigate = useNavigate();
  const {
    divisionStore: {
      selectedForEdit,
      updateDivision,
      createDivision,
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
    initialValues = { ...selectedForEdit };
  }

  const submitHandler = async (
    values: CreateDivision,
    { setSubmitting }: FormikHelpers<CreateDivision>
  ) => {
    setMutationError();

    let success;
    if (isEdit && selectedForEdit) {
      success = await updateDivision(selectedForEdit.id, values);
    } else {
      success = await createDivision(values);
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
        validationSchema={divisionValidationSchema}
        onSubmit={submitHandler}
      >
        {({ setErrors }) => {
          if (mutationError) {
            setErrors(getValidationErrors(mutationError));
          }
          return (
            <Form className="form">
              <InputFormField label="Division Name" name="name" type="text" />
              <div className="inputs-group">
                <InputFormField
                  label="Min Weight"
                  name="minWeight"
                  type="number"
                />
                <InputFormField
                  label="Max Weight"
                  name="maxWeight"
                  type="number"
                />
              </div>
              <div className="inputs-group">
                <InputFormField label="Min Age" name="minAge" type="number" />
                <InputFormField label="Max Age" name="maxAge" type="number" />
              </div>
              <SelectInput
                label="Sex"
                name="sex"
                items={[
                  { label: "Male", value: "M" },
                  { label: "Female", value: "F" },
                ]}
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
