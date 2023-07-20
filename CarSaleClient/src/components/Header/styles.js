import styled from "styled-components";

export const Container = styled.header`
  margin: auto;
  max-height: 100px;
  width: 100%;
  box-shadow: 0px 2px 4px 0px rgba(0, 0, 0, 0.35);
  margin-bottom: 1rem;
`;

export const NavBar = styled.nav`
  display: flex;
  justify-content: space-between;
  margin: auto;
  max-height: 100px;
  max-width: 1140px;

  .img-container {
    width: 15rem;
    cursor: pointer;
    img {
      width: 100%;
    }
  }

  section {
    display: flex;
    align-items: center;
    justify-content: space-evenly;
    gap: 1rem;
  }

  .access-container {
    div {
      cursor: default;
      color: ${({ theme }) => theme.COLORS.GRAY_300};

      :hover {
        cursor: pointer;
        color: ${({ theme }) => theme.COLORS.BLACK};
      }
    }
  }

  .selected {
    font-weight: 800;
    color: ${({ theme }) => theme.COLORS.BLUE_800} !important;
  }

  @media only screen and (max-width: 540px) {
    width: 100%;
    max-width: 100%;
    .access-container {
      font-size: 10px;
    }
    /*     width: 100%;

    font-size: 5px;

    .img-container {
      width: 110px;
    }
    svg {
      width: 100%;
    }

    .access-container {
      width: 120px;
    } */
  }
`;
