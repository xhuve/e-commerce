import React, { useEffect, useState } from 'react'
import logo from '../basic-logo.png'
import { Link } from "react-router-dom";
import axios from 'axios';

function Navbar() {
    
    let [logData, setLogData] = useState(false);

    useEffect(() => {
        axios.get("https://localhost:44462/account/Logged")
        .then((response) => {
            setLogData(response.data)
            console.log(response)
        })
        .catch((err) => {
            console.log(err);
        })
    }, [])

    
    return (
        <div className='static flex justify-between align-middle border-solid border-b-4 border-sky-200 bg-sky-300 p-1.5'>
            <div className='ml-3'>
                <Link to="/">
                    <img className=" w-16 h-16" src={logo} alt="Logo"></img>
                </Link>
            </div>

            {logData ? 
            <div className='flex justify-around my-auto'>
                <div to="/signin" className="bg-blue-400 text-cyan-50 font-bold py-2 px-4 rounded">
                        Hello, {logData}
                </div> 
            </div> : 
            <div className='flex justify-around my-auto'>
                <Link to="/signin" className="bg-blue-400 text-cyan-50 font-bold py-2 px-4 rounded">
                    Sign In
                </Link>
                <Link to="/register" className="bg-blue-400 text-cyan-50 font-bold py-2 px-4 rounded mx-5">
                    Register
                </Link>
            </div>}
        
        </div>
    )
}

export default Navbar