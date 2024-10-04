export type Car = {
  id: number;
  make: string;
  model: string;
  productionYear: number;
  power: number;
  price: number;
  image?: string;
};
type Action = {
  carId: number;
  type: string;
};

type CarActionAdd = Action & {
  type: 'add';
  car: Car;
};
type CarActionDelete = Action & {
  type: 'delete';
  carId: number;
};
type CarActionUpdate = Action & {
  type: 'update';
  car: Car;
};

export type CarAction = CarActionAdd | CarActionDelete | CarActionUpdate;
function saveState(state: Car[]) {
  localStorage.setItem('cars', JSON.stringify(state));
  return state;
}
export function getState() {
  const state = localStorage.getItem('cars');
  return state ? JSON.parse(state) : [];
}
export function carReducer(cars: Car[], action: CarAction): Car[] {
  switch (action.type) {
    case 'add': {
      return saveState(cars.concat(action.car));
    }
    case 'delete': {
      return saveState(cars.filter((c) => c.id !== action.carId));
    }
    case 'update': {
      return saveState(
        cars.map((c) => (c.id === action.car.id ? action.car : c))
      );
    }
    default: {
      throw Error('Unknown action');
    }
  }
}
export function deleteCar(dispatch: React.Dispatch<CarAction>, carId: number) {
  const action: CarActionDelete = {
    type: 'delete',
    carId: carId,
  };
  dispatch(action);
}
export function updateCar(dispatch: React.Dispatch<CarAction>, carData: Car) {
  const updatedCar = {
    id: carData.id,
    make: carData.make,
    model: carData.model,
    productionYear: carData.productionYear,
    power: carData.power,
    price: carData.price,
    image: carData.image || '',
  };
  const action: CarActionUpdate = {
    type: 'update',
    car: updatedCar,
    carId: updatedCar.id,
  };
  dispatch(action);
}

export function addCar(
  dispatch: React.Dispatch<CarAction>,
  carData: {
    make: string;
    model: string;
    productionYear: number;
    power: number;
    price: number;
    image?: string;
  }
) {
  const newCar = {
    id: new Date().getTime(),
    make: carData.make,
    model: carData.model,
    productionYear: carData.productionYear,
    power: carData.power,
    price: carData.price,
    image: carData.image || '',
  };
  const action: CarActionAdd = {
    type: 'add',
    car: newCar,
    carId: newCar.id,
  };
  dispatch(action);
}
