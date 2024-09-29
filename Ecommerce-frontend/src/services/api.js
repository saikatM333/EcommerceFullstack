import axios from 'axios';

const API = await axios.create({
  baseURL: 'https://localhost:7130/api',
  withCredentials: true // Change to your backend URL
});

API.interceptors.request.use(config => {
  const token = localStorage.getItem('token');
  
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  console.log('Request Headers:', config.headers);
  return config;
});

export default API;
