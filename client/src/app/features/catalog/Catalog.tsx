import { Product } from "../../models/product"

interface Props{
    products:Product[];
    addProduct:()=>void;
}
export default function Catalog(props:Props){
    return(
        <>
        <ul>
            {props.products.map((product,index) =>(
            <li key={index}>
            {product.name} - {product.price}- {product.description}
            </li>
            ))}
            </ul>
            <button  onClick={props.addProduct}>Add Product</button>
        </>
    )

}