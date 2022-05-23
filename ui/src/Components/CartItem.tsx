import { Button, Input, Row } from "reactstrap";
import CartItem from "../Models/CartItem";

export interface CartItemProps {
    item: CartItem,
    deleteItem : (item : CartItem) => void;
}
const CartItemComponent = (prop: CartItemProps) => {

    return (
        <tr>
            <td data-th="Product">
                <Row>
                    <div className="col-md-3 text-left">
                        <img src={prop.item.product.image} alt="" className="img-fluid d-none d-md-block rounded mb-2 shadow " />
                    </div>
                    <div className="col-md-9 text-left mt-sm-2">
                        <h4>{prop.item.product.name}</h4>
                        <p className="font-weight-light">{prop.item.product.description}</p>
                    </div>
                </Row>
            </td>
            <td data-th="Price">${prop.item.product.price}</td>
            <td data-th="Quantity">
                <Input type={"number"} className="form-control form-control-lg text-center" value={prop.item.quantity} />
            </td>
            <td className="actions" data-th="">
                <div className="text-right">
                    <button className="btn btn-white border-secondary bg-white btn-md mb-2">
                        <i className="fas fa-sync"></i>
                    </button>
                    <button className="btn btn-white border-secondary bg-white btn-md mb-2" onClick={() => prop.deleteItem(prop.item)}>
                        <i className="fas fa-trash"></i>
                    </button>
                </div>
            </td>
        </tr>
    );
}

export default CartItemComponent;