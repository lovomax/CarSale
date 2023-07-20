import styled, { css } from "styled-components";

export const Overlay = styled.div`
  background-color: rgba(0, 0, 0, 0.8);
  display: grid;
  height: 100%;
  place-content: center;
  position: absolute;
  transition: 0.2s;
  width: 100%;
`;

export const Container = styled.form`
  width: 100vw;
  display: flex;
  align-items: center;
  justify-content: center;
  margin-bottom: 3rem;
  flex-direction: column;

  @media only screen and (max-width: 540px) {
    width: 100%;
    max-width: 100%;
  }
`;

export const DataContainer = styled.div`
  display: flex;
  flex-direction: column;
  width: 500px;

  h1 {
    margin: 2rem 0;
  }

  @media only screen and (max-width: 540px) {
    width: 100%;
    max-width: 100%;
    padding: 1rem;
  }
`;

export const TitleContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  width: 100%;
  gap: 1rem;
`;

export const InputContainer = styled.div`
  display: flex;
  flex: 1 100%;
  width: 100%;
  gap: 1rem;
  justify-content: center;

  input,
  select {
    font-weight: 600;
    color: ${({ theme }) => theme.COLORS.GRAY_500};
    width: 10rem;
    height: 2rem;
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
  .option-disabled {
    color: ${({ theme }) => theme.COLORS.GRAY_300};
  }
  @media only screen and (max-width: 540px) {
    input, select {
      font-size: ${({ theme }) => theme.FONT_SIZE.MD}px;
      height: 3rem;
    }
  }
`;

export const ImageInputContainer = styled.div`
  display: flex;
  width: 100%;
  position: relative;
  color: ${({ theme }) => theme.COLORS.GRAY_300};
  align-items: center;
  justify-content: center;
  border-radius: 0.5rem;
  border: 1px solid ${({ theme }) => theme.COLORS.GRAY_300};
  background-color: ${({ theme }) => theme.COLORS.GRAY_50};

  h3 {
    width: 100%;
    text-align: center;
    position: absolute;
    right: 0;
    top: 75%;
    transform: translateY(-50%);
  }
  svg {
    height: 40%;
    position: absolute;
    right: 44%;
    top: 40%;
    transform: translateY(-50%);
  }

  #image {
    display: none;
  }

  .image-container {
    display: block;
    width: 50%;
    height: 150px;
  }
`;

export const ImageContainer = styled.label`
  background-image: url(${({ source }) => source});

  ${({ source }) =>
    source &&
    css`
      background-position: 50%;
      background-size: cover;
    `}
`;

export const Button = styled.button`
  border: 1px solid ${({ theme }) => theme.COLORS.BLACK};
  border-radius: 0.5rem;
  background-color: ${({ theme }) => theme.COLORS.BLACK};
  color: ${({ theme }) => theme.COLORS.WHITE};
  font-weight: 500;
  font-size: ${({ theme }) => theme.FONT_SIZE.MD}px;

  margin-top: 3rem;
  padding: 0 3rem;

  height: 3rem;

  :hover {
    background-color: ${({ theme }) => theme.COLORS.WHITE};
    color: ${({ theme }) => theme.COLORS.BLACK};
  }
`;
