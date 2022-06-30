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
  instructorPrice: (price: number) => void;
}> = ({ clientId, setInstructorResId, setStep, instructorPrice }) => {
  const [loading, setLoading] = useState<boolean>();
  const [instructorId, setInstructorId] = useState<number>();
  const [instructors, setInstructors] = useState<Trainers>();
  const [price, setPrice] = useState<number>();

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

  const setInstructor = (e: any) => {
    setInstructorId(+e.target.value);
    const instruktor =
      instructors && instructors.items.find((el) => el.id === +e.target.value);
    console.log(instruktor?.price);
    setPrice(instruktor?.price);
  };

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    if (instructorId) {
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
            instructorPrice(price as number);
            setLoading(false);
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
        {form &&
          form.map((el, i) => {
            return (
              <Fragment key={el.id}>
                <label htmlFor={el.name}>{el.name}</label>
                {el.selectOptions?.length ? (
                  <select id={el.id} name={el.name} multiple={el.multiselect}>
                    {el.selectOptions.map((op, i) => {
                      return (
                        <option key={op.id} value={op.id}>
                          {op.label}
                        </option>
                      );
                    })}
                  </select>
                ) : (
                  <input type={el.type} id={el.id} name={el.name}></input>
                )}
              </Fragment>
            );
          })}
        <label>Wybierz Instruktora</label>
        <select onChange={setInstructor}>
          <option key={0} value={undefined}>
            Instruktor
          </option>
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
        </div>
        <div className={s.add}>
          <button type="submit" form="instructorForm">
            Dalej
          </button>
        </div>
      </form>
    </Fragment>
  );
};

export default InstructorStep;
