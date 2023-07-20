import { React } from "react";
import { useNavigate } from "react-router-dom";

import { Container } from "./styles";

function CarCard({ car }) {
  const navigate = useNavigate();
  return (
    <Container
      onClick={() => {
        navigate(`/car/${car.id}`);
      }}
    >
      <div className="img-container">
        {car?.photo?.photoURL ? (
          <img className="photo" src={car.photo.photoURL} alt="car" />
        ) : (
          <div className="not-found" />
        )}
      </div>
      <div className="info-container">
        <p className="car-name">{car.make?.name + " " + car.model}</p>
        <p className="car-characteristics">
          {car?.year?.split("-")[0] + " • " + car.kilometers + " km"}
        </p>
        <p className="car-price">R$ {car?.price?.toLocaleString()}</p>
      </div>
    </Container>
  );
}

export default CarCard;
