import axios from 'axios';

const request = axios.create({
    baseURL: 'http://localhost:14884/api/Products/'
});

export const getProductsAll = data => request.get('/GetAll', data);

export const getProductById = data => request.get('/GetById', data);

export const addProduct = data => request.post('/Add', data);

export const editProduct = data => request.put('/Edit', data);

export const deleteProduct = data => request.delete('/Delete', data);
