import React, { useState } from 'react';
import { TextField, Button, Typography, Container } from '@mui/material';
import API from '../services/api';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleLogin = () => {
    API.post('/auth/login', { email, password })
      .then(response => {
        localStorage.setItem('token', response.data.token);
        navigate('/');
      })
      .catch(error => console.error('There was an error logging in!', error));
  };

  return (
    <Container>
      <Typography variant="h4" component="h1" gutterBottom>Login</Typography>
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
      <Button variant="contained" color="primary" onClick={handleLogin}>Login</Button>
    </Container>
  );
};

export default Login;
