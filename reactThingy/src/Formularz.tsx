import { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
// ******************************************************
//  nazwa komponentu: Formularz
//  pola stanu: title - tytuł filmu,
//              category - kategoria filmu
//  informacje: Komponent wyświetla formularz, który pozwala na wprowadzenie tytułu filmu oraz wybranie kategorii filmu z listy rozwijanej. Po kliknięciu przycisku Dodaj wyświetlany jest w konsoli komunikat z tytułem i kategorią filmu.
//  autor: Gami
// *****************************************************
function Formularz() {
  const [title, setTitle] = useState('');
  const [category, setCategory] = useState('');

  return (
    <div className="container">
      <form>
        <div className="form-group">
          <label htmlFor="title">Tytuł filmu:</label>
          <input
            type="text"
            className="form-control"
            id="title"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="category">Rodzaj:</label>
          <select
            className="form-control"
            id="category"
            value={category}
            onChange={(e) => setCategory(e.target.value)}
          >
            <option value="">Wybierz...</option>
            <option value="1">Komedia</option>
            <option value="2">Obyczajowy</option>
            <option value="3">Sensacyjny</option>
            <option value="4">Horror</option>
          </select>
        </div>
        <button
          type="button"
          className="btn btn-primary"
          onClick={() => {
            console.log(`tytul: ${title}, rodzaj: ${category} `);
          }}
        >
          Dodaj
        </button>
      </form>
    </div>
  );
}

export default Formularz;
