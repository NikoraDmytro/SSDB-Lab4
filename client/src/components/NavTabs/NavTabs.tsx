import { Tab, Tabs } from "@mui/material";
import { TabLabel } from "../../types/TabLabel";
import { Link } from "react-router-dom";
import { useState } from "react";

interface Props {
  tabLabels: TabLabel[];
}

export const NavTabs = ({ tabLabels }: Props) => {
  const [currentTab, setCurrentTab] = useState(0);

  const handleChange = (_: React.SyntheticEvent, newTab: number) => {
    setCurrentTab(newTab);
  };

  return (
    <Tabs value={currentTab} onChange={handleChange}>
      {tabLabels.map((item) => (
        <Tab
          key={item.label}
          label={item.label}
          to={item.link}
          component={Link}
        />
      ))}
    </Tabs>
  );
};
