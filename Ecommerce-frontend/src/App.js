import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Header from './components/Header';
import Footer from './components/Footer';
import HomePage from './pages/HomePage';
import ProductPage from './pages/ProductPage';
import CartPage from './pages/CartPage';
import Login from './components/Login';
import Register from './components/Register';
import UserProfile from './components/UserProfile';
import OrderHistory from './components/OrderHistory';
import Checkout from './components/Checkout';
import Wishlist from './components/WishList';
import ProductReviews from './components/ProductReviews';
import SearchResults from './components/SearchResults';

const App = () => {
  return (
    <Router>
      <Header />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/product/:id" element={<ProductPage />} />
        <Route path="/cart" element={<CartPage />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/profile" element={<UserProfile />} />
        <Route path="/orders" element={<OrderHistory />} />
        <Route path="/checkout" element={<Checkout />} />
        <Route path="/wishlist" element={<Wishlist />} />
        <Route path="/product/:id/reviews" element={<ProductReviews />} />
        <Route path="/search" element={<SearchResults />} />
      </Routes>
      <Footer />
    </Router>
  );
};

export default App;
