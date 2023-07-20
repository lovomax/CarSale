import React from 'react';
import { Container } from './styles';

const NUMBER_OF_CIRCLES = 4;

function Spinner() {
  return (
    <Container>
      <div className='lds-ellipsis'>
        {Array.from({ length: NUMBER_OF_CIRCLES }).map((_item, index) => (
          <div key={index} />
        ))}
      </div>
    </Container>
  );
}

export default Spinner;
