import React, { useEffect, useState } from "react";
import { getProducts, deleteProduct } from "../services/productService";
import { useNavigate } from "react-router-dom";

const ProductList = () => {
  const [products, setProducts] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetchProducts();
  }, []);

  const fetchProducts = async () => {
    const data = await getProducts();
    setProducts(data);
  };

  const handleDelete = async (id) => {
    await deleteProduct(id);
    fetchProducts();
  };

  return (
    <div className="flex flex-col items-center">
      <h2 className="text-center text-xl font-bold my-4">Ürün Listesi</h2>
      <button onClick={() => navigate("/add")} className="btn btn-success mb-4">
        Yeni Ürün Ekle
      </button>

      <div className="overflow-x-auto w-full max-w-4xl">
        <table className="table mx-auto">
          <thead>
            <tr className="bg-gray-200">
              <th className="px-4 py-2">#</th>
              <th className="px-4 py-2">Name</th>
              <th className="px-4 py-2">Price</th>
              <th className="px-4 py-2">Actions</th>
            </tr>
          </thead>
          <tbody>
            {products.map((product, index) => (
              <tr key={product.id}>
                <th className="px-4 py-2">{index + 1}</th>
                <td className="px-4 py-2">{product.name}</td>
                <td className="px-4 py-2">${product.price}</td>
                <td className="px-4 py-2">
                  <button
                    className="btn btn-primary btn-sm mr-2"
                    onClick={() => navigate(`/edit/${product.id}`)}
                  >
                    Düzenle
                  </button>
                  <button
                    className="btn btn-error btn-sm"
                    onClick={() => handleDelete(product.id)}
                  >
                    Sil
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default ProductList;
