import { Button } from "@mui/material";
import Avatar from "@mui/material/Avatar";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem/ListItem";
import ListItemAvatar from "@mui/material/ListItemAvatar";
import ListItemText from "@mui/material/ListItemText";
import { Product } from "../../models/product"
import ProductList from "./ProductList";

interface Props{
    products:Product[];
    addProduct:()=>void;
}
export default function Catalog({products,addProduct}:Props){
    return(
        <>
           <ProductList products={products} />
            <Button variant="contained"  onClick={addProduct}>Add Product</Button>
        </>
    )
 }