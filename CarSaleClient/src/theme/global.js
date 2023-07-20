import { createGlobalStyle } from "styled-components";

export const GlobalStyle = createGlobalStyle`

  * {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
  }

  html {
    @media (max-width: 1080px) {
      font-size: 93.5%;
    }
    @media (max-width: 720px) {
      font-size: 87.75%;
    }
  }

  body {
    background-color: var(--white-900);
    color: #29292E;
    font-family: 'Open Sans', sans-serif;
    min-height: 100vh;
    min-width: 100vw;
    overflow-x: hidden;
    input {
      font-family: 'Open Sans', sans-serif;
      font-weight: 600;
    }
  }



  h1, h2, h3, h4, h5, h6 {
    font-weight: 600;
  }

  button {
    transition: 0.2s;
    cursor: pointer;

    :hover {
      filter: brightness(0.95);
    }
  }

  [disabled] {
    opacity: 0.6;
    cursor: not-allowed;
  }

  a {
    color: inherit;
    text-decoration: none;
  }
`;
