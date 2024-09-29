// import React from 'react';
// import { AppBar, Toolbar, Typography, Button, IconButton } from '@mui/material';
// import { Link, useNavigate } from 'react-router-dom';
// import SearchBar from './SearchBar';
// import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';
// import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
// const Header = () => {
//   const navigate = useNavigate();

//   const handleLogout = () => {
//     localStorage.removeItem('token');
//     navigate('/login');
//   };

//   const isAuthenticated = !!localStorage.getItem('token');

//   return (
//     <AppBar position="static">
//       <Toolbar>
//         <Typography variant="h6" style={{ flexGrow: 1 }}>
//           <Link to="/" style={{ color: 'inherit', textDecoration: 'none' }}>E-Commerce</Link>
//         </Typography>
//         <SearchBar />
//         {isAuthenticated ? (
//           <>
//             <Button color="inherit" onClick={handleLogout}>Logout</Button>
//             <Button color="inherit" component={Link} to="/profile">Profile</Button>
//             <Button color="inherit" component={Link} to="/orders">Orders</Button>
//             <Button color="inherit" component={Link} to="/wishlist">Wishlist</Button>
//           </>
//         ) : (
//           <>
//             <Button color="inherit" component={Link} to="/login">Login</Button>
//             <Button color="inherit" component={Link} to="/register">Register</Button>
//           </>
//         )}
//         <div>
          
//           <IconButton color="inherit" component={Link} to="/cart">
//             <FontAwesomeIcon icon={faShoppingCart} />
//           </IconButton>
//         </div>
//       </Toolbar>
//     </AppBar>
//   );
// };

// export default Header;

import React, { useState } from 'react';
import { AppBar, Toolbar, Typography, Button, IconButton, Menu, MenuItem, Box } from '@mui/material';
import { Link, useNavigate } from 'react-router-dom';
import SearchBar from './SearchBar';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faShoppingCart, faUserCircle } from '@fortawesome/free-solid-svg-icons';
import '../styles/Header.css'; // Import the custom CSS file

const Header = () => {
  const navigate = useNavigate();
  const [anchorEl, setAnchorEl] = useState(null);

  const handleProfileMenuOpen = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleMenuClose = () => {
    setAnchorEl(null);
  };

  const handleLogout = () => {
    localStorage.removeItem('token');
    navigate('/login');
    handleMenuClose();
  };

  const isAuthenticated = !!localStorage.getItem('token');

  return (
    <AppBar position="static" className="custom-app-bar">
      <Toolbar className="custom-toolbar">
        <Typography variant="h6" className="custom-title">
          <Link to="/" className="custom-link">E-Commerce</Link>
          
        </Typography>
        <SearchBar className="custom-search-bar" />
        {isAuthenticated ? (
          <>
            <IconButton
              color="inherit"
              onClick={handleProfileMenuOpen}
              className="custom-icon-button"
            >
              <FontAwesomeIcon icon={faUserCircle} />
            </IconButton>
            <Menu
              anchorEl={anchorEl}
              anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
              keepMounted
              transformOrigin={{ vertical: 'top', horizontal: 'right' }}
              open={Boolean(anchorEl)}
              onClose={handleMenuClose}
            >
              <MenuItem onClick={handleMenuClose} component={Link} to="/profile">Profile</MenuItem>
              <MenuItem onClick={handleMenuClose} component={Link} to="/orders">Orders</MenuItem>
              <MenuItem onClick={handleMenuClose} component={Link} to="/wishlist">Wishlist</MenuItem>
              <MenuItem onClick={handleLogout}>Logout</MenuItem>
            </Menu>
          </>
        ) : (
          <>
            <Button color="inherit" component={Link} to="/login">Login</Button>
            <Button color="inherit" component={Link} to="/register">Register</Button>
          </>
        )}
        <IconButton color="inherit" component={Link} to="/cart" className="custom-cart-icon">
          <FontAwesomeIcon icon={faShoppingCart} />
        </IconButton>
      </Toolbar>
    </AppBar>
  );
};

export default Header;

