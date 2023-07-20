import styled, { css } from "styled-components";

export const Overlay = styled.div`
  background-color: rgba(0, 0, 0, 0.9);
  z-index: 99;
  display: grid;
  height: 100%;
  place-content: center;
  position: absolute;
  transition: 0.2s;
  width: 100%;
`;

export const Container = styled.div`
  input {
    text-transform: capitalize;
  }
  .mega-container {
    display: flex;
    flex-direction: column;
    margin: auto;
    width: 1100px;
  }
  .navbar {
    display: flex;
    gap: 0.4rem;
    justify-content: flex-start;
    text-transform: uppercase;
    font-size: ${({ theme }) => theme.FONT_SIZE.SM}px;
    padding-bottom: 1rem;
  }
  .nav-desc {
    color: ${({ theme }) => theme.COLORS.GRAY_300};
  }

  .navlink {
    color: ${({ theme }) => theme.COLORS.BLUE_800};

    :hover {
      text-decoration: underline ${({ theme }) => theme.COLORS.BLUE_800};
    }
  }

  @media only screen and (max-width: 540px) {
    .mega-container {
      width: 100%;
      overflow: hidden;
    }
    .navbar {
      margin: 0 1rem 2rem;
      font-size: 10px;
    }
  }
`;

export const InfoContainer = styled.div`
  display: flex;
  width: 90%;
  justify-content: center;
  text-transform: capitalize;
  height: 600px;
  gap: 1rem;
  align-items: flex-start;
  margin: auto;

  @media only screen and (max-width: 540px) {
    flex-direction: column;
  }
`;

export const ImageContainer = styled.label`
  display: block;
  border-radius: 0.5rem;
  border: 1px solid ${({ theme }) => theme.COLORS.GRAY_100};
  position: relative;
  width: 750px;
  height: 100%;
  overflow: hidden;

  background-image: url(${({ source }) => source});

  ${({ source }) =>
    source &&
    css`
      overflow: auto;
      background-position: 50%;
      background-size: cover;
    `}

  img {
    width: 100%;
    height: 100%;
  }

  h4 {
    width: 100%;
    text-align: center;
    text-transform: initial;
    position: absolute;
    right: 0%;
    top: 60%;
    transform: translateY(-50%);
  }

  svg {
    height: 15%;
    position: absolute;
    right: 45%;
    top: 40%;
    transform: translateY(-50%);
  }

  #image {
    display: none;
  }

  .missing-icon {
    position: absolute;
    right: 45%;
    top: 50%;
    transform: translateY(-50%);
  }

  @media only screen and (max-width: 540px) {
    width: 100%;
  }
`;

export const TextContainer = styled.form`
  display: flex;
  flex-direction: column;
  align-self: flex-start;
  justify-self: flex-start;
  line-height: 35px;

  .name-container {
    font-weight: 800;
    font-size: ${({ theme }) => theme.FONT_SIZE.XXL}px;
  }

  .char-container {
    font-size: ${({ theme }) => theme.FONT_SIZE.LG}px;
    color: ${({ theme }) => theme.COLORS.GRAY_400};
  }

  .price-container {
    display: flex;
    gap: 1rem;
    color: ${({ theme }) => theme.COLORS.GRAY_400};
    align-items: flex-end;
    height: fit-content;
    margin: 2rem 0 1rem;
    line-height: 0;

    .price {
      //calc(1.317rem + 0.804vw)
      font-size: 34px;
      color: ${({ theme }) => theme.COLORS.BLUE_800};
      font-weight: 650;
      height: fit-content;
    }
  }

  input,
  select {
    width: 10rem;
    height: 2.5rem;
    border-radius: 0.5rem;
    border: 1px solid ${({ theme }) => theme.COLORS.GRAY_300};
    width: 100%;
    padding-left: 1rem;
    margin-bottom: 1rem;

    :focus {
      border: 1px solid ${({ theme }) => theme.COLORS.BLUE_800};
      outline: none;
    }
  }

  @media only screen and (max-width: 540px) {
    width: 100%;

    .name-container {
      font-size: ${({ theme }) => theme.FONT_SIZE.XL}px;
    }

    .char-container {
      font-size: ${({ theme }) => theme.FONT_SIZE.MD}px;
    }

    .price-container {
      color: ${({ theme }) => theme.COLORS.GRAY_400};

      .price {
        //calc(1.317rem + 0.804vw)
        font-size: 34px;
        color: ${({ theme }) => theme.COLORS.BLUE_800};
      }
    }
  }
`;

export const InputContainer = styled.div`
  display: flex;
  flex: 1 100%;
  width: 100%;
  gap: 1rem;
  justify-content: center;
`;

export const Button = styled.button`
  border: 1px solid ${({ theme }) => theme.COLORS.BLACK};
  border-radius: 0.5rem;
  background-color: ${({ toDelete, theme }) => toDelete ? theme.COLORS.WHITE : theme.COLORS.BLACK};
  color: ${({ toDelete, theme }) => toDelete ? theme.COLORS.BLACK : theme.COLORS.WHITE};
  font-weight: 500;
  font-size: ${({ theme }) => theme.FONT_SIZE.MD}px;
  width: 100%;
  margin-top: 2.5rem;
  padding: 0 2rem;
  height: 2.5rem;
  font-weight: bold;

  :hover {
    background-color: ${({ toDelete, theme }) => toDelete ? theme.COLORS.RED : theme.COLORS.WHITE};
    border: 1px solid ${({ toDelete, theme }) => toDelete ? theme.COLORS.RED : theme.COLORS.BLACK};
    color: ${({ toDelete, theme }) => toDelete ? theme.COLORS.WHITE : theme.COLORS.BLACK};
  }

  @media only screen and (max-width: 540px) {
    padding: 1rem 3rem 2.3rem !important;
    text-align: center;
  }
`;
