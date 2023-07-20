import React, { useState } from "react";

import { useForm } from "react-hook-form";
import { ToastContainer, toast } from "react-toastify";
import useAuth from "hooks/useAuth";

import { ReactComponent as Icon } from "assets/uncolor-logo.svg";

import { Button, Container, Input, Overlay, Section, Title } from "./styles";
import Spinner from "components/Spinner";

const DEFAULT_VALUES = { username: "", password: "" };

function Login() {
  const { login } = useAuth()
  const [isFetching, setIsFetching] = useState(false);

  const {
    handleSubmit,
    register,
    watch,
    formState: { errors },
  } = useForm({ defaultValues: DEFAULT_VALUES, mode: "onChange" });

  const handleLogin = async (payload) => {
    try {
      setIsFetching(true);
      login(payload)
    } catch (error) {
      toast.error(error.response?.data?.message);
    } finally {
      setIsFetching(false);
    }
  };

  return (
    <Container onSubmit={handleSubmit(handleLogin)}>
      <Section>
        <Icon fill="white" data-testid="logo" />
      </Section>
      <Section hasForm>
        <Title>Sign in</Title>
        <Input
          type="text"
          placeholder="Username"
          {...register("username", { required: true, minLength: 3 })}
        />
        <Input
          type="password"
          placeholder="Password"
          {...register("password", { required: true, minLength: 4 })}
        />
        <Button
          disabled={
            Object.keys(errors).length ||
            Object.values(watch()).some((item) => !item)
          }
        >
          Login
        </Button>

        {isFetching && (
          <Overlay>
            <Spinner />
          </Overlay>
        )}
      </Section>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="colored"
      />
    </Container>
  );
}

export default Login;
