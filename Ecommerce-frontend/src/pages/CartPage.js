// import React, { useEffect, useState } from 'react';
// import API from '../services/api';
// import { Grid, Container, Typography, Button } from '@mui/material';
// import { useNavigate } from 'react-router-dom';
// import CartItem from '../components/CartItem';

// const CartPage = () => {
//   const [cartItems, setCartItems] = useState([]);
//   const navigate = useNavigate();

//   useEffect(() => {
//     API.get('/Cart')
//       .then(response => setCartItems(response.data))
//       .catch(error => console.error('There was an error fetching the cart items!', error));
//   }, []);

//   const handleRemoveFromCart = (id) => {
//     API.delete(`/Cart/RemoveItem?productId=${id}`)
//       .then(response => {
//         console.log('Product removed from cart:', response.data);
//         setCartItems(prevItems => prevItems.filter(item => item.product.id !== id));
//       })
//       .catch(error => {
//         console.error('There was an error removing the product from the cart!', error);
//       });
//   };

//   const handleCheckout = () => {
//     navigate('/checkout');
//   };

//   return (
//     <Container>
//       <Typography variant="h4" component="h1" gutterBottom>Cart</Typography>
//       <Grid container spacing={2}>
//         {cartItems.map(item => (
//           <Grid item key={item.id} xs={12}>
//             <CartItem item={item} />
//             <Button variant="contained" color="secondary" onClick={() => handleRemoveFromCart(item.product.id)}>Remove</Button>
//           </Grid>
//         ))}
//       </Grid>
//       {cartItems.length > 0 && (
//         <Button variant="contained" color="primary" onClick={handleCheckout}>Proceed to Checkout</Button>
//       )}
//     </Container>
//   );
// };

// export default CartPage;

// CartPage.jsx
import React, { useEffect, useState } from 'react';
import API from '../services/api';
import { Grid, Container, Typography, Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import CartItem from '../components/CartItem';
import PriceDetails from '../components/PriceDetails';
import '../styles/CartPage.css';

const CartPage = () => {
  const [cartItems, setCartItems] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    API.get('/Cart')
      .then(response => {setCartItems(response.data)
        console.log(response.data)
      })
      .catch(error => console.error('There was an error fetching the cart items!', error));
  }, []);

  const handleRemoveFromCart = (id) => {
    API.delete(`/Cart/RemoveItem?productId=${id}`)
      .then(response => {
        console.log('Product removed from cart:', response.data);
        setCartItems(prevItems => prevItems.filter(item => item.product.id !== id));
      })
      .catch(error => {
        console.error('There was an error removing the product from the cart!', error);
      });
  };

  const handleCheckout = () => {
    navigate('/checkout');
  };

  const totalItems = cartItems.length;
  const totalPrice = cartItems.reduce((acc, item) => acc + item.product.price* item.quantity, 0);

  return (
    <Container className="Cart-page-container">
      <Typography variant="h4" component="h1" gutterBottom>Cart</Typography>
      <Grid container spacing={2}>
        <Grid item xs={8}>
          {cartItems.map(item => (
            <Grid item key={item.id} xs={12} className='One-Cart-Item'>
              <CartItem item={item} />
              <Button  onClick={() => handleRemoveFromCart(item.product.id)} className='cart-page-remove-button'>Remove</Button>
            </Grid>
          ))}
        </Grid>
        <Grid item xs={4}>
          {cartItems.length > 0 && (
            <PriceDetails totalItems={totalItems} totalPrice={totalPrice} />
          )}
          {cartItems.length > 0 && (
            <Button className="checkout-button" variant="contained" color="primary" onClick={handleCheckout}>Proceed to Checkout</Button>
          )}
        </Grid>
      </Grid>
    </Container>
  );
};

export default CartPage;

