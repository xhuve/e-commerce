import React from 'react';
import Home from "./components/Home.js"
import "./index.css";
import Navbar from './components/Navbar.js';
import { Route, Routes } from 'react-router-dom';
import SignIn from './components/SignIn.js';
import Register from './components/Register.js';

function App() {
  return (
      <>
        <Navbar />
          <Routes>
            <Route index element={<Home />} />
            <Route to="/signin" element={<SignIn />} />
            <Route to="/register" element={<Register />} />
          </Routes>
      </>
    );
  }

export default App
