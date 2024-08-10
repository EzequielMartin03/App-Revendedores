import React, { useEffect, useState } from 'react';
import Slider from 'react-slick';
import './App.css';
import './CarouselPage.css'; // Importa los estilos del carrusel

function App() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [showPopup, setShowPopup] = useState(false);
  const [selectedProduct, setSelectedProduct] = useState(null);

  useEffect(() => {
    fetch('https://localhost:55416/api/Product')
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => {
        setProducts(data);
        setLoading(false);
      })
      .catch(error => {
        setError(error);
        setLoading(false);
      });
  }, []);

  const handleProductClick = (product) => {
    setSelectedProduct(product);
    setShowPopup(true);
  };

  const handleClosePopup = () => {
    setShowPopup(false);
    setSelectedProduct(null);
  };

  const handleWhatsAppClick = (product) => {
    const message = `Hola, estoy interesado en el producto: ${product.name}.`;
    const url = `https://wa.me/?text=${encodeURIComponent(message)}`;
    window.open(url, '_blank');
  };

  const carouselSettings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 1,
    slidesToScroll: 1
  };

  if (loading) {
    return <p>Cargando productos...</p>;
  }

  if (error) {
    return <p>Error al cargar productos: {error.message}</p>;
  }

  return (
    <div className="App">
      <nav className="navbar">
        <h1>RevendedoresApp</h1>
        <button onClick={() => setShowPopup(true)}>Nuevo Producto</button>
        <button>nueva Categoria</button>
      </nav>
      <div className="product-list">
        {products.map(product => (
          <div key={product.productId} className="card">
            {product.image && (
              <img 
                src={`https://localhost:55416${product.image}`} 
                alt={product.name} 
                style={{ maxWidth: '100%', height: 'auto' }} 
                onClick={() => handleProductClick(product)}
              />
            )}
            <h5>{product.name}</h5>
            <p>${product.price}</p>
          </div>
        ))}
      </div>
      {showPopup && selectedProduct && (
        <div className="popup">
          <div className="popup-content">
            <h2>{selectedProduct.name}</h2>
            <Slider {...carouselSettings}>
              {selectedProduct.images && selectedProduct.images.map((image, index) => (
                <div key={index} className="carousel-slide">
                  <img 
                    src={`https://localhost:55416${image}`} 
                    alt={selectedProduct.name} 
                    style={{ width: '100%', height: 'auto' }} 
                  />
                </div>
              ))}
            </Slider>
            <p>{selectedProduct.description}</p>
            <p>${selectedProduct.price}</p>
            <button onClick={() => handleWhatsAppClick(selectedProduct)}>
              Contactar por WhatsApp
            </button>
            <button onClick={handleClosePopup}>Cerrar</button>
          </div>
        </div>
      )}
    </div>
  );
}

export default App;
