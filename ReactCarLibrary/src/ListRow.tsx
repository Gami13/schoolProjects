import { useState } from 'react';
import type { CarFormElements } from './App';
import { Input } from './Input';
import {
  type Car,
  type CarAction,
  addCar,
  deleteCar,
  updateCar,
} from './State';

function getBase64(file: File): Promise<string> {
  return new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result as string);
    reader.onerror = (error) => reject(error);
  });
}

export function ListRow(props: {
  car?: Car;
  dispatch: React.Dispatch<CarAction>;
  isEditable: boolean;
}) {
  const [isEditing, setIsEditing] = useState(props.car === undefined);
  return (
    <li>
      <form
        onSubmit={async (e: React.FormEvent<HTMLFormElement>) => {
          e.preventDefault();
          const target = e.currentTarget.elements as CarFormElements;
          const make = target.make.value;
          const model = target.model.value;
          const productionYear = target.productionYear.value;
          const power = target.power.value;
          const price = target.price.value;
          let image = '';
          if (target.image.files && target.image.files[0] !== undefined) {
            image = await getBase64(target.image.files[0]);
          }
          console.log(image, target.image.files);
          if (!make || !model || !productionYear || !power || !price) {
            return;
          }
          if (props.car === undefined) {
            addCar(props.dispatch, {
              make,
              model,
              productionYear: Number.parseInt(productionYear, 10),
              power: Number.parseInt(power, 10),
              price: Number.parseInt(price, 10),
              image,
            });
            target.make.value = '';
            target.model.value = '';
            target.productionYear.value = '';
            target.power.value = '';
            target.price.value = '';
          } else {
            const newCar: Car = {
              id: props.car.id,
              make,
              model,
              productionYear: Number.parseInt(productionYear, 10),
              power: Number.parseInt(power, 10),
              price: Number.parseInt(price, 10),
              image: props.car.image,
            };
            updateCar(props.dispatch, newCar);
            setIsEditing(false);
          }
        }}
      >
        <Input
          type="text"
          placeholder="Make"
          name="make"
          required
          initialValue={props.car?.make}
          isEditing={isEditing}
        />
        <Input
          type="text"
          placeholder="Model"
          name="model"
          required
          initialValue={props.car?.model}
          isEditing={isEditing}
        />
        <Input
          type="number"
          placeholder="Production year"
          name="productionYear"
          required
          pattern="\d+"
          initialValue={props.car?.productionYear.toString()}
          isEditing={isEditing}
        />
        <Input
          type="number"
          placeholder="Power"
          name="power"
          required
          pattern="\d+"
          initialValue={props.car?.power.toString()}
          isEditing={isEditing}
        />
        <Input
          type="number"
          placeholder="Price"
          name="price"
          required
          pattern="\d+"
          initialValue={props.car?.price.toString()}
          isEditing={isEditing}
        />
        <img src={props.car?.image} alt="" />
        {isEditing && (
          <input
            type="file"
            name="image"
            accept="image/png, image/jpeg"
            defaultValue={props.car?.image}
          />
        )}
        {props.isEditable && isEditing && (
          <>
            <button type="submit">Save</button>
            <button type="button" onClick={() => setIsEditing(false)}>
              Cancel
            </button>
          </>
        )}
        {props.isEditable && !isEditing && (
          <button type="button" onClick={() => setIsEditing(true)}>
            Edit
          </button>
        )}
        {props.isEditable && props.car !== undefined ? (
          <>
            <button
              type="button"
              onClick={() => deleteCar(props.dispatch, (props.car as Car).id)}
            >
              Delete
            </button>
          </>
        ) : null}
        {props.isEditable === false && props.car === undefined ? (
          <button type="submit">Add car</button>
        ) : null}
      </form>
    </li>
  );
}
