import React, { useEffect, useState } from 'react';
import API from '../services/api';
import { Grid } from '@mui/material';
import ProductCard from '../components/ProductCard';

const Wishlist = () => {
  const [wishlist, setWishlist] = useState([]);

  useEffect(() => {
    API.get('/wishlist')
      .then(response => setWishlist(response.data))
      .catch(error => console.error('There was an error fetching the wishlist!', error));
  }, []);

  return (
    <Grid container spacing={2}>
      {wishlist.map(product => (
        <Grid item key={product.id} xs={12} sm={6} md={4}>
          <ProductCard product={product} />
        </Grid>
      ))}
    </Grid>
  );
};

export default Wishlist;
