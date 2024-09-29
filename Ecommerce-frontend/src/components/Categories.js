// Categories.js
import React, { useEffect, useState } from 'react';
import API from '../services/api';
import { List, ListItem, ListItemText, Typography, Container } from '@mui/material';
import '../styles/Categories.css';

const Categories = () => {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    API.get('/Catagory')
      .then(response => {setCategories(response.data)
        console.log(response.data)
      })
      .catch(error => console.error('There was an error fetching the categories!', error));
  }, []);

  return (
    <Container className="categories-container">
      <Typography variant="h5" component="h3" gutterBottom>
        Categories
      </Typography>
      <List className="categories-list">
        {categories.map(category => (
          <ListItem button key={category.id} className="category-item">
            <ListItemText primary={category.name} />
          </ListItem>
        ))}
      </List>
    </Container>
  );
};

export default Categories;
