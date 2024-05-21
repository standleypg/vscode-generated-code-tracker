import React from 'react';
import { AreaChartOutlined, ArrowLeftOutlined } from "@ant-design/icons";
import { Menu, Layout } from 'antd';

const { Sider } = Layout;

interface SiderMenuProps {
  collapsed: boolean;
  toggleCollapse: () => void;
}

const SiderMenu: React.FC<SiderMenuProps> = ({ collapsed }) => (
  <Sider trigger={null} collapsible collapsed={collapsed}>
    <div className="demo-logo-vertical" />
    <Menu
      theme="dark"
      mode="inline"
      defaultSelectedKeys={["1"]}
      items={[
        {
          key: "1",
          icon: <AreaChartOutlined />,
          label: "Dashboard",
        },
        {
          key: "2",
          icon: <ArrowLeftOutlined />,
          label: "Sign out",
        },
      ]}
    />
  </Sider>
);

export default SiderMenu;
