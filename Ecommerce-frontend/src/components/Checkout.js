// // import React, { useState } from 'react';
// // import { TextField, Button, Typography, Container } from '@mui/material';
// // import API from '../services/api';
// // import { useNavigate } from 'react-router-dom';

// // const Checkout = () => {
// //   const [address, setAddress] = useState('');
// //   const [paymentMethod, setPaymentMethod] = useState('');
// //   const navigate = useNavigate();

// //   const handleCheckout = () => {
// //     API.post('/orders', { address, paymentMethod })
// //       .then(response => {
// //         navigate('/orders');
// //       })
// //       .catch(error => console.error('There was an error placing the order!', error));
// //   };

// //   return (
// //     <Container>
// //       <Typography variant="h4" component="h1" gutterBottom>Checkout</Typography>
// //       <TextField
// //         label="Address"
// //         variant="outlined"
// //         fullWidth
// //         value={address}
// //         onChange={(e) => setAddress(e.target.value)}
// //         margin="normal"
// //       />
// //       <TextField
// //         label="Payment Method"
// //         variant="outlined"
// //         fullWidth
// //         value={paymentMethod}
// //         onChange={(e) => setPaymentMethod(e.target.value)}
// //         margin="normal"
// //       />
// //       <Button variant="contained" color="primary" onClick={handleCheckout}>Place Order</Button>
// //     </Container>
// //   );
// // };

// // export default Checkout;

// import React, { useState } from 'react';
// import { TextField, Button, Typography, Container, Grid, Radio, RadioGroup, FormControlLabel, FormControl, FormLabel } from '@mui/material';
// import API from '../services/api';
// import { useNavigate } from 'react-router-dom';
// import './Checkout.css';

// const Checkout = () => {
//   const [address, setAddress] = useState('');
//   const [paymentMethod, setPaymentMethod] = useState('creditCard');
//   const navigate = useNavigate();

//   const handleCheckout = () => {
//     API.post('/orders', { address, paymentMethod })
//       .then(response => {
//         navigate('/orders');
//       })
//       .catch(error => console.error('There was an error placing the order!', error));
//   };

//   return (
//     <Container className="checkout-container">
//       <Typography variant="h4" component="h1" gutterBottom>Checkout</Typography>
//       <Grid container spacing={3}>
//         <Grid item xs={12}>
//           <TextField
//             label="Shipping Address"
//             variant="outlined"
//             fullWidth
//             value={address}
//             onChange={(e) => setAddress(e.target.value)}
//           />
//         </Grid>
//         <Grid item xs={12}>
//           <FormControl component="fieldset">
//             <FormLabel component="legend">Payment Method</FormLabel>
//             <RadioGroup
//               aria-label="paymentMethod"
//               name="paymentMethod"
//               value={paymentMethod}
//               onChange={(e) => setPaymentMethod(e.target.value)}
//             >
//               <FormControlLabel value="creditCard" control={<Radio />} label="Credit Card" />
//               <FormControlLabel value="paypal" control={<Radio />} label="PayPal" />
//               <FormControlLabel value="upi" control={<Radio />} label="UPI" />
//               <FormControlLabel value="cashOnDelivery" control={<Radio />} label="Cash on Delivery" />
//             </RadioGroup>
//           </FormControl>
//         </Grid>
//         <Grid item xs={12}>
//           <Button
//             variant="contained"
//             color="primary"
//             fullWidth
//             onClick={handleCheckout}
//             className="checkout-button"
//           >
//             Place Order
//           </Button>
//         </Grid>
//       </Grid>
//     </Container>
//   );
// };

// export default Checkout;
// import React, { useState } from 'react';
// import { TextField, Button, Typography, Container, Grid, Radio, RadioGroup, FormControlLabel, FormControl, FormLabel } from '@mui/material';
// import API from '../services/api';
// import { useNavigate } from 'react-router-dom';
// import '../styles/Checkout.css';

// const Checkout = () => {
//   const [address, setAddress] = useState('');
//   const [paymentMethod, setPaymentMethod] = useState('creditCard');
//   const navigate = useNavigate();

//   const handlePayment = () => {
//     // Placeholder for actual payment processing logic
//     if (paymentMethod === 'creditCard' || paymentMethod === 'paypal') {
//       console.log('Processing payment through', paymentMethod);
//     } else {
//       console.log('Selected payment method:', paymentMethod);
//     }
//     // Proceed with order placement
//     handleCheckout();
//   };

//   const handleCheckout = () => {
//     API.post('/orders', { address, paymentMethod })
//       .then(response => {
//         navigate('/orders');
//       })
//       .catch(error => console.error('There was an error placing the order!', error));
//   };

