import {useEffect} from 'react';
import Router from 'routes';

import { injectStyle } from "react-toastify/dist/inject-style";

function App() {
  useEffect(() => {
    injectStyle();
  }, []);
  return <Router />;
}

export default App;
