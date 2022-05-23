import Cart from "../Models/Cart";
import Product from "../Models/Product";
import ProductList from "./ProductList";

export interface HomeProps {
    products? : Product[]
    cart? : Cart,
}
const Home = (props: HomeProps) => (
    <div className="App">
    <ProductList data={props.products} cart={props.cart}/>
  </div>
);

export default Home;