import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

import { api } from "services/config";
import CarCard from "components/CarCard";
import Header from "components/Header";
import { CardContainer, Container, Overlay } from "./styles";
import Footer from "components/Footer";
import Spinner from "components/Spinner";

function Cars() {
  const [cars, setCars] = useState([]);
  const [isFetching, setIsFetching] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        setIsFetching(true);
        await api.get("/api/Car/getallcars").then((res) => {
          setCars(res.data.data);
        });
        setIsFetching(false);
      } catch (error) {
        console.error(error);
      } finally {
        setIsFetching(false);
      }
    };

    fetchData();
  }, []);

  return (
    <>
      {isFetching ? (
        <Overlay>
          <Spinner />
        </Overlay>
      ) : (
        <>
          <Header isBuy />

          <Container>
            <CardContainer>
              {cars &&
                cars.map((car, i) => (
                  <CarCard
                    car={car}
                    key={`${car.id}-${car.model}`}
                    onClick={() => navigate(`/car/${car.id}`)}
                  />
                ))}
            </CardContainer>
          </Container>

          <Footer isBasic={false} />
        </>
      )}
    </>
  );
}

export default Cars;
