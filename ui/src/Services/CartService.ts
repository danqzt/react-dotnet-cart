import CartItem from "../Models/CartItem";
import Country from "../Models/Country";

const cartEndpoint = 'http://localhost:5240/cart';

export const getCart = async () =>
  await(await fetch(cartEndpoint)).json();

export const addProductToCart  = async (data: CartItem) =>
{
    var json = await fetch(cartEndpoint, {
        method : 'POST',
        body: JSON.stringify(data),
        headers: {'Content-Type': 'application/json'}
    });

    return json.json();
}

export const deleteItemToCart  = async (data: CartItem) =>
{
    var json = await fetch(cartEndpoint, {
        method : 'DELETE',
        body: JSON.stringify(data),
        headers: {'Content-Type': 'application/json'}
    });

    return json.json();
}
export const cartChangeCountry  = async (data: Country) =>
{
    var json = await fetch(cartEndpoint+'/country/', {
        method : 'PUT',
        body: JSON.stringify(data),
        headers: {'Content-Type': 'application/json'}
    });

    return json.json();
}
