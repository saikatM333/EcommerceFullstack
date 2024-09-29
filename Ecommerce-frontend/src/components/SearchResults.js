import React, { useEffect, useState } from 'react';
import API from '../services/api';
import { useLocation } from 'react-router-dom';
import { Grid, Container, Typography } from '@mui/material';
import ProductCard from './ProductCard';

const useQuery = () => {
  return new URLSearchParams(useLocation().search);
};

const SearchResults = () => {
  const query = useQuery().get('q');
  const [products, setProducts] = useState([]);

  useEffect(() => {
    if (query) {
      API.get(`/Product/search?query=${query}`)
        .then(response => {setProducts(response.data)
          console.log(response.data)
        })
        .catch(error => console.error('There was an error fetching the products!', error));
    }
  }, [query]);

  return (
    <Container>
      <Typography variant="h4" component="h1" gutterBottom>
        Search Results for "{query}"
      </Typography>
      <Grid container spacing={2}>
        {products.map(product => (
          <Grid item key={product.id} xs={12} sm={6} md={4}>
            <ProductCard product={product} />
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export default SearchResults;
