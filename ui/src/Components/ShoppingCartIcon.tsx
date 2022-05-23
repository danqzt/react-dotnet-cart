import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { Badge, Button, Container, Row } from "reactstrap";
import { Link } from "react-router-dom";
import Cart from "../Models/Cart";

export interface CartIconProp {
    cartData?: Cart;
}

const ShoppingCartIcon = (prop: CartIconProp) => (

    <Link to="/cart" state={{ data: prop.cartData!}}>
        <Button color="warning" className="bi-cart float-end btn-lg">
            <Badge color="warning"><span style={{ "color": "black" }}>{prop.cartData!.totalQuantity}</span></Badge>
        </Button>
    </Link>
)

export default ShoppingCartIcon;