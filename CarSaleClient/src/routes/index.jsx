import React, { useEffect } from "react";
import { Navigate, Route, Routes, useLocation } from "react-router-dom";
import useAuth from "hooks/useAuth";

import Login from "pages/Login";
import Cars from "pages/Showcase";
import CarDetails from "pages/CarDetails";
import CarSell from "pages/CarSell";

function Router() {
  const { pathname } = useLocation();
  const path = pathname.split("/")[1];
  const { auth } = useAuth()

  useEffect(() => {
    const renderTitle = {
      "": "Login / PinPoint",
      cars: "Carros / PinPoint",
      car: "Detalhes / PinPoint",
      "car-sell": "Vender / PinPoint",
    };

    document.title = renderTitle[path];
  }, [path]);

  return (
    <Routes>
      {auth ? (
        <>
        <Route path="/car-sell" element={<CarSell />} />
        <Route path="/" element={<Navigate to="/cars" />} />
        </>
      ) : (
        <>
          <Route path="/car-sell" element={<Navigate to="/" />} />
          <Route path="/" element={<Login />} />
        </>
      )}

      <Route path="/cars" element={<Cars />} />
      <Route path="/car/:id" element={<CarDetails />} />
    </Routes>
  );
}

export default Router;
