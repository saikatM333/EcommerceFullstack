// PriceDetails.jsx
import React from 'react';
import { Card, CardContent, Typography } from '@mui/material';

import '../styles/PriceDetails.css'
const PriceDetails = ({ totalItems, totalPrice }) => {
  return (
    <Card className="price-details">
      <CardContent>
        <Typography variant="h6">Price Details</Typography>
        <Typography variant="body2">Total Items: {totalItems}</Typography>
        <Typography variant="body2">Total Price: ${totalPrice.toFixed(2)}</Typography>
      </CardContent>
    </Card>
  );
};

export default PriceDetails;
