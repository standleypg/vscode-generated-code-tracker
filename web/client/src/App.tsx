import React, { useState } from "react";
import SiderMenu from "./components/SiderMenu";
import DashboardContent from "./components/Dashboard/DashboardContent";
import AppHeader from "./components/Header";
import {
  Layout,
  theme,
} from "antd";

const App: React.FC = () => {
  const [collapsed, setCollapsed] = useState(false);
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  return (
    <Layout>
      <SiderMenu collapsed={collapsed} toggleCollapse={() => setCollapsed(!collapsed)} />
      <Layout>
      <AppHeader collapsed={collapsed} toggleCollapse={() => setCollapsed(!collapsed)} colorBgContainer={colorBgContainer} />
        <DashboardContent colorBgContainer={colorBgContainer} borderRadiusLG={`${borderRadiusLG}`} />
      </Layout>
    </Layout>
  );
};

export default App;