//   return (
//     <Container className="checkout-container">
//       <Typography variant="h4" component="h1" gutterBottom>Checkout</Typography>
//       <Grid container spacing={3}>
//         <Grid item xs={12}>
//           <TextField
//             label="Shipping Address"
//             variant="outlined"
//             fullWidth
//             value={address}
//             onChange={(e) => setAddress(e.target.value)}
//           />
//         </Grid>
//         <Grid item xs={12}>
//           <FormControl component="fieldset">
//             <FormLabel component="legend">Payment Method</FormLabel>
//             <RadioGroup
//               aria-label="paymentMethod"
//               name="paymentMethod"
//               value={paymentMethod}
//               onChange={(e) => setPaymentMethod(e.target.value)}
//             >
//               <FormControlLabel value="creditCard" control={<Radio />} label="Credit Card" />
//               <FormControlLabel value="paypal" control={<Radio />} label="PayPal" />
//               <FormControlLabel value="upi" control={<Radio />} label="UPI" />
//               <FormControlLabel value="cashOnDelivery" control={<Radio />} label="Cash on Delivery" />
//             </RadioGroup>
//           </FormControl>
//         </Grid>
//         <Grid item xs={12}>
//           <Button
//             variant="contained"
//             color="primary"
//             fullWidth
//             onClick={handlePayment}
//             className="checkout-button"
//           >
//             Place Order
//           </Button>
//         </Grid>
//       </Grid>
//     </Container>
//   );
// };

// export default Checkout;

import React, { useState, useEffect } from 'react';
import { TextField, Button, Typography, Container, Grid, Radio, RadioGroup, FormControlLabel, FormControl, FormLabel, Divider } from '@mui/material';
import API from '../services/api';
import { useNavigate } from 'react-router-dom';
import '../styles/Checkout.css';

const Checkout = () => {
  const [address, setAddress] = useState('');
  const [paymentMethod, setPaymentMethod] = useState('creditCard');
  const [promoCode, setPromoCode] = useState('');
  const [orderSummary, setOrderSummary] = useState({
    items: [],
    total: 0,
    discount: 0,
  });
  const navigate = useNavigate();

  useEffect(() => {
    // Fetch cart items and calculate total amount
    API.get('/Cart')
      .then(response => {
        const items = response.data;
        const total = items.reduce((sum, item) => sum + item.product.price * item.quantity, 0);
        setOrderSummary({ ...orderSummary, items, total });
      })
      .catch(error => console.error('There was an error fetching the cart items!', error));
  }, []);

  const handlePayment = () => {
    // Placeholder for actual payment processing logic
    if (paymentMethod === 'creditCard' || paymentMethod === 'paypal') {
      console.log('Processing payment through', paymentMethod);
    } else {
      console.log('Selected payment method:', paymentMethod);
    }
    // Proceed with order placement
    handleCheckout();
  };

  const handleCheckout = () => {
    API.post('/Order')
      .then(response => {
        console.log(response.data)
        navigate('/orders');
      })
      .catch(error => console.error('There was an error placing the order!', error));
  };

  const handleApplyPromoCode = () => {
    // Placeholder for promo code application logic
    console.log('Applying promo code:', promoCode);
    const discount = promoCode === 'DISCOUNT10' ? orderSummary.total * 0.1 : 0;
    setOrderSummary({ ...orderSummary, discount });
  };

  return (
    <Container className="checkout-container">
      <Typography variant="h4" component="h1" gutterBottom>Checkout</Typography>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Typography variant="h6" gutterBottom>Order Summary</Typography>
          <div className="order-summary">
            {orderSummary.items.map((item, index) => (
              <div key={index} className="order-item">
                <Typography variant="body1">{item.product.name} x {item.quantity}</Typography>
                <Typography variant="body1">${item.product.price * item.quantity}</Typography>
              </div>
            ))}
            <Divider />
            <div className="order-total">
              <Typography variant="h6">Subtotal</Typography>
              <Typography variant="h6">${orderSummary.total}</Typography>
            </div>
            <div className="order-discount">
              <Typography variant="h6">Discount</Typography>
              <Typography variant="h6">${orderSummary.discount}</Typography>
            </div>
            <Divider />
            <div className="order-final-total">
              <Typography variant="h6">Total</Typography>
              <Typography variant="h6">${orderSummary.total - orderSummary.discount}</Typography>
            </div>
          </div>
        </Grid>
        <Grid item xs={12}>
          <TextField
            label="Shipping Address"
            variant="outlined"
            fullWidth
            value={address}
            onChange={(e) => setAddress(e.target.value)}
            className="input-field"
          />
        </Grid>
        <Grid item xs={12}>
          <FormControl component="fieldset">
            <FormLabel component="legend">Payment Method</FormLabel>
            <RadioGroup
              aria-label="paymentMethod"
              name="paymentMethod"
              value={paymentMethod}
              onChange={(e) => setPaymentMethod(e.target.value)}
            >
              <FormControlLabel value="creditCard" control={<Radio />} label="Credit Card" />
              <FormControlLabel value="paypal" control={<Radio />} label="PayPal" />
              <FormControlLabel value="upi" control={<Radio />} label="UPI" />
              <FormControlLabel value="cashOnDelivery" control={<Radio />} label="Cash on Delivery" />
            </RadioGroup>
          </FormControl>
        </Grid>
        <Grid item xs={12}>
          <TextField
            label="Promo Code"
            variant="outlined"
            fullWidth
            value={promoCode}
            onChange={(e) => setPromoCode(e.target.value)}
            className="input-field"
          />
          <Button
            variant="contained"
            color="secondary"
            onClick={handleApplyPromoCode}
            className="apply-promo-button"
          >
            Apply Promo Code
          </Button>
        </Grid>
        <Grid item xs={12}>
          <Button
            variant="contained"
            color="primary"
            fullWidth
            onClick={handlePayment}
            className="checkout-button"
          >
            Place Order
          </Button>
        </Grid>
      </Grid>
    </Container>
  );
};

export default Checkout;
