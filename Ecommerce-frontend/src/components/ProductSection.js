// // // ProductSection.js
// // import React, { useEffect, useState } from 'react';
// // import API from '../services/api';
// // import { Grid, Typography } from '@mui/material';
// // import ProductCard from './ProductCard';
// // //import './ProductSection.css';

// // const ProductSection = ({ category, title }) => {
// //   const [products, setProducts] = useState([]);

// //   useEffect(() => {
// //     API.get(`/Product/category/${category}`)
// //       .then(response => {setProducts(response.data.Result.$values)
// //         console.log("prosuct section",response.data.Result.$values)
// //       })
// //       .catch(error => console.error('There was an error fetching the products!', error));
// //   }, []);

// //   return (
// //     <div className="product-section">
// //       <Typography variant="h5" component="h3" gutterBottom>
// //         {title}
// //       </Typography>
// //       <div className="product-carousel">
// //         {products.map(product => (
// //           <ProductCard key={product.id} product={product} />
// //         ))}
// //       </div>
// //     </div>
// //   );
// // };

// // export default ProductSection;

// // ProductSection.js
// // import React, { useEffect, useState } from 'react';
// // import API from '../services/api';
// // import { Grid, Typography, Box } from '@mui/material';
// // import ProductCard from './ProductCard';
// // import '../styles/ProductSection.css';

// // const ProductSection = ({ category, title }) => {
// //   const [products, setProducts] = useState([]);

// //   useEffect(() => {
// //     API.get(`/Product/category/${category}`)
// //       .then(response => {
// //         setProducts(response.data.Result.$values);
// //         console.log("product section", response.data.Result.$values);
// //       })
// //       .catch(error => console.error('There was an error fetching the products!', error));
// //   }, [category]);

// //   return (
// //     <Box className="product-section">
// //       <Typography variant="h5" component="h3" gutterBottom>
// //         {title}
// //       </Typography>
// //       <Grid container spacing={2} className="product-grid">
// //         {products.map(product => (
// //           <Grid item xs={12} sm={6} md={4} lg={3} key={product.id}>
// //             <ProductCard product={product} />
// //           </Grid>
// //         ))}
// //       </Grid>
// //     </Box>
// //   );
// // };

// // export default ProductSection;

// // ProductSection.js
// // // ProductSection.js
// import React, { useEffect, useState, useRef } from 'react';
// import API from '../services/api';
// import { Grid, Typography, Box } from '@mui/material';
// import ProductCard from './ProductCard';
// import '../styles/ProductSection.css';

// const ProductSection = ({ category, title }) => {
//   const [products, setProducts] = useState([]);
//   const productContainerRef = useRef(null);

//   useEffect(() => {
//     API.get(`/Product/category/${category}`)
//       .then(response => {
//         setProducts(response.data.Result.$values);
//         console.log("product section", response.data.Result.$values);
//       })
//       .catch(error => console.error('There was an error fetching the products!', error));
//   }, [category]);

//   const handleMouseEnter = () => {
//     productContainerRef.current.style.animationPlayState = 'paused';
//   };

//   const handleMouseLeave = () => {
//     productContainerRef.current.style.animationPlayState = 'running';
//   };

//   return (
//     <Box className="product-section" onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave}>
//       <Typography variant="h5" component="h3" gutterBottom>
//         {title}
//       </Typography>
//       <div className="product-carousel-wrapper">
//         <div className="product-carousel" ref={productContainerRef}>
//           {products.concat(products).map((product, index) => (
//             <ProductCard key={index} product={product} />
//           ))}
//         </div>
//       </div>
//     </Box>
//   );
// };

// export default ProductSection;

// ProductSection.js
import React, { useEffect, useState, useRef } from 'react';
import API from '../services/api';
import { Typography, Box , Container} from '@mui/material';
import ProductCard from './ProductCard';
import '../styles/ProductSection.css';

const ProductSection = ({ category, title }) => {
  const [products, setProducts] = useState([]);
  const productContainerRef = useRef(null);

  useEffect(() => {
    API.get(`/Product/category/${category}`)
      .then(response => {
        setProducts(response.data.$values);
        console.log("product section", response.data.Result.$values);
      })
      .catch(error => console.error('There was an error fetching the products!', error));
  }, [category]);

  const handleMouseEnter = () => {
    productContainerRef.current.style.animationPlayState = 'paused';
  };

  const handleMouseLeave = () => {
    productContainerRef.current.style.animationPlayState = 'running';
  };

  return (
    <Container className="product-section" onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave}>
      <Typography variant="h5" component="h3" gutterBottom className='product-section-name'>
        {title}
      </Typography>
      <div className="product-carousel-wrapper">
        <div className="product-carousel" >
          {products.concat(products).map((product, index) => (
            <div className="product-carousel-effect" ref={productContainerRef}>
            <ProductCard key={index} product={product} />
            </div>
          ))}
        </div>
      </div>
    </Container>
  );
};

export default ProductSection;

