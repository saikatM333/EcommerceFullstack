// // import React, { useEffect, useState } from 'react';
// // import API from '../services/api';
// // import { Typography, Container, Grid } from '@mui/material';

// // const OrderHistory = () => {
// //   const [orders, setOrders] = useState([]);

// //   useEffect(() =>  {
// //   API.get('/Order')
// //       .then(response => {
// //         console.log("api calling api calling ")
// //          setOrders(response.data)
// //         console.log(response.data)
// //       })
// //       .catch(error => console.error('There was an error fetching the orders!', error));
// //   });
// //  // console.log("order set ",orders)
// //   return (
// //     <Container>
// //       <Typography variant="h4" component="h1" gutterBottom>Order History</Typography>
// //       {/* <List>
// //         {orders.map(order => (
// //           <ListItem key={order.id}>
// //             <ListItemText primary={`Order #${order.id}`} secondary={`Total: $${order.total}`} />
// //           </ListItem>
// //         ))}
// //       </List> */}
// //       {orders.orderItems.map( order=>(
// //       <Grid container spacing={2}>
// //         <Grid item>
// //           {/* <img src={ordersimage} alt={order.product.name}  className='cart-Item-image'/> */}
// //         </Grid>
// //         <Grid item xs={8} className="item-details">
// //           <Typography variant="h6">{order.product.name}</Typography>
// //           <Typography variant="body2">{order.product.description}</Typography>
// //         </Grid>
// //         <Grid item className="item-actions">
// //           <Typography variant="h6">${order.product.price}</Typography>
// //         </Grid>
// //         <Grid item className = "item-quatity">

// //              </Grid>
// //       </Grid>
// // ))}
// //     </Container>
// //   );
// // };

// // export default OrderHistory;
// import React, { useEffect, useState } from 'react';
// import API from '../services/api';
// import { Typography, Container, Grid } from '@mui/material';

// const OrderHistory = () => {
//   const [orders, setOrders] = useState([]);

//   useEffect(() => {
//     API.get('/Order')
//       .then(response => {
//         setOrders(response.data);
//       })
//       .catch(error => console.error('There was an error fetching the orders!', error));
//   }, []); // Add an empty dependency array to call the API only once on mount

//   return (
//     <Container>
//       <Typography variant="h4" component="h1" gutterBottom>Order History</Typography>
//       {orders.map(order => (
//         order.orderItems.map(item => (
//           <Grid container spacing={2} key={item.id}>
//             <Grid item>
//               {/* <img src={ordersimage} alt={item.product.name} className='cart-Item-image' /> */}
//             </Grid>
//             <Grid item xs={8} className="item-details">
//               <Typography variant="h6">{item.product.name}</Typography>
//               <Typography variant="body2">{item.product.description}</Typography>
//             </Grid>
//             <Grid item className="item-actions">
//               <Typography variant="h6">${item.product.price}</Typography>
//             </Grid>
//             <Grid item className="item-quantity">
//               <Typography variant="body2">Quantity: {item.quantity}</Typography>
//             </Grid>
//           </Grid>
//         ))
//       ))}
//     </Container>
//   );
// };

// export default OrderHistory;

import React, { useEffect, useState } from 'react';
import API from '../services/api';
import { Typography, Container, Grid } from '@mui/material';
import '../styles/OderHistory.css'; // Import the custom CSS

const OrderHistory = () => {
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    API.get('/Order')
      .then(response => {
        setOrders(response.data);
        console.log(response.data)
      })
      .catch(error => console.error('There was an error fetching the orders!', error));
  }, []); // Add an empty dependency array to call the API only once on mount

  return (
    <Container className="order-container">
      <Typography variant="h4" component="h1" gutterBottom>Order History</Typography>
      {orders.map(item => (
        
          <Grid container spacing={2} key={item.id} className="order-item">
            <Grid item>
              <img src={item.product.imageUrl} alt={item.product.name} className="item-image" /> {/* Replace placeholder_image_url with the actual image URL */}
            </Grid>
            <Grid item xs={8} className="item-details">
              <Typography variant="h6">{item.product.name}</Typography>
              <Typography variant="body2">{item.product.description}</Typography>
            </Grid>
            <Grid item xs={2} className="item-actions">
              <Typography variant="h6">${item.product.price}</Typography>
            </Grid>
            <Grid item xs={2} className="item-quantity">
              <Typography variant="body2">Quantity: {item.quantity}</Typography>
            </Grid>
          </Grid>
        ))
      }
    </Container>
  );
};

export default OrderHistory;
