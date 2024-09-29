import React, { useState } from 'react';
import { TextField, Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import '../styles/Header.css'; // Import the custom CSS file

const SearchBar = () => {
  const [query, setQuery] = useState('');
  const navigate = useNavigate();

  const handleSearch = () => {
    navigate(`/search?q=${query}`);
  };

  return (
    <div style={{ display: 'flex', alignItems: 'center', marginLeft: '20px' , gap : '2rem'}}>
      <TextField
        variant="outlined"
        placeholder="Search for products"
        value={query}
        onChange={(e) => setQuery(e.target.value)}
        className="search-input"
      />
      <Button variant="contained" color="primary" onClick={handleSearch} className="search-button">
        Search
      </Button>
    </div>
  );
};

export default SearchBar;
