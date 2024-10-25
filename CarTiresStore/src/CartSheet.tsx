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
import { useContext, useEffect } from 'react';
import { AppState } from './Main';
import { addToCart, getTire, removeFromCart } from './utils';

export function CartSheet() {
  const State = useContext(AppState);
  useEffect(() => {
    console.log('Łefekt', State.cartItems);
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
          <SheetTitle>Your Cart</SheetTitle>
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
                  <li className="flex  w-full justify-between " key={item.id}>
                    <span className="align-middle flex justify-center items-center">
                      {tire.make} {tire.model} | {tire.width}/{tire.thickness}R
                      {tire.radius}
                    </span>
                    <div className="flex gap-1 ">
                      <Button
                        onClick={() => {
                          removeFromCart(State, item.id);
                        }}
                        variant="outline"
                      >
                        -
                      </Button>
                      <span className="rounded-xl flex justify-center items-center bg-secondary h-full aspect-square ">
                        {item.amount}
                      </span>
                      <Button
                        onClick={() => {
                          addToCart(State, item.id);
                        }}
                        variant="outline"
                      >
                        +
                      </Button>
                    </div>
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
