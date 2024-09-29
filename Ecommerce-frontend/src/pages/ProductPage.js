// // // import React, { useEffect, useState } from 'react';
// // // import API from '../services/api';
// // // import { useParams } from 'react-router-dom';
// // // import { Container, Typography, Button, Grid, IconButton, Box } from '@mui/material';
// // // import AddIcon from '@mui/icons-material/Add';
// // // import RemoveIcon from '@mui/icons-material/Remove';

// // // const ProductPage = () => {
// // //   const { id } = useParams();
// // //   const [product, setProduct] = useState(null);
// // //   const [quantity, setQuantity] = useState(1); // Initial quantity set to 1

// // //   useEffect(() => {
// // //     API.get(`/Product/${id}`)
// // //       .then(response => setProduct(response.data))
// // //       .catch(error => console.error('There was an error fetching the product!', error));
// // //   }, [id]);

// // //   const handleAddToCart = () => {
// // //     API.post(`/Cart/AddItem?productId=${id}&quantity=${quantity}`)
// // //       .then(response => {
// // //         console.log('Product added to cart:', response.data);
// // //       })
// // //       .catch(error => {
// // //         console.error('There was an error adding the product to the cart!', error);
// // //       });
// // //   };

// // //   const incrementQuantity = () => setQuantity(quantity + 1);
// // //   const decrementQuantity = () => setQuantity(quantity > 1 ? quantity - 1 : 1);

// // //   if (!product) return null;

// // //   return (
// // //     <Container>
// // //       <Grid container spacing={2}>
// // //         <Grid item xs={12} md={6}>
// // //           <img src={product.imageUrl} alt={product.name} style={{ width: '100%' }} />
// // //         </Grid>
// // //         <Grid item xs={12} md={6}>
// // //           <Typography variant="h4" component="h1" gutterBottom>{product.name}</Typography>
// // //           <Typography variant="h5" color="textSecondary" gutterBottom>${product.price}</Typography>
// // //           <Typography variant="body1" gutterBottom>{product.description}</Typography>
// // //           <Box display="flex" alignItems="center" mb={2}>
// // //             <IconButton onClick={decrementQuantity} aria-label="decrease">
// // //               <RemoveIcon />
// // //             </IconButton>
// // //             <Typography variant="h6" component="span" mx={2}>{quantity}</Typography>
// // //             <IconButton onClick={incrementQuantity} aria-label="increase">
// // //               <AddIcon />
// // //             </IconButton>
// // //           </Box>
// // //           <Button variant="contained" color="primary" onClick={handleAddToCart}>Add to Cart</Button>
// // //         </Grid>
// // //       </Grid>
// // //     </Container>
// // //   );
// // // };

// // // export default ProductPage;

// // import React, { useEffect, useState } from 'react';
// // import API from '../services/api';
// // import { useParams } from 'react-router-dom';
// // import { Container, Typography, Button, Grid, IconButton, Box } from '@mui/material';
// // import AddIcon from '@mui/icons-material/Add';
// // import RemoveIcon from '@mui/icons-material/Remove';
// // import '../styles/ProductPage.css'; // Import the custom CSS

// // const ProductPage = () => {
// //   const { id } = useParams();
// //   const [product, setProduct] = useState(null);
// //   const [quantity, setQuantity] = useState(1); // Initial quantity set to 1

// //   useEffect(() => {
// //     API.get(`/Product/${id}`)
// //       .then(response => setProduct(response.data))
// //       .catch(error => console.error('There was an error fetching the product!', error));
// //   }, [id]);

// //   const handleAddToCart = () => {
// //     API.post(`/Cart/AddItem?productId=${id}&quantity=${quantity}`)
// //       .then(response => {
// //         console.log('Product added to cart:', response.data);
// //       })
// //       .catch(error => {
// //         console.error('There was an error adding the product to the cart!', error);
// //       });
// //   };

// //   const incrementQuantity = () => setQuantity(quantity + 1);
// //   const decrementQuantity = () => setQuantity(quantity > 1 ? quantity - 1 : 1);

// //   if (!product) return null;

// //   return (
// //     <Container className="product-page">
// //       <Grid container spacing={2}>
// //         <Grid item xs={12} md={6} className="product-image-container">
// //           <img src={product.imageUrl} alt={product.name} className="product-image" />
// //         </Grid>
// //         <Grid item xs={12} md={6} className="product-details">
// //           <Typography variant="h4" component="h1" gutterBottom className="product-name">
// //             {product.name}
// //           </Typography>
// //           <Typography variant="h5" color="textSecondary" gutterBottom className="product-price">
// //             ${product.price}
// //           </Typography>
// //           <Typography variant="body1" gutterBottom className="product-description">
// //             {product.description}
// //           </Typography>
// //           <Box display="flex" alignItems="center" mb={2} className="quantity-controls">
// //             <IconButton onClick={decrementQuantity} aria-label="decrease" className="quantity-button">
// //               <RemoveIcon />
// //             </IconButton>
// //             <Typography variant="h6" component="span" mx={2} className="quantity-number">
// //               {quantity}
// //             </Typography>
// //             <IconButton onClick={incrementQuantity} aria-label="increase" className="quantity-button">
// //               <AddIcon />
// //             </IconButton>
// //           </Box>
// //           <Button variant="contained" color="primary" onClick={handleAddToCart} className="add-to-cart-button">
// //             Add to Cart
// //           </Button>
// //         </Grid>
// //       </Grid>
// //     </Container>
// //   );
// // };

