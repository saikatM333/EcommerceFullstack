import React from 'react';
import { Typography, Container } from '@mui/material';

const Footer = () => {
  return (
    <footer>
      <Container>
        <Typography variant="body1" align="center" color="textSecondary" component="p">
          &copy; {new Date().getFullYear()} E-Commerce, Inc.
        </Typography>
      </Container>
    </footer>
  );
};

export default Footer;
