import React from 'react';
import { Button } from 'reactstrap';
import Product  from '../Models/Product';

export interface ProductCardProp {
  item : Product,
  handleAddToCart: (clickedItem: Product) => void;
}

const ProductCard = (prop: ProductCardProp) => (
  <div className="col hp">
  <div className="card h-100 shadow-sm">
    <a href="#">
      <img src={prop.item.image} className="card-img-top" alt="product.title" />
    </a>

    <div className="label-top shadow-sm">
      <a className="text-white" href="#">{prop.item.name}</a>
    </div>
    <div className="card-body">
      <div className="clearfix mb-3">
        <span className="float-start badge rounded-pill bg-success">${prop.item.price}</span>

        <span className="float-end"><a href="#" className="small text-muted text-uppercase aff-link">reviews</a></span>
      </div>
      <h5 className="card-title">
        <a target="_blank" href="#">{prop.item.description}</a>
      </h5>

      <div className="d-grid gap-2 my-4">

        <Button color="warning" className="btn bold-btn" onClick={() => prop.handleAddToCart(prop.item)}>add to cart</Button>

      </div>
      <div className="clearfix mb-1">

        <span className="float-start"><a href="#"><i className="fas fa-question-circle"></i></a></span>

        <span className="float-end">
          <i className="far fa-heart" style={{"cursor": "pointer"}}></i>

        </span>
      </div>
    </div>
  </div>
</div>
);

export default ProductCard;