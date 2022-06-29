import { Fragment, MutableRefObject, useRef } from "react";
import { FormElement } from "types/types";
import s from "./../../App.module.scss";

export const InstructorForm: FormElement[] = [
  { name: "Imie", type: "text", id: "name" },
  { name: "Nazwisko", type: "text", id: "surname" },
  { name: "Cena", type: "number", id: "price" },
  { name: "Typ usługi", type: "text", id: "service" },
  { name: "Godzina startu pracy", type: "time", id: "startTime" },
  { name: "Godzina startu pracy", type: "time", id: "endTime" },
];

const AddInstructor = () => {
  const formRef = useRef() as MutableRefObject<HTMLFormElement>;
  const handleData = async (e: any) => {
    e.preventDefault();
    const body = {
      name: e.target.name.value,
      surname: e.target.surname.value,
      price: e.target.price.value,
      typeOfService: e.target.service.value,
      startTime: e.target.startTime.value,
      endTime: e.target.endTime.value,
      isActive: true,
    };

    try {
      await fetch(`${process.env.REACT_APP_IP}/Trainers`, {
        method: "POST",
        mode: "cors",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(body),
      });

      formRef.current.reset();
    } catch (e) {
      console.log(e);
    }
  };

  return (
    <div>
      <p className={s.title}>Dodaj sdsa </p>

      <form className={s.form} id="form" onSubmit={handleData} ref={formRef}>
        {InstructorForm.map((el, i) => {
          return (
            <Fragment key={i}>
              <label htmlFor={el.name}>{el.name}</label>
              <input type={el.type} id={el.id} name={el.name}  required></input>
            </Fragment>
          );
        })}
      </form>
      <div className={s.add}>
        <button type="submit" form="form" className="material-icons">
          add
        </button>
      </div>
    </div>
  );
};

export default AddInstructor;
