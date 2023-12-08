import { useEffect } from "react";
import { Formik, Form, FormikHelpers } from "formik";
import { Button, CircularProgress, Typography } from "@mui/material";
import { observer } from "mobx-react";
import { useNavigate } from "react-router-dom";

import { useRootStoreContext } from "../../../../store";
import { AppModal } from "../../../../components/AppModal";
import { InputFormField } from "../../../../components/Inputs/InputFormField";

import { FormatIso } from "../../../../utils/dateUtils";
import { isBadRequestError } from "../../../../utils/checkResponseErrorType";
import { getValidationErrors } from "../../../../utils/getValidationErrors";
import { CreateSportsman } from "../../../../models/Sportsman/CreateSportsman";
import { sportsmanValidationSchema } from "../../utils/sportsmanValidation";
import { SelectInput } from "../../../../components/Inputs/SelectInput";

import "./SportsmanModal.scss";

interface Props {
  isEdit?: boolean;
}

let initialValues: CreateSportsman = {
  firstName: "",
  lastName: "",
  birthDate: "",
  sex: "M",
};

export const SportsmanModal = observer(({ isEdit }: Props) => {
  const navigate = useNavigate();
  const {
    sportsmanStore: {
      selectedForEdit,
      updateSportsman,
      createSportsman,
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
    const [firstName, lastName] = selectedForEdit.fullName.split(" ");

    initialValues = {
      sex: selectedForEdit.sex,
      lastName: lastName,
      firstName: firstName,
      birthDate: FormatIso(selectedForEdit.birthDate),
    };
  }

  const submitHandler = async (
    values: CreateSportsman,
    { setSubmitting }: FormikHelpers<CreateSportsman>
  ) => {
    setMutationError();

    let success;
    if (isEdit && selectedForEdit) {
      success = await updateSportsman(selectedForEdit.id, values);
    } else {
      success = await createSportsman(values);
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
        validationSchema={sportsmanValidationSchema}
        onSubmit={submitHandler}
      >
        {({ setErrors }) => {
          if (mutationError) {
            setErrors(getValidationErrors(mutationError));
          }
          return (
            <Form className="form">
              <div className="inputs-group">
                <InputFormField
                  label="First Name"
                  name="firstName"
                  type="text"
                />
                <InputFormField label="Last Name" name="lastName" type="text" />
              </div>
              <div className="inputs-group">
                <InputFormField
                  label="Birth Date"
                  name="birthDate"
                  type="date"
                />
                <SelectInput
                  label="Sex"
                  name="sex"
                  items={[
                    { label: "Male", value: "M" },
                    { label: "Female", value: "F" },
                  ]}
                />
              </div>
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
