import React, { useEffect, useState } from "react";
import { getProductById, updateProduct } from "../services/productService";
import { useParams, useNavigate } from "react-router-dom";

const EditProduct = () => {
  const { id } = useParams();
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    fetchProduct();
  }, []);

  const fetchProduct = async () => {
    const product = await getProductById(id);
    setName(product.name);
    setPrice(product.price);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await updateProduct(id, {
      id: parseInt(id),
      name,
      price: parseFloat(price),
    });
    navigate("/");
  };

  return (
    <div className="flex flex-col items-center justify-center min-h-screen">
      <div className="bg-white shadow-lg rounded-lg p-6 w-full max-w-md">
        <h2 className="text-xl font-bold text-center mb-4">Ürünü Düzenle</h2>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block font-medium mb-1">Ürün Adı</label>
            <input
              type="text"
              value={name}
              onChange={(e) => setName(e.target.value)}
              required
              className="input input-bordered w-full"
            />
          </div>
          <div>
            <label className="block font-medium mb-1">Fiyat</label>
            <input
              type="number"
              value={price}
              onChange={(e) => setPrice(e.target.value)}
              required
              className="input input-bordered w-full"
            />
          </div>
          <div className="flex justify-between">
            <button
              type="button"
              onClick={() => navigate("/")}
              className="btn btn-outline"
            >
              İptal
            </button>
            <button type="submit" className="btn btn-primary">
              Güncelle
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default EditProduct;
