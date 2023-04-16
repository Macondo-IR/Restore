import { useEffect, useState } from "react";
import  {Product}  from "./product";
 function App() {
  const [products,setProducts]=useState<Product[]>([]);
    useEffect(()=>{
      fetch('http://localhost:8080/api/Products')
      .then(response=>response.json())
      .then(data=>setProducts(data))
    },[])
    function addProduct(){
      setProducts(prevstate=> [...prevstate,{
        id:prevstate.length+1001,
        name:'product '+(prevstate.length+1),
        price:100*prevstate.length,
        brand:'unknown brand',
        description:'des ...',
        pictureUrl:'http://picsum.photos/200'
      }]);
    }
  return (
    <div className="app">

      <h1  style={{color:'blue'}}>Re-Store</h1>
      <ul>

        {products.map((product,index) =>(
          <li key={index}>
            {product.name} - {product.price}- {product.description}
          </li>
        ))}
      </ul>
      <button  onClick={addProduct}>Add Product</button>
    </div>
  );
}

export default App;
