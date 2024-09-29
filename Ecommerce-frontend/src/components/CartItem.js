// import React from 'react';
// import { Card, CardContent, Typography, Button, Grid } from '@mui/material';
// import API from '../services/api';


// const CartItem = ({ item }) => {
//   return (
//     <Card className="cart-item">
//       <Grid container spacing={2}>
//         <Grid item>
//           <img src={item.product.image} alt={item.product.name} />
//         </Grid>
//         <Grid item xs={8} className="item-details">
//           <Typography variant="h6">{item.product.name}</Typography>
//           <Typography variant="body2">{item.product.description}</Typography>
//         </Grid>
//         <Grid item className="item-actions">
//           <Typography variant="h6">${item.product.price}</Typography>
//            </Grid>
//       </Grid>
//     </Card>
//   );
// };

// export default CartItem;

// CartItem.jsx
import React from 'react';
import { Card, CardContent, Typography, Grid , Button} from '@mui/material';
import '../styles/CartItem.css'

import API from '../services/api';


const CartItem = ({ item }) => {
  return (
    
      <Grid container spacing={2}>
        <Grid item>
          <img src={item.product.imageUrl} alt={item.product.name}  className='cart-Item-image'/>
        </Grid>
        <Grid item xs={5} className="item-details">
          <Typography variant="h6">{item.product.name}</Typography>
          <Typography variant="body2">{item.product.description}</Typography>
        </Grid>
        <Grid item className="item-actions">
          <Typography variant="h6">${item.product.price}</Typography>
        </Grid>
        <Grid item className = "item-quatity">
             </Grid>
      </Grid>
   
  );
};

export default CartItem;

