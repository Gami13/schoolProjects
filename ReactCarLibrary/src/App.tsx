import { useReducer } from 'react';

import { ListRow } from './ListRow';
import { carReducer, getState } from './State';

export function App() {
  const [cars, dispatch] = useReducer(carReducer, getState());

  return (
    <div>
      <h1>Cars</h1>

      <ol>
        <li>
          <span> -- Make -- </span>
          <span> -- Model -- </span>
          <span> -- Production Year -- </span>
          <span> -- Power -- </span>
          <span> -- Price -- </span>
        </li>
        {cars.map((car) => (
          <ListRow
            key={car.id}
            dispatch={dispatch}
            car={car}
            isEditable={true}
          />
        ))}
        <ListRow dispatch={dispatch} isEditable={false} />
      </ol>
    </div>
  );
}
export type CarFormElements = {
  make: HTMLInputElement;
  model: HTMLInputElement;
  productionYear: HTMLInputElement;
  power: HTMLInputElement;
  price: HTMLInputElement;
  image: HTMLInputElement;
} & HTMLFormControlsCollection;
