// // ProductCard.js
import React from 'react';
import { Card, CardMedia, CardContent, Typography, CardActions, Button, Box } from '@mui/material';
import { Link } from 'react-router-dom';
import '../styles/ProductCard.css';

const ProductCard = ({ product }) => {
  return (
    <Card className="product-card">
      <CardMedia
        component="img"
        alt={product.name || product.Name}
        // height="100"
        image={product.ImageUrl || product.imageUrl}
        className="product-image"
        style={{ height: '100%', width : 'inherit' ,objectFit: 'contain' }} 
      />
      <CardContent>
        <Typography gutterBottom variant="h6" component="div" className="product-name">
          {product.name || product.Name}
        </Typography>
        <Typography variant="body2" color="textSecondary" className="product-price">
          ${product.price || product.Price}
        </Typography>
      </CardContent>
      <CardActions>
        <Button
          size="small"
          color="primary"
          component={Link}
          to={`/Product/${product.id || product.Id}`}
          className="view-button"
        >
          View
        </Button>
      </CardActions>
    </Card>
  );
};

export default ProductCard;
