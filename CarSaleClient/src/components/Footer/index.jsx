import React from "react";
import { useNavigate } from "react-router-dom";

import { ReactComponent as Icon } from "assets/uncolor-logo.svg";
import { Container, LogoNavContainer, NavContainer, ListContainer } from "./style";
//200 50 487 300
function Footer({ ...props }) {
  const navigate = useNavigate();
  return (
    <>
      <Container isBasic={props.isBasic}>
        {props.isBasic ? (
          <>
            <LogoNavContainer isBasic={props.isBasic}>
              <section className="img-container">
                <Icon fill="black" viewBox="45 50 500 100" />
              </section>
              <p className="copyright">
                Copyright © 2021 PinPoint. Todos os direitos reservados
              </p>
            </LogoNavContainer>
          </>
        ) : (
          <>
            <LogoNavContainer>
              <section className="img-container">
                <Icon fill="white" /* viewBox="45 60 487 196" */ />
              </section>
              <NavContainer>
                <ListContainer>
                  <li onClick={() => navigate('/cars')}>Comprar carro</li>
                  <li onClick={() => navigate('/car-sell')}>Vender carro</li>
                  <li>App Kavak</li>
                  <li>Onde estamos</li>
                  <li>Perguntas frequentes</li>
                  <li>Blog</li>
                  <li>Guia de preços</li>
                  <li>Carreiras</li>
                  <li>Contato</li>
                  <li>Imprensa</li>
                  <li>🇧🇷 Brasil</li>
                </ListContainer>

              </NavContainer>
            </LogoNavContainer>
          </>
        )}
      </Container>
    </>
  );
}

export default Footer;
