import React, { useEffect, useState } from "react";
import logo from "../basic-logo.png";
import { Link } from "react-router-dom";
import axios from "axios";

function Navbar() {
  let [logData, setLogData] = useState(false);

  useEffect(() => {
    axios
      .get("https://localhost:44462/account/Logged")
      .then((response) => {
        setLogData(response.data);
        console.log(response);
      })
      .catch((err) => {
        console.log(err);
        setLogData(false);
      });
  }, []);

  return (
    <>
      <nav className="bg-gray-900">
        <div className="max-w-screen-2xl flex flex-wrap items-center justify-between mx-auto p-4">
          <Link to="/">
            <img className=" w-16 h-16" src={logo} alt="Logo"></img>
          </Link>
          <div
            className="hidden w-full align-middle md:block md:w-auto"
            id="navbar-default"
          >
            <div className="items-baseline text-white font-medium flex flex-col p-4 md:p-0 mt-4 border rounded-lg md:flex-row md:space-x-8 md:mt-0 md:border-0 bg-gray-800 md:bg-gray-900 border-gray-700">
              <div>
                <div
                  className="block py-2 pl-3 pr-4 bg-blue-700 rounded md:bg-transparent md:text-blue-700 md:p-0 text-white"
                  aria-current="page"
                >
                  Home
                </div>
              </div>
              <div>
                <div className="block py-2 pl-3 pr-4 rounded md:border-0 md:hover:text-blue-700 md:p-0 text-white  hover:bg-gray-700 hover:text-white md:hover:bg-transparent">
                  About
                </div>
              </div>
              <div>
                <div className="block py-2 pl-3 pr-4 rounded md:border-0 md:hover:text-blue-700 md:p-0 text-white  hover:bg-gray-700 hover:text-white md:hover:bg-transparent">
                  Services
                </div>
              </div>
              <div>
                <div className="block py-2 pl-3 pr-4 rounded md:border-0 md:hover:text-blue-700 md:p-0 text-white  hover:bg-gray-700 hover:text-white md:hover:bg-transparent">
                  Pricing
                </div>
              </div>
              <div>
                <div className="block py-2 pl-3 pr-4 rounded md:border-0 md:hover:text-blue-700 md:p-0 text-white  hover:bg-gray-700 hover:text-white md:hover:bg-transparent">
                  Contact
                </div>
              </div>
              {logData ? (
                <div className="flex">
                  <div
                    to="/signin"
                    className="bg-blue-400 text-cyan-50 font-bold py-2 px-4 rounded"
                  >
                    Hello, {logData}
                  </div>
                </div>
              ) : (
                <div className="flex justify-around my-auto">
                  <Link
                    to="/signin"
                    className="bg-blue-400 text-cyan-50 font-bold py-2 px-4 rounded"
                  >
                    Sign In
                  </Link>
                  <Link
                    to="/register"
                    className="bg-blue-400 text-cyan-50 font-bold py-2 px-4 rounded mx-5"
                  >
                    Register
                  </Link>
                </div>
              )}
            </div>
          </div>
        </div>
      </nav>
    </>
  );
}

export default Navbar;
