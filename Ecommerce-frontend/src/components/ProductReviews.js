// import React, { useEffect, useState } from 'react';
// import API from '../services/api';
// import { useParams } from 'react-router-dom';
// import { List, ListItem, ListItemText, Typography, TextField, Button, Container } from '@mui/material';

// const ProductReviews = ({id}) => {
//  // const { id } = useParams();
//   const [reviews, setReviews] = useState([]);
//   const [newReview, setNewReview] = useState('');

//   useEffect(() => {
//     API.get(`/Reviews/product/${id}`)
//       .then(response => {setReviews(response.data.Result.$values)
//         console.log(response.data.Result.$values)
//       })
//       .catch(error => console.error('There was an error fetching the reviews!', error));
//   }, []);

//   const handleAddReview = () => {
//     API.post(`/products/${id}/reviews`, { content: newReview })
//       .then(response => {
//         setReviews([...reviews, response.data]);
//         setNewReview('');
//       })
//       .catch(error => console.error('There was an error adding the review!', error));
//   };

//   return (
//     <Container>
//       <Typography variant="h5" component="h2" gutterBottom>Product Reviews</Typography>
//       <List>
//         {reviews.map(review => (
//           <ListItem key={review.Id}>
//             <ListItemText primary={review.Comment} secondary={`by ${review.CustomerId}`} />
//           </ListItem>
//         ))}
//       </List>
//       <TextField
//         label="Add a review"
//         variant="outlined"
//         fullWidth
//         value={newReview}
//         onChange={(e) => setNewReview(e.target.value)}
//         margin="normal"
//       />
//       <Button variant="contained" color="primary" onClick={handleAddReview}>Add Review</Button>
//     </Container>
//   );
// };

// export default ProductReviews;
import React, { useEffect, useState } from 'react';
import API from '../services/api';
import { useParams } from 'react-router-dom';
import { List, ListItem, ListItemText, Typography, TextField, Button, Container, Avatar, Box ,Rating} from '@mui/material';
import { deepOrange } from '@mui/material/colors';
import   "../styles/ProductReview.css";
const ProductReviews = ({ id }) => {
  const [reviews, setReviews] = useState([]);
  const [newReview, setNewReview] = useState('');
  
  const [rating, setRating] = useState(0);
  useEffect(() => {
    API.get(`/Reviews/product/${id}`)
      .then(response => {
        setReviews(response.data.Result.$values);
        console.log(response.data.Result.$values);
      })
      .catch(error => console.error('There was an error fetching the reviews!', error));
  }, [id]);

  const handleAddReview = () => {
    API.post(`/Reviews?productId=${id}&rating=${rating}&comment=${newReview}`)
      .then(response => {
        setReviews([...reviews]);
        setNewReview('');
        console.log(rating,id ,newReview )
        setRating(0)
      })
      .catch(error => console.error('There was an error adding the review!', rating,id ,newReview ,error ));
  };

  

  return (
    <Container className="reviews-container">
      <Typography variant="h5" component="h2" gutterBottom>Product Reviews</Typography>
      <List>
        {reviews.length===0?<></>:reviews.map(review => (
          <ListItem key={review.Id} alignItems="flex-start" className="review-item">
            <Avatar sx={{ bgcolor: deepOrange[500] }} className="user-avatar">
              {/* {review.CustomerId.charAt(0).toUpperCase()} */}
            </Avatar>
            <ListItemText
              primary={review.Comment}
              secondary={`by ${review.CustomerId}`}
              className="review-text"
            />
          </ListItem>
        ))}
      </List>
      {/* <Box className="add-review-section">
        <TextField
          label="Add a review"
          variant="outlined"
          fullWidth
          value={newReview}
          onChange={(e) => setNewReview(e.target.value)}
          margin="normal"
          className="add-review-textfield"
        />
        <Button variant="contained" color="primary" onClick={handleAddReview} className="add-review-button">
          Add Review
        </Button>
      </Box> */
      <Box className="add-review-section">
      <TextField
        label="Add a review"
        variant="outlined"
        fullWidth
        value={newReview}
        onChange={(e) => setNewReview(e.target.value)}
        margin="normal"
        className="add-review-textfield"
      />
      <Rating
        name="rating"
        value={rating}
        precision={1}
        onChange={(event, newValue) => {
          setRating(newValue);
        }}
        className="add-review-rating"
      />
      <Button
        variant="contained"
        color="primary"
        onClick={handleAddReview}
        className="add-review-button"
      >
        Add Review
      </Button>
    </Box>
      }
    </Container>
  );
};

export default ProductReviews;

