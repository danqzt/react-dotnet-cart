import React, { ChangeEvent, useEffect, useState } from "react";
import { useQuery } from "react-query";
import { useLocation } from "react-router-dom";
import { Button, Container, Input, Label, Row } from "reactstrap";
import Cart from "../Models/Cart"
import CartItem from "../Models/CartItem";
import Country from "../Models/Country";
import { cartChangeCountry, deleteItemToCart } from "../Services/CartService";
import { getCountries } from "../Services/ProductSvc";
import CartItemComponent from "./CartItem";

interface CartData {
    data: Cart;
}

// design from here: https://bootstraptor.com/snippets/bootstrap-4-snippet-shopping-cart/

const CartComponent = () => {
    const location = useLocation();
    const cart = location.state as CartData;
    const countries = useQuery<Country[]>('countries', getCountries);
    
    const [selectedCountry, setCountry] = useState<Country>();
    const [cartData, setCart] = useState<Cart>();

    const handleDeleteItem = async (item: CartItem) => {

        const cart = await deleteItemToCart(item);
        setCart(cart!);
    }

    const handleCountryChange = async (event: React.ChangeEvent<HTMLInputElement>) => {
        var selected = event.target.value;
        var country = countries?.data?.find(e => e.currency == selected);
        setCountry(country);
        const cart = await cartChangeCountry(country!);
        setCart(cart);
        
    }
    useEffect(() => {
        setCart(cart.data);
        setCountry(cart.data.country);
    },[]);

    return (
        <section className="pt-5 pb-5">
            <Container>
                <Row className="w-100">
                    <div className="col-lg-12 col-md-12 col-12">
                        <h3 className="display-6 mb-2 text-center">Shopping Cart</h3>
                        <div className="mb-3 text-center">
                            <i className="text-info font-weight-bold">{cartData?.items.length}</i> items in your cart</div>
                        <div className="mb-3 float-center w-25">
                            <Label for="slCountry" className="">Country </Label>
                            <Input id="slCountry" bssize="sm" type={"select"} className="form-control form-control-sm text-center"
                                    value={selectedCountry?.currency} onChange={handleCountryChange}
                           >
                                {countries.data?.map(c => (
                                    <option key={c.name} value={c.currency}>{c.name}</option>
                                ))}
                            </Input> </div>
                        <table id="shoppingCart" className="table table-condensed table-responsive">
                            <thead>
                                <tr>
                                    <th style={{ "width": "60%" }}>Product</th>
                                    <th style={{ "width": "12%" }}>Price</th>
                                    <th style={{ "width": "10%" }}>Quantity</th>
                                    <th style={{ "width": "16%" }}></th>
                                </tr>
                            </thead>
                            <tbody>
                                {cartData?.items.map(i => (<CartItemComponent item={i} deleteItem={handleDeleteItem} key={i.product.id} />))}
                            </tbody>
                        </table>
                        <div className="float-end text-end">
                            <h4>Subtotal:</h4>
                            <h1>${cartData?.totalPrice} {cartData?.country.currency}</h1>
                        </div>
                    </div>
                </Row>
                <Row className="row mt-4 d-flex align-items-center">
                    {cartData && cartData?.items.length > 0 && <div className="col-sm-6 order-md-2 text-end">
                        <a href="/checkout" className="btn-warning mb-4 btn-lg pl-5 pr-5">Checkout</a>
                    </div>}
                    <div className="col-sm-6 mb-5 mb-m-1 order-md-1 text-md-left">
                        <a href="/" className="text-danger">
                            <i className="fas fa-arrow-left mr-2"></i> Continue Shopping</a>
                    </div>
                </Row>
            </Container>
        </section>
    )
}
export default CartComponent