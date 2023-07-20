import styled from "styled-components";

export const Container = styled.section`
  display: flex;
  flex-direction: column;
  width: 275px;
  border-radius: 0.4rem;
  overflow: hidden;
  box-shadow: 0px 2px 4px 0px rgba(0, 0, 0, 0.35);

  :hover {
    box-shadow: 0px 3px 5px 0px rgba(0, 0, 0, 0.5);
    cursor: pointer;
  }

  .img-container {
    max-width: 275px;
    max-height: 205px;

    img {
      width: 100%;
    }
    .not-found {
      width: 100%;
      height: 205px;
      background-color: ${({ theme }) => theme.COLORS.GRAY_300};
    }
  }

  .info-container {
    display: flex;
    flex-direction: column;
    gap: 0.35rem;
    width: 100%;
    text-transform: capitalize;
    padding: 0.3rem 1rem 0.5rem;

    .car-name {
      color: ${({ theme }) => theme.COLORS.GREY_600};
      font-weight: bold;
      font-size: ${({ theme }) => theme.FONT_SIZE.MD}px;
      letter-spacing: -0.3px;
    }

    .car-characteristics {
      text-transform: lowercase;
      color: ${({ theme }) => theme.COLORS.GRAY_300};
      font-weight: 600;
      font-size: ${({ theme }) => theme.FONT_SIZE.SM}px;
    }

    .car-price {
      padding-top: 1rem;
      font-weight: 700;
      color: ${({ theme }) => theme.COLORS.BLUE_800};
      font-size: ${({ theme }) => theme.FONT_SIZE.LG}px;
    }
  }
`;
