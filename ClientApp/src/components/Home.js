import axios from 'axios'
import React, { useEffect, useState } from 'react'
import Card from './Card'

function Products() {
    const [logged, setLogged] = useState(false);
    const [responseData, setResponseData] = useState({});
  
    useEffect(() => {
      axios.get("https://localhost:44462/api/Products")
      .then((response) => {
        setResponseData(response.data)
        setLogged(true)
        console.log(response)
      })
      .catch((err) => {
        setResponseData(err);
        console.log(err)
      })
    }, [])
  
    return (
      <div>
        <div className='bg-cyan-200 h-64'> 
        Test
        </div>
      <div className='mt-8 flex flex-row flex-wrap justify-center gap-5 mx-16'>  
        {logged ? responseData.map((x) => {
          return (
            <div><Card pName={x.name} price={x.price} /></div>
            )
          }) : <div>{responseData.code + ": Products not available"}</div>}
      </div>
      </div>
    )
}

export default Products