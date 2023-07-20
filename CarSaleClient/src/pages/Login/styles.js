import styled, { css } from "styled-components";

export const Container = styled.form`
  background-color: ${({ theme }) => theme.COLORS.GRAY_600};
  display: flex;
  height: 100vh;
  width: 100vw;

  svg {
    width: 15rem;
  }
  @media only screen and (max-width: 540px) {
    flex-direction: column;
  }
`;

export const Section = styled.section`
  animation: ${({ hasForm }) => (hasForm ? "enterFromLeft" : "enterFromRight")}
    ease-out 0.5s;
  background-color: ${({ theme, hasForm }) =>
    hasForm ? theme.COLORS.WHITE : "transparent"};
  display: grid;
  flex: 0.5;
  gap: 2rem;
  place-content: center;
  position: relative;

  ${({ hasForm }) => (hasForm ? enterFromLeft : enterFromRight)}

  @media only screen and (max-width: 540px) {
    max-height: ${({ hasForm }) => (hasForm ? "90vh" : "10vh")} !important;
  }
`;

export const Overlay = styled.div`
  background-color: rgba(0, 0, 0, 0.8);
  display: grid;
  height: 100%;
  place-content: center;
  position: absolute;
  transition: 0.2s;
  width: 100%;
`;

export const Input = styled.input`
  border-radius: 0.3rem;
  border: solid 1px ${({ theme }) => theme.COLORS.GRAY_200};
  box-shadow: inset 1px 2px 8px rgba(0, 0, 0, 0.04);
  outline: none;
  padding: 0.8rem;
  text-align: center;
  transition: 0.18s ease-out;
  width: 20rem;
  -moz-transition: 0.18s ease-out;
  -o-transition: 0.18s ease-out;
  -webkit-transition: 0.18s ease-out;

  &:hover {
    box-shadow: inset 1px 2px 8px rgba(0, 0, 0, 0.02);
  }

  &:focus {
    color: #4b515d;
    border: 1px solid #b8b6b6;
    box-shadow: inset 1px 2px 4px rgba(0, 0, 0, 0.02),
      0px 0px 8px rgba(0, 0, 0, 0.3);
  }
`;

export const Title = styled.h1`
  color: ${({ theme }) => theme.COLORS.GRAY_400};
`;

export const Button = styled.button`
  background-color: ${({ theme }) => theme.COLORS.GRAY_400};
  border-radius: 0.3rem;
  border: none;
  color: ${({ theme }) => theme.COLORS.WHITE};
  font-size: ${({ theme }) => theme.FONT_SIZE.MD}px;
  padding: 0.8rem 2rem;
`;

const enterFromLeft = css`
  @keyframes enterFromLeft {
    from {
      transform: translateX(-400%);
    }
    to {
      transform: translateX(0);
    }
  }
`;

const enterFromRight = css`
  @keyframes enterFromRight {
    from {
      transform: translateX(400%);
    }
    to {
      transform: translateX(0);
    }
  }
`;
