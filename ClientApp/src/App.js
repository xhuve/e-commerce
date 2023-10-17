import React from 'react';
import Home from "./components/Home.js"
import "./index.css";
import Navbar from './components/Navbar.js';
import { Route, Routes } from 'react-router-dom';
import SignIn from './components/SignIn.js';
import Register from './components/Register.js';

function App() {
  return (
      <div className="min-h-screen">
        <Navbar />
        <Routes>
          <Route index element={<Home />} />
          <Route path="/signin" element={<SignIn />} />
          <Route path="/register" element={<Register />} />
        </Routes>
      </div>
    );
  }

export default App
