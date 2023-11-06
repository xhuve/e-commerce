import React, { useState } from 'react'
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function SignIn() {
    const [formData, setFormData] = useState({});
    const nav = useNavigate();

    const oninputChange = (event) => {
      console.log(formData);
      setFormData({...formData, [event.target.name]: event.target.value});
    }

    const onSubmit = (e) => {
        e.preventDefault();
        axios.post("https://localhost:44462/account/Login", formData)
        .then((response) => {
            console.log(response);
            nav("/")
        })
        .catch((error) => {
            console.log(error);
        })
    }



  return (
    <div className='flex justify-center mt-32'>
        <div className='flex flex-col  p-4'>
            <div className="w-full max-w-xs">
                <form onSubmit={onSubmit} className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">
                            First Name
                        </label>
                        <input onChange={oninputChange} className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" name="first_name" type="text" placeholder="First Name" />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" >
                            E-mail
                        </label>
                        <input onChange={oninputChange} className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" name="email" type="text" placeholder="First Name" />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">
                            Username
                        </label>
                        <input onChange={oninputChange} className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" name="username" type="text" placeholder="Username" />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">
                            Password
                        </label>
                        <input onChange={oninputChange} className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" name="password" type="password" placeholder="******************" />
                        {/* <p class="text-red-500 text-xs italic">Please choose a password.</p> */}
                    </div>
                    <div className="grid">
                        <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" type="submit">
                            Sign In!
                        </button>
                    </div>
                </form>
            </div>
        </div>
    </div>
  )
}

export default SignIn