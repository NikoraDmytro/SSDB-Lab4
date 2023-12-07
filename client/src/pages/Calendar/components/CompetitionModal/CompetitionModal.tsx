import { Formik, Form } from "formik";
import { Button, CircularProgress } from "@mui/material";
import { observer } from "mobx-react";
import { useNavigate } from "react-router-dom";

import { useRootStoreContext } from "../../../../store";
import { AppModal } from "../../../../components/AppModal";
import { InputFormField } from "../../../../components/Inputs/InputFormField";
import { CreateCompetition } from "../../../../models/CreateCompetition";

import regionalCenters from "../../../../const/cities";
import { FormatIso } from "../../../../utils/dateUtils";
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
      isMutating,
    },
  } = useRootStoreContext();

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

  const submitHandler = async (values: CreateCompetition) => {
    if (isEdit && selectedForEdit) {
      await updateCompetition(selectedForEdit.id, values);
    } else {
      await createCompetition(values);
    }
    if (!isMutating) {
      navigate(-1);
    }
  };

  return (
    <AppModal visible={true} close={() => navigate(-1)}>
      <Formik
        initialValues={initialValues}
        validationSchema={competitionValidationSchema}
        onSubmit={submitHandler}
      >
        <Form className="form">
          <InputFormField label="Competition name" name="name" type="text" />
          <div className="inputs-group">
            <InputFormField label="Start date" name="startDate" type="date" />
            <InputFormField label="Duration" name="duration" type="number" />
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
        </Form>
      </Formik>
    </AppModal>
  );
});
