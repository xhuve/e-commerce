import axios from 'axios'
import React, { useEffect, useState } from 'react'
import Card from './Card';

function Home() {
  
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
    <>
    <div className='mt-4 flex flex-row flex-wrap gap-5 justify-center'>  
      {logged ? responseData.map((x) => {
        return (
        <div><Card pName={x.name} price={x.price} /></div>
        )
      }) : <div>{responseData.code + ": Products not available"}</div>}
    </div>
    </>
  )
}

export default Home
