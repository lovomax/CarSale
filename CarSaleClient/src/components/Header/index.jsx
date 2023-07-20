import React from "react";
import { Container, NavBar } from "./styles";
import { useNavigate } from "react-router-dom";
import useAuth from "hooks/useAuth";

import { ReactComponent as Icon } from "assets/uncolor-logo.svg";
/* import { ReactComponent as UserIcon } from "assets/user-icon.svg"; */

function Header({ ...props }) {
  const { auth } = useAuth()
  const navigate = useNavigate();

  const verifySesion = () => {

    if (!auth) {
      navigate("/");
      return false;
    }
    return true;
  };

  const handleSell = () => {
    const result = verifySesion();

    if (result) {
      navigate("/car-sell");
    }
  };

  return (
    <Container>
      <NavBar>
        <section className="img-container" onClick={() => navigate('/cars')}>
          <Icon fill="black" data-testid="logo" />
        </section>
        <section className="access-container">
          <div
            className={props?.isBuy ? "selected" : ""}
            onClick={() => navigate("/cars")}
          >
            Comprar Carro
          </div>
          <div
            className={props?.isSell ? "selected" : ""}
            onClick={() => handleSell()}
          >
            Vender Carro
          </div>
          <div className="">Sobre nós</div>

          {!auth  && (
            <>
              <div onClick={() => navigate("/")}>Login</div>
            </>
          )}
        </section>
      </NavBar>
    </Container>
  );
}

export default Header;
