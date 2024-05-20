import React from 'react';
import { MenuFoldOutlined, MenuUnfoldOutlined } from "@ant-design/icons";
import { Button, Layout } from 'antd';

const { Header } = Layout;

interface HeaderProps {
  collapsed: boolean;
  toggleCollapse: () => void;
  colorBgContainer: string;
}

const AppHeader: React.FC<HeaderProps> = ({ collapsed, toggleCollapse, colorBgContainer }) => (
  <Header style={{ padding: 0, background: colorBgContainer }}>
    <Button
      type="text"
      icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
      onClick={toggleCollapse}
      style={{
        fontSize: "16px",
        width: 64,
        height: 64,
      }}
    />
  </Header>
);

export default AppHeader;
