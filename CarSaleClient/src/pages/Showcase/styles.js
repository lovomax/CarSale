import styled from "styled-components";

export const Overlay = styled.div`
  z-index: 999;
  background-color: rgba(0, 0, 0, 0.9);
  display: grid;
  height: 100%;
  place-content: center;
  position: absolute;
  transition: 0.2s;
  width: 100%;
`;

export const Container = styled.main`
  display: flex;
  width: 100vw;
  margin: auto;
  justify-content: center;
  align-items: center;
  padding-bottom: 3rem;

  @media only screen and (max-width: 540px) {
    width: 100%;
    max-width: 100%;
  }
`;

export const CardContainer = styled.section`
  display: flex;
  flex-wrap: wrap;
  gap: 1rem;
  max-width: 1150px;

  @media only screen and (max-width: 540px) {
    max-width: 300px;
    width: 300px;
    flex-direction: column;
    align-items: center;
    justify-content: center;
  }
`;
