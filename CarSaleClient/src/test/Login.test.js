import React from 'react';
import { render, screen } from '@testing-library/react';

import Login from 'pages/Login/index';
import { theme } from 'theme';
import { ThemeProvider } from 'styled-components';

test('Renders content', () => {
  render(
    <ThemeProvider theme={theme}>
      <Login />
    </ThemeProvider>
  );

  screen.getByTestId('logo');
  screen.getAllByText('Sign in');
  screen.getAllByPlaceholderText('Username');
  screen.getAllByPlaceholderText('Password');
  screen.getByRole('button', { name: /Login/i });
});
