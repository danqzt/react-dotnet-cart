export const getProducts = async () =>
  await(await fetch('http://localhost:5240/shop/products')).json();

  export const getCountries = async () =>
  await(await fetch('http://localhost:5240/shop/countries')).json();