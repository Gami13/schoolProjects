const courses = [
  'Programowanie w C#',
  'Angular dla początkujących',
  'Kurs Django',
];
export function App() {
  return (
    <>
      <h2>Liczba kursów {courses.length}</h2>
      <ol>
        {courses.map((course) => (
          <li key={course}>{course}</li>
        ))}
      </ol>
      <form
        onSubmit={(
          e: React.SyntheticEvent<HTMLFormElement> & {
            currentTarget: HTMLFormElement & {
              elements: {
                name: { value: string };
                course: { value: string };
              };
            };
          }
        ) => {
          e.preventDefault();

          console.log(e.currentTarget.elements.name.value);
          console.log(
            courses[
              Number.parseInt(e.currentTarget.elements.course.value) - 1
            ] || 'Nieprawidłowy numer kursu'
          );
        }}
      >
        <div className="form-group">
          <label htmlFor="name">Imię i nazwisko:</label>
          <input className="form-control" id="name" name="name" type="text" />
        </div>

        <div className="form-group">
          <label htmlFor="course" className="form-group">
            Numer kursu:
          </label>
          <input
            className="form-control"
            id="course"
            name="course"
            type="number"
          />
        </div>
        <div className="form-group">
          <button className="btn btn-primary" type="submit">
            Zapisz do kursu
          </button>
        </div>
      </form>
    </>
  );
}

export default App;
