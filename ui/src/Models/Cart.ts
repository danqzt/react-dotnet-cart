import CartItem from "./CartItem";
import Country from "./Country";

interface Cart{
   id: string,
   items: CartItem[],
   totalPrice: number,
   country: Country,
   totalQuantity: number
}

export default Cart;