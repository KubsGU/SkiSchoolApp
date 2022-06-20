import { instructorsOptions } from "components/Reservation/Reservation";
import { Fragment } from "react";
import s from "./../../App.module.scss";
import { InstructorForm } from "./AddInstructor";

//
// TO DO to samo co w edycji najwpierw zapytac o instruktora pokazac jego godzine z mozliwoscia edycji albo mozemy meic
// to w dupie i wybierac instruktora wpisywac jego gzine i wysylac bez pokazania aktualnej
//

const WorkHours = () => {
  const handleSelect = (e: any) => {
    e.preventDefault();
  };
  const handleSave = (e: any) => {
    e.preventDefault();
  };

  return (
    <div>
      <p className={s.title}>Godziny pracy</p>
      <div className={s.selectContainer}>
        <select>
          {instructorsOptions.map((op) => {
            return (
              <option key={op.id} value={op.id}>
                {op.label}
              </option>
            );
          })}
        </select>

        <button
          type="submit"
          form="form"
          className="material-icons"
          onClick={handleSelect}
        >
          edit
        </button>
      </div>

      <form className={s.form} id="form" onSubmit={handleSave}>
        <label>Początek</label>
        <input
          type="time"
          name="appt"
          min="07:00"
          max="22:00"
          required
        />
        <label>Koniec</label>
        <input
          type="time"
          name="appt"
          min="07:00"
          max="22:00"
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
          save
        </button>
      </div>
    </div>
  );
};

export default WorkHours;
