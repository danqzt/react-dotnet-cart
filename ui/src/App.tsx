import { useQuery } from "react-query";
import ProductList from "./Components/ProductList";
import Product from './Models/Product';
import { Spinner } from "reactstrap";
import { getProducts } from "./Services/ProductSvc";
import { getCart } from "./Services/CartService";
import 'bootstrap-icons/font/bootstrap-icons.css'
import Cart from "./Models/Cart";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import CartComponent from "./Components/Cart";
import Checkout from "./Components/Checkout";


const App = () => {

  const products = useQuery<Product[]>('products', getProducts);
  const cart  = useQuery<Cart>('cart', getCart);

    if(products.isLoading) return <Spinner animation="border"/>
    if (products.error){
      console.log(products.error);
      return <div>Something went wrong</div>;

    } 

    return (
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<ProductList data={products.data} cart={cart.data}/>}/>
          <Route path='/cart' element={<CartComponent/>}/>
          <Route path='/checkout' element={<Checkout/>}/>
        </Routes>
      </BrowserRouter>
    );
}

export default App;
