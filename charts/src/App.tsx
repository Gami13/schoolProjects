import { Chart } from 'react-google-charts';
const MINUTE = 60 * 1000;

const columns = [
  { type: 'string', label: 'Task ID' },
  { type: 'string', label: 'Task Name' },
  { type: 'string', label: 'Resource' },
  { type: 'date', label: 'Start Date' },
  { type: 'date', label: 'End Date' },
  { type: 'number', label: 'Duration' },
  { type: 'number', label: 'Percent Complete' },
  { type: 'string', label: 'Dependencies' },
];

const rows = [
  ['warmMeat', 'Grzanie miensa', 'Kebab', null, null, 5 * MINUTE, 100, null],
  [
    'insertMeat',
    'Wkladanie miensa',
    'Kebab',

    null,
    null,
    5 * MINUTE,
    100,
    'warmMeat',
  ],
  [
    'insertRest',
    'Wkladanie reszty',
    null,
    null,
    null,
    3 * MINUTE,
    68,
    'insertMeat',
  ],
  [
    'makeFries',
    'Robienie frytkow',
    'Frytki',
    null,
    null,
    11.5 * MINUTE,
    100,
    null,
  ],
  [
    'serve',
    'Wydanie posiłku',
    'Całość',
    null,
    null,
    1.5 * MINUTE,
    0,
    'makeFries, insertRest',
  ],
];

const data = [columns, ...rows];

export function App() {
  return <Chart chartType="Gantt" data={data} width="90%" height="400px" />;
}
