    // import React, { useEffect, useState } from 'react';
    // import API from '../services/api';
    // import { Grid, Container } from '@mui/material';
    // import ProductCard from '../components/ProductCard';

    // const HomePage = () => {
    //   const [products, setProducts] = useState([]);

    //   useEffect(() => {
    //       API.get('/Product')
    //       .then(response => {setProducts(response.data)
    //         console.log(response.data.$values);
    //       })
    //       .catch(error => console.error('There was an error fetching the products!', error));
    //   }, []);
    
    //   return (
    //     <Container>
    //       <Grid container spacing={2}>
    //         {products.map(product => (
    //           <Grid item key={product.id} xs={12} sm={6} md={4}>
    //             <ProductCard product={product} />
    //           </Grid>
    //         ))}
    //       </Grid>
    //     </Container>
    //   );
    // };

    // export default HomePage;

    // HomePage.js
import React from 'react';
import { Container, Typography } from '@mui/material';
import { Carousel } from 'react-responsive-carousel';
import 'react-responsive-carousel/lib/styles/carousel.min.css';
import { css } from '@emotion/react';
import styled from '@emotion/styled';
import Header from '../components/Header';
import ProductSection from '../components/ProductSection';
import Categories from '../components/Categories';
import '../styles/styles.css';
const StyledCarouselContainer = styled(Container)`
  width: 100%;
  margin-left: 0 !important;
  margin-right: 0 !important;
  padding-left: 0 !important;
  padding-right: 0 !important;
  box-sizing: border-box;
  display: block;
  padding-left: 0 !important;
  padding-right: 0 !important;
`;
const HomePage = () => {
  const carouselImages = [
    'https://via.placeholder.com/1200x400?text=Image+1',
    'https://via.placeholder.com/1200x400?text=Image+2',
    'https://via.placeholder.com/1200x400?text=Image+3'
  ];

  return (
    <>
      
      
      <Categories />
      <Container className="css-1oqqzyl-MuiContainer-root custom-mui-container">
        <Carousel showThumbs={false} autoPlay infiniteLoop className='carousel-css'>
          {carouselImages.map((image, index) => (
            <div key={index}>
              <img src={image} alt={`carousel-${index}`} />
            </div>
          ))}
        </Carousel>
        
        <Typography variant="h4" component="h2" gutterBottom>
          Products
        </Typography>
        <ProductSection category="1" title="Electronics" />
        <ProductSection category="2" title="Fashion" />
        <ProductSection category="3" title="Home Appliances" />
      </Container>
      
    </>
  );
};

export default HomePage;

