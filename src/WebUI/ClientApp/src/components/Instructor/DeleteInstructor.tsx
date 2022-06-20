import { instructorsOptions } from "components/Reservation/Reservation";
import s from "./../../App.module.scss";

const DeleteInstructor = () => {
  const handleDelete = (e: any) => {
    e.preventDefault();
  };

  return (
    <div>
      <p className={s.title}>Usuń instruktora</p>

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
          onClick={handleDelete}
        >
          remove
        </button>
      </div>
    </div>
  );
};

export default DeleteInstructor;
