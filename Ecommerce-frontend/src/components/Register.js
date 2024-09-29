import React, { useState } from 'react';
import { TextField, Button, Typography, Container } from '@mui/material';
import API from '../services/api';
import { useNavigate } from 'react-router-dom';

const Register = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [name, setName] = useState('');
  const navigate = useNavigate();

  const handleRegister = () => {
    API.post('/auth/register', { email, password, name })
      .then(response => {
        navigate('/login');
      })
      .catch(error => console.error('There was an error registering!', error));
  };

  return (
    <Container>
      <Typography variant="h4" component="h1" gutterBottom>Register</Typography>
      <TextField
        label="Name"
        variant="outlined"
        fullWidth
        value={name}
        onChange={(e) => setName(e.target.value)}
        margin="normal"
      />
      <TextField
        label="Email"
        variant="outlined"
        fullWidth
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        margin="normal"
      />
      <TextField
        label="Password"
        variant="outlined"
        fullWidth
        type="password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        margin="normal"
      />
      <Button variant="contained" color="primary" onClick={handleRegister}>Register</Button>
    </Container>
  );
};

export default Register;
