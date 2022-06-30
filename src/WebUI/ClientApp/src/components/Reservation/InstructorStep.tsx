import { FC, Fragment, useEffect, useState } from "react";
import s from "./../../App.module.scss";

const InstructorStep: FC<{
  clientId: number | undefined;
  setInstructorResId: (res: number | undefined) => void;
  setStep: (id: number) => void;
  instructorPrice: (price: number) => void;
}> = ({ clientId, setInstructorResId, setStep, instructorPrice }) => {
  const [instructorId, setInstructorId] = useState<number>();
  const [instructors, setInstructors] = useState<any[]>([]);
  const [price, setPrice] = useState<number>();
  const [startDate, setStartDate] = useState<string>();
  const [endDate, setEndDate] = useState<string>();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetch(
          `${process.env.REACT_APP_IP}/Trainers/available?StartDate=${startDate}&EndDate=${endDate}`
        );
        const res = await data.json();
        setInstructors(res);
      } catch (e) {
        console.log(e);
      }
    };
    if (startDate && endDate) {
      fetchData();
    }
  }, [startDate, endDate]);

  const setInstructor = (e: any) => {
    setInstructorId(+e.target.value);
    const instruktor =
      instructors && instructors.find((el) => el.id === +e.target.value);
    setPrice(instruktor?.price);
  };

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    if (instructorId) {
      const body = {
        startDate: e.target.startDate.value,
        endDate: e.target.endtDate.value,
        trainerId: instructorId,
        clientId: clientId,
        isCancelled: false,
      };

      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/Timetables`, {
          method: "POST",
          mode: "cors",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(body),
        });
        const res = data.json().then((e) => {
          if (e) {
            setInstructorResId(e);
            instructorPrice(price as number);
            setStep(2);
          }
        });
      } catch (e) {
        console.log(e);
      }
    } else {
      setStep(2);
    }
  };
  return (
    <Fragment>
      <p className={s.title}>Wprowadz instruktora</p>
      <form className={s.form} id="instructorForm" onSubmit={handleSubmit}>
        <label htmlFor="Data startu">Data startu</label>
        <input
          type="datetime-local"
          id="startDate"
          name="Data startu"
          onChange={(e) => setStartDate(e.target.value)}
        ></input>
        <label htmlFor="Data końca">Data końca</label>
        <input
          type="datetime-local"
          id="endtDate"
          name="Data końca"
          onChange={(e) => setEndDate(e.target.value)}
        ></input>
        <label>Wybierz Instruktora</label>
        <select onChange={setInstructor}>
          <option key={0} value={undefined}>
            Instruktor
          </option>
          {instructors &&
            instructors.map((e, i) => {
              return (
                <option key={i} value={e.id}>
                  {`${e.name} ${e.surname}, ${e.price}zł`}
                </option>
              );
            })}
        </select>
        <div></div>
        <div className={s.next}>
          <button type="submit" form="instructorForm">
            Dalej
          </button>
        </div>
      </form>
    </Fragment>
  );
};

export default InstructorStep;
