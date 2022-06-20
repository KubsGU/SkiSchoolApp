import { instructorsOptions } from "components/Reservation/Reservation";
import s from "./../../App.module.scss";

//
// TO DO to samo co w edycji najwpierw zapytac o instruktora pokazac jego godzine z mozliwoscia edycji albo mozemy meic
// to w dupie i wybierac instruktora wpisywac jego gzine i wysylac bez pokazania aktualnej
//

const SearchReservation = () => {
  const handleSelect = (e: any) => {
    e.preventDefault();
  };
  const handleSave = (e: any) => {
    e.preventDefault();
  };

  return (
    <div>
      <p className={s.title}>Wyszukaj rezerwacje</p>
      <form className={s.form} id="form" onSubmit={handleSave}>
        <label>Nr dowodu</label>
        <input
          type="text"
          required
        />
      </form>
      <div className={s.add}>
        <button
          type="submit"
          form="form"
          className="material-icons"
          onClick={handleSave}
        >
          search
        </button>
      </div>
    </div>
  );
};

export default SearchReservation;
