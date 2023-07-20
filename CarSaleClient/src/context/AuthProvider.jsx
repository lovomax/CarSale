import { createContext, useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

import { api } from 'services/config';
import { httpStatusCodes } from 'utils/httpCode';
import { toast } from 'react-toastify';

const AuthContext = createContext();

const token = window.localStorage.getItem("data");

export const AuthProvider = ({ children }) => {
  const [auth, setAuth] = useState(token === "null" ? null : token);
  const navigate = useNavigate();

  const login = async (data) => {
    try {
      const userData = await api.post('api/Auth/login', data);

      setAuth(JSON.stringify(userData.data.data));

      navigate('/cars');
    } catch (error) {
      if (error.response.status === httpStatusCodes.notFound) {
        toast.error('Error de conexion');
      }
      if (error.response.status === httpStatusCodes.badRequest) {
        toast.error('Contraseña o rut incorrectos');
      }
    }
  };

  const logout = async () => {
    try {
      setAuth(null)
    } catch (error) {
      console.error(error)
    }
  }


  useEffect(() => {
    window.localStorage.setItem("data", auth);
  }, [auth]);

  return (
    <AuthContext.Provider value={{ auth, login, logout, setAuth }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;