import s from "./../../App.module.scss";
import { ReservationOptions } from "./DeleteReservation";

const PayReservation = () => {
  const handleDelete = (e: any) => {
    e.preventDefault();
  };

  return (
    <div>
      <p className={s.title}>Opłać rezerwacje</p>

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
          payments
        </button>
      </div>
    </div>
  );
};

export default PayReservation;
