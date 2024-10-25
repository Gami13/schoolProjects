import { type ReactNode, StrictMode, createContext, useState } from 'react';
import { createRoot } from 'react-dom/client';
import { App, type CartItem, type TireFlat } from './App.tsx';
import './index.css';
//@ts-expect-error i know what im doing
export const AppState = createContext<AppStateType>();

export type AppStateType = {
  cartItems: CartItem[];
  setCartItems: (items: CartItem[]) => void;
  tireList: TireFlat[];
  setTireList: (items: TireFlat[]) => void;
};

export function AppStateProvider({ children }: { children: ReactNode }) {
  const [cartItems, setCartItems] = useState<CartItem[]>([]);
  const [tireList, setTireList] = useState<TireFlat[]>([]);

  return (
    <AppState.Provider
      value={{
        cartItems,
        setCartItems,
        tireList,
        setTireList,
      }}
    >
      {children}
    </AppState.Provider>
  );
}
const root = document.querySelector('#root');
if (root) {
  createRoot(root).render(
    <StrictMode>
      <AppStateProvider>
        <App />
      </AppStateProvider>
    </StrictMode>
  );
}