// // export default ProductPage;
// import React, { useEffect, useState } from 'react';
// import API from '../services/api';
// import { useParams } from 'react-router-dom';
// import { Container, Typography, Button, Grid, IconButton, Box } from '@mui/material';
// import AddIcon from '@mui/icons-material/Add';
// import RemoveIcon from '@mui/icons-material/Remove';
// import '../styles/ProductPage.css';

// const ProductPage = () => {
//   const { id } = useParams();
//   const [product, setProduct] = useState(null);
//   const [quantity, setQuantity] = useState(1);

//   useEffect(() => {
//     API.get(`/Product/${id}`)
//       .then(response => setProduct(response.data))
//       .catch(error => console.error('There was an error fetching the product!', error));
//   }, [id]);

//   const handleAddToCart = () => {
//     API.post(`/Cart/AddItem?productId=${id}&quantity=${quantity}`)
//       .then(response => {
//         console.log('Product added to cart:', response.data);
//       })
//       .catch(error => {
//         console.error('There was an error adding the product to the cart!', error);
//       });
//   };

//   const incrementQuantity = () => setQuantity(quantity + 1);
//   const decrementQuantity = () => setQuantity(quantity > 1 ? quantity - 1 : 1);

//   if (!product) return null;

//   return (
//     <Container className="product-page">
//       <Grid container spacing={4}>
//         <Grid item xs={12} md={6} className="product-image-container">
//           <img src={product.imageUrl} alt={product.name} className="product-image" />
//         </Grid>
//         <Grid item xs={12} md={6} className="product-details">
//           <Typography variant="h4" component="h1" gutterBottom className="product-name">
//             {product.name}
//           </Typography>
//           <Typography variant="h5" color="textSecondary" gutterBottom className="product-price">
//             ${product.price}
//           </Typography>
//           <Typography variant="body1" gutterBottom className="product-description">
//             {product.description}
//           </Typography>
//           <Box display="flex" alignItems="center" mb={2} className="quantity-controls">
//             <IconButton onClick={decrementQuantity} aria-label="decrease" className="quantity-button">
//               <RemoveIcon />
//             </IconButton>
//             <Typography variant="h6" component="span" mx={2} className="quantity-number">
//               {quantity}
//             </Typography>
//             <IconButton onClick={incrementQuantity} aria-label="increase" className="quantity-button">
//               <AddIcon />
//             </IconButton>
//           </Box>
//           <Button variant="contained" color="primary" onClick={handleAddToCart} className="add-to-cart-button">
//             Add to Cart
//           </Button>
//         </Grid>
//       </Grid>
//     </Container>
//   );
// };

// export default ProductPage;

import React, { useEffect, useState } from 'react';
import API from '../services/api';
import { useParams } from 'react-router-dom';
import { Container, Typography, Button, Grid, IconButton, Box, Rating , CardMedia, Card} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import RemoveIcon from '@mui/icons-material/Remove';
import '../styles/ProductPage.css';
import ProductReviews from '../components/ProductReviews';

const ProductPage = () => {
  const { id } = useParams();
  const [product, setProduct] = useState(null);
  const [quantity, setQuantity] = useState(1);
  const [avgRating, setavgRating] = useState(0);
  

  useEffect(() => {
    API.get(`/Product/${id}`)
    .then(response => {setProduct(response.data)
      console.log('Product :', product);
    })
      .catch(error => console.error('There was an error fetching the product!', error));
    API.get(`/Reviews/avgRate?productId=${id}`)
    .then(response => {setavgRating(response.data.Result);
      console.log(response);
    })
    .catch(error =>console.error("there is an errror in fetchin the average rating!", error) )  
   
  }, []);

  const handleAddToCart = () => {
    API.post(`/Cart/AddItem?productId=${id}&quantity=${quantity}`)
      .then(response => {
        console.log('Product added to cart:', response.data);
      })
      .catch(error => {
        console.error('There was an error adding the product to the cart!', error);
      });
  };

  const incrementQuantity = () => setQuantity(quantity + 1);
  const decrementQuantity = () => setQuantity(quantity > 1 ? quantity - 1 : 1);

  if (!product) return null;

  return (
    <>
    <Container className="product-page">
      <Grid container spacing={4} className="product-container">
        <Grid item xs={12} md={6} className="product-image-container">
        {/* <CardMedia
        component="img"
        alt={product.name || product.Name}
        // height="100"
        image={product.imageUrl}
       className="product-page-image"
      /> */}
          <img src={product.imageUrl} alt={product.name} className="product-page-image" />
          {console.log(product.imageUrl)}
          <Button variant="contained" color="primary" onClick={handleAddToCart} className="add-to-cart-button">
            Add to Cart
          </Button>
        </Grid>
        <Grid item xs={12} md={6} className="product-page-details">
          <Typography variant="h4" component="h1" gutterBottom className="product-page-name">
            {product.name}
          </Typography>
          <Typography variant="body1" gutterBottom className="product-page-description">
            {product.description}
          </Typography>
          <Rating value={avgRating} readOnly precision={0.5} />
          <Typography variant="h5" color="textSecondary" gutterBottom className="product-page-price">
            ${product.price}
          </Typography>
          <Box display="flex" alignItems="center" className="quantity-controls">
            <IconButton onClick={decrementQuantity} aria-label="decrease" className="quantity-button">
              <RemoveIcon />
            </IconButton>
            <Typography variant="h6" component="span" mx={2} className="quantity-number">
              {quantity}
            </Typography>
            <IconButton onClick={incrementQuantity} aria-label="increase" className="quantity-button">
              <AddIcon />
            </IconButton>
          </Box>
        </Grid>
      </Grid>
    </Container>
    <ProductReviews  id ={id}/>
    </>
  );
};

export default ProductPage;



