import { useEffect, useState } from "react";
import { Rental, Rentals, SelectOptions, Timetables } from "types/types";
import s from "./../../App.module.scss";

const DeleteReservation = () => {
  const [rentalId, setRentalId] = useState<number | undefined>();
  const [rentals, setRentals] = useState<Rentals>();
  const [timetableId, setTimetableId] = useState<number | undefined>();
  const [timetables, setTimetables] = useState<Timetables>();
  const [reload, setReload] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/Rentals`);
        const res = await data.json();
        setRentals(res);
      } catch (e) {
        console.log(e);
      }
    };
    fetchData();
  }, []);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/Timetables`);
        const res = await data.json();
        setTimetables(res);
      } catch (e) {
        console.log(e);
      }
    };
    fetchData();
  }, []);

  const handleDelete = (e: any) => {
    e.preventDefault();
  };

  return (
    <div>
      <p className={s.title}>Anuluj rezerwacje</p>
      <form className={s.form} id="form" onSubmit={handleDelete}>
        <label>Wybierz lekcję</label>
        <select>
          {timetables &&
            timetables.items.map((op) => {
              return (
                <option key={op.id} value={op.id}>
                  {`${op.id}: ${op.client.name} ${op.client.surname}, ${op.trainer.name}`}
                </option>
              );
            })}
        </select>
        <label>Wybierz sprzęt</label>
        <select>
          {rentals &&
            rentals.items.map((op) => {
              return (
                <option key={op.id} value={op.id}>
                  {`${op.id}: ${op.client.name} ${op.client.surname}`}
                </option>
              );
            })}
        </select>
      </form>
      <div className={s.add}>
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
