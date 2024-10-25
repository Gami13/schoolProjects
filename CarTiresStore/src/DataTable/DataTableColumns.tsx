import type { AppStateType } from '@/Main';
import { addToCart } from '@/utils';
import type { ColumnDef } from '@tanstack/react-table';
import { ShoppingBasketIcon } from 'lucide-react';
import type { TireFlat } from '../App';
import { Button } from '../components/ui/button';
import { DataTableColumnHeader } from './DataTableHeader';

export function TableColumns(State: AppStateType): ColumnDef<TireFlat>[] {
  return [
    {
      accessorKey: 'make',
      header: ({ column }) => (
        <DataTableColumnHeader column={column} title="Make" />
      ),
    },
    {
      accessorKey: 'model',

      header: ({ column }) => (
        <DataTableColumnHeader column={column} title="Model" />
      ),
      enableMultiSort: true,
    },
    {
      accessorKey: 'fuelType',
      header: ({ column }) => (
        <DataTableColumnHeader column={column} title="Fuel Type" />
      ),
      enableMultiSort: true,
    },
    {
      accessorKey: 'radius',
      header: ({ column }) => (
        <DataTableColumnHeader column={column} title="Radius" />
      ),
      enableMultiSort: true,
    },
    {
      accessorKey: 'width',
      header: ({ column }) => (
        <DataTableColumnHeader column={column} title="Width" />
      ),
      enableMultiSort: true,
    },
    {
      accessorKey: 'thickness',
      header: ({ column }) => (
        <DataTableColumnHeader column={column} title="Thickness" />
      ),
      enableMultiSort: true,
    },
    {
      accessorKey: 'rim',
      header: ({ column }) => (
        <DataTableColumnHeader column={column} title="Rim" />
      ),
      sortUndefined: 1,
      enableMultiSort: true,
    },
    {
      accessorKey: 'bars',
      header: ({ column }) => (
        <DataTableColumnHeader column={column} title="Pressure" />
      ),
      sortUndefined: 1,
      enableMultiSort: true,
    },
    {
      id: 'offset',
      header: ({ column }) => (
        <DataTableColumnHeader column={column} title="Offset" />
      ),
      accessorFn: (row) =>
        row.offsetStart ? `${row.offsetStart} - ${row.offsetEnd}` : '',
      sortUndefined: 1,

      // enableSorting: false,
    },
    {
      accessorKey: 'price',
      enableMultiSort: true,

      header: ({ column }) => (
        <DataTableColumnHeader
          className="text-right"
          column={column}
          title="Price"
        />
      ),
      cell: ({ row }) => {
        const amount = Number.parseFloat(row.getValue('price'));
        const formatted = new Intl.NumberFormat('en-US', {
          style: 'currency',
          currency: 'USD',
        }).format(amount);

        return <div className="text-right font-medium">{formatted}</div>;
      },
    },
    {
      id: 'edit',
      accessorKey: 'id',
      header: 'Actions',

      cell: (e) => (
        <div className="text-right">
          <Button
            variant="secondary"
            onClick={() => {
              addToCart(State, e.getValue() as number);

              console.log(State.cartItems);
            }}
          >
            <ShoppingBasketIcon />
          </Button>
        </div>
      ),
    },
  ];
}
