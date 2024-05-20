import React from 'react';
import { Row, Col, TableProps, Table, Layout } from 'antd';
import DashboardCard from './DashboardCard';
import { getCurrentDateTime } from '../../utils/dateTime';

const { Content } = Layout;

interface DashboardContentProps {
  colorBgContainer: string;
  borderRadiusLG: string;
}

interface DataType {
    key: string;
    userId: string;
    projectId: string;
    solutionId: string;
    no_of_gen_lines: number;
}

const columns: TableProps<DataType>["columns"] = [
  {
    title: "User ID",
    dataIndex: "userId",
    key: "userId",
    render: (text) => <a>{text}</a>,
  },
  {
    title: "Project ID",
    dataIndex: "projectId",
    key: "projectId",
  },
  {
    title: "Solution ID",
    dataIndex: "solutionId",
    key: "solutionId",
  },
  {
    title: "Number of Generated Lines",
    dataIndex: "no_of_gen_lines",
    key: "no_of_gen_lines",
  },
];

const data: DataType[] = [
  {
    key: "1",
    userId: "John Brown",
    projectId: "Optimar",
    solutionId: "Backend",
    no_of_gen_lines: 24,
  },
  {
    key: "2",
    userId: "Jim Green",
    projectId: "Kahoot",
    solutionId: "Frontend",
    no_of_gen_lines: 12,
  },
  {
    key: "3",
    userId: "Joe Black",
    projectId: "Internal Projects",
    solutionId: "Extension",
    no_of_gen_lines: 58,
  },
  {
    key: "4",
    userId: "Joe Black",
    projectId: "Internal Projects",
    solutionId: "Backend",
    no_of_gen_lines: 128,
  },
];

const DashboardContent: React.FC<DashboardContentProps> = ({ colorBgContainer, borderRadiusLG }) => {
  const currentDateTime = getCurrentDateTime();
  
  return (
    <Content
      style={{
        margin: "25px 20px",
        padding: "0px 15px",
        minHeight: 400,
        background: colorBgContainer,
        borderRadius: borderRadiusLG,
      }}
    >
      <div style={{ display: 'flex', alignItems: 'center', marginTop: 10 }}>
        <h5 style={{ margin: 0 }}>Last data updated, </h5>
        <span style={{ fontStyle: 'italic', marginLeft: 5 }}>{currentDateTime}</span>
      </div>
      <Row gutter={[16, 16]} style={{ marginTop: 0 }}>
        <Col>
          <DashboardCard 
            avatarSrc="https://user-images.githubusercontent.com/4573851/226388344-20f2e01d-1594-4d3c-83e9-502868782445.png"
            title="539"
            description="Auto-generated lines by Github Copilot"
          />
        </Col>
        <Col>
          <DashboardCard 
            avatarSrc="https://cdn3.iconfinder.com/data/icons/luchesa-vol-9/128/Html-512.png"
            title="24"
            description="Total number of solutions registered"
          />
        </Col>
      </Row>
      <Table style={{ marginTop: 24 }} columns={columns} dataSource={data} />
    </Content>
  );
};

export default DashboardContent;
