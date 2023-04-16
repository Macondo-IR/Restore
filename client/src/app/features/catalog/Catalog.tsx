import { useState, useEffect } from "react";
import { Product } from "../../models/product"
import ProductList from "./ProductList";


export default function Catalog(){
    const [products,setProducts]=useState<Product[]>([]);
    useEffect(()=>{
      fetch('http://185.8.173.74:8080/api/Products')
      .then(response=>response.json())
      .then(data=>setProducts(data))
    },[])
    
    return(
        <>
           <ProductList products={products} />
        </>
    )
 }