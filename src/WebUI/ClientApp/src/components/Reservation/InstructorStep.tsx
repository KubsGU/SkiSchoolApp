import { FC, Fragment, useEffect, useState } from "react";
import { Client, FormElement, Trainers } from "types/types";
import s from "./../../App.module.scss";

const form: FormElement[] = [
  { name: "Data startu", type: "datetime-local", id: "startDate" },
  { name: "Data końca", type: "datetime-local", id: "endtDate" },
];

const InstructorStep: FC<{
  clientId: number | undefined;
  setInstructorResId: (res: number | undefined) => void;
  setStep: (id: number) => void;
}> = ({ clientId, setInstructorResId, setStep }) => {
  const [loading, setLoading] = useState<boolean>();
  const [instructorId, setInstructorId] = useState<number>();
  const [instructors, setInstructors] = useState<Trainers>();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/Trainers`);
        const res = await data.json();
        setInstructors(res);
      } catch (e) {
        console.log(e);
      }
    };
    fetchData();
  }, []);

  console.log(clientId);

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    setLoading(true);
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
          setLoading(false);
        }
      });
    } catch (e) {
      console.log(e);
    }
  };
  return (
    <form className={s.form} id="instructorForm" onSubmit={handleSubmit}>
      {form &&
        form.map((el, i) => {
          return (
            <Fragment key={el.id}>
              <label htmlFor={el.name}>{el.name}</label>
              {el.selectOptions?.length ? (
                <select
                  id={el.id}
                  name={el.name}
                  multiple={el.multiselect}
                  required
                >
                  {el.selectOptions.map((op, i) => {
                    return (
                      <option key={op.id} value={op.id}>
                        {op.label}
                      </option>
                    );
                  })}
                </select>
              ) : (
                <input
                  type={el.type}
                  id={el.id}
                  name={el.name}
                  required
                ></input>
              )}
            </Fragment>
          );
        })}
      <label>Wybierz Instruktora</label>
      <select onChange={(e) => setInstructorId(+e.target.value)}>
        {instructors &&
          instructors.items.map((e, i) => {
            return (
              <option key={i} value={e.id}>
                {`${e.name} ${e.surname}, ${e.price}zł`}
              </option>
            );
          })}
      </select>
      <div className={s.add}>
        <button onClick={() => setStep(0)} form="instructorForm">
          Powrót
        </button>
        <button type="submit" form="instructorForm">
          Dalej
        </button>
      </div>
    </form>
  );
};

export default InstructorStep;
