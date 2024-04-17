import { useRef, useState } from 'react';
import { Chart } from 'react-google-charts';
import Select from 'react-select';
const MINUTE = 60 * 1000;

export function App() {
  const [columns, setColumns] = useState([
    { type: 'string', label: 'Task ID' },
    { type: 'string', label: 'Task Name' },
    { type: 'string', label: 'Resource' },
    { type: 'date', label: 'Start Date' },
    { type: 'date', label: 'End Date' },
    { type: 'number', label: 'Duration' },
    { type: 'number', label: 'Percent Complete' },
    { type: 'string', label: 'Dependencies' },
  ]);
  const [rows, setRows] = useState([
    ['0', 'Grzanie miensa', 'Kebab', null, null, 5 * MINUTE, 100, null],
    ['2', 'Wkladanie miensa', 'Kebab', null, null, 5 * MINUTE, 100, '0'],
    ['1', 'Wkladanie reszty', null, null, null, 3 * MINUTE, 68, '2'],
    ['3', 'Robienie frytkow', 'Frytki', null, null, 11.5 * MINUTE, 100, null],
    ['4', 'Wydanie posiłku', 'Całość', null, null, 1.5 * MINUTE, 0, '3, 1'],
  ]);
  const depRef = useRef(null);
  return (
    <main>
      <form
        onSubmit={(formData) => {
          formData.preventDefault();
          console.log(formData);
          if (
            formData.currentTarget.elements.namedItem('tName').value == null
          ) {
            alert('Task Name is required');
            return;
          }
          if (
            formData.currentTarget.elements.namedItem('tResource').value == null
          ) {
            alert('Resource is required');
            return;
          }
          if (
            formData.currentTarget.elements.namedItem('tDuration').value == null
          ) {
            alert('Duration is required');
            return;
          }
          if (
            formData.currentTarget.elements.namedItem('tPercent').value == null
          ) {
            alert('Percent is required');
            return;
          }
          if (
            formData.currentTarget.elements.namedItem('tDependencies').value ==
            null
          ) {
            alert('Dependencies is required');
            return;
          }
          const name = formData.currentTarget.elements.namedItem('tName')
            ?.value as string;
          const resource = formData.currentTarget.elements.namedItem(
            'tResource'
          )?.value as string;
          const duration = parseInt(
            formData.currentTarget.elements.namedItem('tDuration')
              ?.value as string
          );
          const percent = parseInt(
            formData.currentTarget.elements.namedItem('tPercent')
              ?.value as string
          );
          let dependenciesReal = [];
          const dependencies =
            formData.currentTarget.elements.namedItem('tDependencies');
          if (dependencies.length > 1) {
            const dependenciesNew = (dependencies as RadioNodeList).values();
            dependenciesNew.forEach((x) => {
              dependenciesReal.push(x.value);
            });
            console.log(dependenciesReal);
          } else {
            dependenciesReal = [dependencies.value];
          }

          console.log(name, resource, duration, percent, dependenciesReal);
          setRows([
            ...rows,
            [
              rows.length.toString(),
              name,
              resource,
              null,
              null,
              duration * MINUTE,
              percent,
              dependenciesReal.join(','),
            ],
          ]);
          //Reset form
          formData.currentTarget.reset();
          depRef.current.clearValue();
        }}
      >
        <label>
          Task Name:
          <input name="tName" type="text" required />
        </label>
        <label>
          Resource:
          <input type="text" name="tResource" required />
        </label>
        <label>
          Duration(minutes):
          <input type="number" name="tDuration" required />
        </label>
        <label>
          Percent Complete:
          <input type="number" name="tPercent" required />
        </label>
        <label>
          Dependencies:
          <Select
            ref={depRef}
            isMulti={true}
            options={rows.map((x) => {
              return { value: x[0], label: x[1] };
            })}
            name="tDependencies"
          />
        </label>
        <button type="submit">Add Task</button>
      </form>

      <Chart
        chartType="Gantt"
        data={[columns, ...rows]}
        width="90%"
        height="400px"
      />
    </main>
  );
}
