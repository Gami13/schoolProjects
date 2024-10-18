import { useEffect, useState } from 'react';
import { DataTable } from './DataTable/DataTable.tsx';
import { TableColumns } from './DataTable/DataTableColumns.tsx';
import carData from './cars.json';
import { calculateTirePrice } from './utils.tsx';
type Tire = {
  radius: string;
  width: string;
  thickness: string;
  rim: string;
  offsetStart: string;
  offsetEnd: string;
  bar: string;
};

type FuelType = {
  type: string;
  tires: Tire[];
};

type Car = {
  make: string;
  model: string;
  year: string;
  fuelTypes: FuelType[];
};
export type TireFlat = {
  id: number;
  year: number;
  make: string;
  model: string;
  fuelType: string;
  bars: number;
  offsetStart: number;
  offsetEnd: number;
  radius: number;
  rim: number;
  thickness: number;
  width: number;
  price: number;
};
export function App() {
  const [carList, setCarList] = useState<TireFlat[]>([]);
  useEffect(() => {
    let idCounter = 0;
    //converts the carData to TireFlat
    const tireFlat: TireFlat[] = carData.flatMap((car: Car) => {
      return car.fuelTypes.flatMap((fuelType) => {
        return fuelType.tires.map((tire) => {
          return {
            id: idCounter++,
            year: Number.parseInt(car.year),
            make: car.make,
            model: car.model,
            fuelType: fuelType.type,
            bars: Number.parseInt(tire.bar),
            offsetStart: Number.parseInt(tire.offsetStart),
            offsetEnd: Number.parseInt(tire.offsetEnd),
            radius: Number.parseInt(tire.radius),
            rim: Number.parseInt(tire.rim),
            thickness: Number.parseInt(tire.thickness),
            width: Number.parseInt(tire.width),
            price: calculateTirePrice({
              year: Number.parseInt(car.year),
              bar: Number.parseInt(tire.bar || '0'),
              offsetStart: Number.parseInt(tire.offsetStart || '0'),
              offsetEnd: Number.parseInt(tire.offsetEnd || '0'),
              radius: Number.parseInt(tire.radius),
              rim: Number.parseInt(tire.rim),
              thickness: Number.parseInt(tire.thickness),
              width: Number.parseInt(tire.width),
            }),
          };
        });
      });
    });
    console.log(tireFlat);
    setCarList(tireFlat);
  }, []);
  return (
    <div className="p-24 h-screen">
      <DataTable columns={TableColumns} data={carList} />
    </div>
  );
}
