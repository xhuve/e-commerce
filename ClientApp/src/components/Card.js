import React from 'react'
import img from "./img.png"

function Card({pName, price}) {
  return (
    <div className="w-full p-5 max-w-sm bg-white border border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700">
        <a>
            <h5 className="px-5 pt-5 text-xl font-semibold tracking-tight text-gray-900 dark:text-white">{pName}</h5>
            <img className="my-3 mx-auto w-2/3 rounded-lg" src={img} alt="product image" />
        </a>
        <div className="px-5 py-5">
            <div className="flex items-center justify-between">
                <span className="text-xl mr-4 font-bold text-gray-900 dark:text-white">{price}</span>
                <a className="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Add to cart</a>
            </div>
        </div>
    </div>
  )
}

export default Card