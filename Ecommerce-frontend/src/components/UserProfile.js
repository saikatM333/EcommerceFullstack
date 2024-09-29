import React, { useEffect, useState } from 'react';
import API from '../services/api';
import { Typography, TextField, Button, Container } from '@mui/material';

const UserProfile = () => {
  const [user, setUser] = useState({ name: '', email: '' });

  useEffect(() => {
    API.get('/auth/me')
      .then(response => setUser(response.data))
      .catch(error => console.error('There was an error fetching the user!', error));
  }, []);

  const handleUpdate = () => {
    API.put('/auth/me', user)
      .then(response => {
        setUser(response.data);
      })
      .catch(error => console.error('There was an error updating the user!', error));
  };

  return (
    <Container>
      <Typography variant="h4" component="h1" gutterBottom>Profile</Typography>
      <TextField
        label="Name"
        variant="outlined"
        fullWidth
        value={user.name}
        onChange={(e) => setUser({ ...user, name: e.target.value })}
        margin="normal"
      />
      <TextField
        label="Email"
        variant="outlined"
        fullWidth
        value={user.email}
        onChange={(e) => setUser({ ...user, email: e.target.value })}
        margin="normal"
      />
      <Button variant="contained" color="primary" onClick={handleUpdate}>Update Profile</Button>
    </Container>
  );
};

export default UserProfile;
