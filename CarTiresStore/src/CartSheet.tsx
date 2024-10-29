import { Button } from '@/components/ui/button';
import {
  Sheet,
  SheetClose,
  SheetContent,
  SheetDescription,
  SheetFooter,
  SheetHeader,
  SheetTitle,
  SheetTrigger,
} from '@/components/ui/sheet';
import { ShoppingCartIcon } from 'lucide-react';
import { useContext, useEffect, useState } from 'react';
import { AppState } from './Main';
import { addToCart, getTire, removeFromCart } from './utils';

export function CartSheet() {
  const State = useContext(AppState);
  const [total, setTotal] = useState(0);

  // biome-ignore lint/correctness/useExhaustiveDependencies: <explanation>
  useEffect(() => {
    let newTotal = 0;
    for (const item of State.cartItems) {
      const tire = getTire(State.tireList, item.id);
      if (!tire) return null;
      newTotal += tire.price * item.amount;
    }
    setTotal(newTotal);
  }, [State.cartItems]);

  return (
    <Sheet>
      <SheetTrigger asChild className="absolute top-4 left-4">
        <Button variant="outline">
          <ShoppingCartIcon /> Open Cart
        </Button>
      </SheetTrigger>
      <SheetContent className="flex justify-between flex-col">
        <SheetHeader>
          <SheetTitle>Your Cart - Total: ${total}</SheetTitle>
          <SheetDescription>
            Make changes to your cart, or proceed to checkout.
          </SheetDescription>
        </SheetHeader>
        <div className="grid gap-4 py-4 h-5/6">
          <ol className="flex flex-col gap-2  overflow-y-auto scroll-p-2 ">
            {State.cartItems.length === 0 && (
              <li>Your cart is empty. Add some items to get started!</li>
            )}
            {State.cartItems.map((item, index) => {
              const tire = getTire(State.tireList, item.id);
              if (!tire) return null;

              return (
                <>
                  <li
                    className="flex gap-1 w-full justify-between items-center "
                    key={item.id}
                  >
                    <span className="align-middle flex justify-start items-end gap-1 h-fit w-3/6">
                      {tire.width}/{tire.thickness}R{tire.radius}
                      <small className=" text-slate-400 h-full">
                        {tire.make} {tire.model}
                      </small>
                    </span>
                    <div className="flex gap-1 w-2/6 items-center">
                      <Button
                        className="w-8 h-8"
                        onClick={() => {
                          removeFromCart(State, item.id);
                        }}
                        variant="outline"
                      >
                        -
                      </Button>
                      <span className="rounded-xl flex justify-center items-center bg-secondary h-10 w-10 ">
                        {item.amount}
                      </span>
                      <Button
                        className="w-8 h-8"
                        onClick={() => {
                          addToCart(State, item.id);
                        }}
                        variant="outline"
                      >
                        +
                      </Button>
                    </div>
                    <span className="w-1/6 flex justify-end">
                      ${tire.price * item.amount}
                    </span>
                  </li>
                  {index !== State.cartItems.length - 1 && (
                    <li
                      key={`${item.id}sep`}
                      className="bg-secondary w-full h-px"
                    />
                  )}
                </>
              );
            })}
          </ol>
        </div>
        <SheetFooter>
          <div className="flex justify-around w-full gap-3">
            <Button className="w-1/2" type="submit">
              Order
            </Button>
            <SheetClose asChild>
              <Button className="w-1/2" type="submit" variant={'outline'}>
                Close
              </Button>
            </SheetClose>
          </div>
        </SheetFooter>
      </SheetContent>
    </Sheet>
  );
}
