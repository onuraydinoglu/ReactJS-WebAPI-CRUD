import React, { useState } from "react";
import { addProduct } from "../services/productService";
import { useNavigate } from "react-router-dom";

const ProductForm = () => {
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    await addProduct({ name, price: parseFloat(price) });
    navigate("/");
  };

  return (
    <div className="flex flex-col items-center justify-center min-h-screen">
      <div className="bg-white shadow-lg rounded-lg p-6 w-full max-w-md">
        <h2 className="text-xl font-bold text-center mb-4">Yeni Ürün Ekle</h2>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block font-medium mb-1">Ürün Adı</label>
            <input
              type="text"
              placeholder="Ürün Adı"
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
              placeholder="Fiyat"
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
              Kaydet
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default ProductForm;
