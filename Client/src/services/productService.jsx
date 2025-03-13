import axios from "axios";

const API_URL = "http://localhost:5028/api/products";

export const getProducts = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

export const getProductById = async (id) => {
  const response = await axios.get(`${API_URL}/${id}`);
  return response.data;
};

export const addProduct = async (product) => {
  await axios.post(API_URL, product);
};

export const updateProduct = async (id, product) => {
  await axios.put(`${API_URL}/${id}`, product);
};

export const deleteProduct = async (id) => {
  await axios.delete(`${API_URL}/${id}`);
};
