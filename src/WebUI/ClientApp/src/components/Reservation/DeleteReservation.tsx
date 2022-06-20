import { SelectOptions } from "types/types";
import s from "./../../App.module.scss";


export const ReservationOptions: SelectOptions[] = [
  { id: 1, label: "Reservation 1" },
  { id: 2, label: "Reservation 2" },
  { id: 3, label: "Reservation 3" },
];

const DeleteReservation = () => {
  const handleDelete = (e: any) => {
    e.preventDefault();
  };

  return (
    <div>
      <p className={s.title}>Anuluj rezerwacje</p>

      <div className={s.selectContainer}>
        <select>
          {ReservationOptions.map((op) => {
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
          cancel
        </button>
      </div>
    </div>
  );
};

export default DeleteReservation;
