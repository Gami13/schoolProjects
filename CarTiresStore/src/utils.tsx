import type { TireFlat } from './App';
import { AppStateType } from './Main';

type TireParams = {
  year: number;
  bar: number;
  offsetStart: number;
  offsetEnd: number;
  radius: number;
  rim: number;
  thickness: number;
  width: number;
};

export function calculateTirePrice(params: TireParams): number {
  const { year, bar, offsetStart, offsetEnd, radius, rim, thickness, width } =
    params;

  const basePrice = 50;
  const maxPrice = 150;

  const yearWeight = (2024 - year) * 0.5;
  const barWeight = bar * 1.5;
  const offsetRange = Math.abs(offsetEnd - offsetStart);
  const offsetWeight = offsetRange * 1.2;
  const radiusWeight = radius * 3.0;
  const rimWeight = rim * 1.8;
  const thicknessWeight = thickness * 0.8;
  const widthWeight = width * 1.2;

  let totalPrice =
    basePrice +
    yearWeight +
    barWeight +
    offsetWeight +
    radiusWeight +
    rimWeight +
    thicknessWeight +
    widthWeight;
  totalPrice = Math.max(50, Math.min(totalPrice / 5, maxPrice));

  totalPrice += seededRand(totalPrice, 1, 250) / 7.237;

  totalPrice = Math.round(totalPrice * 100) / 100;
  const decimalPart = totalPrice % 1;
  if (decimalPart < 0.25) {
    totalPrice = Math.floor(totalPrice);
  } else if (decimalPart < 0.75) {
    totalPrice = Math.floor(totalPrice) + 0.5;
  } else {
    totalPrice = Math.floor(totalPrice) + 0.99;
  }

  return totalPrice;
}

export function seededRand(seed: number, min: number, max: number) {
  const newMax = max || 1;
  const newMin = min || 0;

  const newSeed = (seed * 9301 + 49297) % 233280;
  const rnd = newSeed / 233280;

  return min + rnd * (newMax - newMin);
}

//TODO: Gami fix this, you need to completely remove item and add it again
export function addToCart(state: AppStateType, tireId: number): void {
  const cartItems = state.cartItems;
  const tire = getTire(state.tireList, tireId);
  if (!tire) return;
  const itemIdx = state.cartItems.findIndex((item) => item.id === tireId);
  if (itemIdx !== -1) {
    cartItems[itemIdx].amount += 1;
  } else {
    cartItems.push({ id: tireId, amount: 1 });
  }
  state.setCartItems([...cartItems]);
}
export function removeFromCart(state: AppStateType, tireId: number): void {
  const cartItems = state.cartItems;
  const itemIdx = state.cartItems.findIndex((item) => item.id === tireId);
  if (itemIdx !== -1) {
    cartItems[itemIdx].amount -= 1;
    if (cartItems[itemIdx].amount === 0) {
      cartItems.splice(itemIdx, 1);
    }
    state.setCartItems([...cartItems]);
  }
}
export function getTire(tires: TireFlat[], tireId: number): TireFlat | false {
  const tire = tires.find((tire) => tire.id === tireId);
  if (tire) return tire;
  return false;
}
