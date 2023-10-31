import axios from 'axios'
import React, { useEffect, useState } from 'react'

function Home() {
  
  const [logged, setLogged] = useState(false);
  const [responseData, setResponseData] = useState({});

  useEffect(() => {
    axios.get("https://localhost:44462/api/Products")
    .then((response) => {
      setResponseData(response)
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
    <div className="">E commerce website</div>
    {logged ? responseData.data.map((x) => {
      return (<div>{x.name}</div>)
    }) : <div>{responseData.code}</div>}
  </>
  )
}

export default Home
