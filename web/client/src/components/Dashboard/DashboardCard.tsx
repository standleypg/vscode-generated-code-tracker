import React from 'react';
import { Card, Avatar } from 'antd';

const { Meta } = Card;

interface DashboardCardProps {
  avatarSrc: string;
  title: string;
  description: string;
}

const DashboardCard: React.FC<DashboardCardProps> = ({ avatarSrc, title, description }) => (
  <Card style={{ width: 380, marginTop: 16 }}>
    <Meta
      avatar={<Avatar src={avatarSrc} shape="square" size={64} />}
      title={<span style={{ fontSize: '24px' }}>{title}</span>}
      description={description}
    />
  </Card>
);

export default DashboardCard;
