import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import Product from "../Models/Product";
import ProductCard from "./ProductCard";
import { Badge, Button, Container, Row } from "reactstrap";

import { addProductToCart, getCart } from '../Services/CartService';
import CartItem from "../Models/CartItem";
import ShoppingCartIcon from "./ShoppingCartIcon";
import Cart from "../Models/Cart";

export interface ProductListProp {
    data?: Product[],
    cart? : Cart
}


///html based on this one: https://codepen.io/design007/pen/BaRPZgJ

const ProductList = (prop: ProductListProp) => {

    const [cartData, setCart] = useState<Cart>();
 

    const handleAddToCart = async (item : Product) => { 
        let cartItem : CartItem = {
            product : item,
            quantity : 1
        };
        let data = await addProductToCart(cartItem);
        setCart(data!);
    };
    
    
    useEffect(() => setCart(prop.cart),[]);
    
    return (
 
        <Container fluid className="bg-trasparent my-4 p-3" style={{ "position": "relative" }}>
            { (cartData?.totalQuantity ?? 0)  > 0 && <ShoppingCartIcon cartData={cartData}/>}
            <Row className="row-cols-1 row-cols-xs-2 row-cols-sm-2 row-cols-lg-4 g-3">
                {prop.data?.map(i => (
                    <ProductCard item={i} handleAddToCart={handleAddToCart} key={i.id} />
                ))}
            </Row>
        </Container>

    );
}

export default ProductList;
