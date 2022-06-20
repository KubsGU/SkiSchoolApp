import { Fragment } from "react";
import { FormElement } from "types/types";
import s from "./../../App.module.scss";

export const InstructorForm: FormElement[] = [
  { name: "Imie", type: "text", id: "name" },
  { name: "Nazwisko", type: "text", id: "surname" },
  { name: "Cena", type: "number", id: "price" },
  { name: "Typ usługi", type: "text", id: "service" },
  { name: "Godziny pracy", type: "text", id: "workHours" }
];

const AddInstructor = () => {
  const handleData = (e: any) => {
    e.preventDefault();
    const body = {
      name: e.target.name.value,
      surname: e.target.surname.value,
      price: e.target.price.value,
      service: e.target.service.value,
    };
    console.log(body);
  };

  return (
    <div>
      <p className={s.title}>Dodaj instruktora</p>

      <form className={s.form} id="form" onSubmit={handleData}>
        {InstructorForm.map((el, i) => {
          return (
            <Fragment key={i}>
              <label htmlFor={el.name}>{el.name}</label>
              <input type={el.type} id={el.id} name={el.name}></input>
            </Fragment>
          );
        })}
      </form>
      <div className={s.add}>
      <button
          type="submit"
          form="form"
          className="material-icons"
          onClick={handleData}
        >
          add
        </button>
      </div>
    </div>
  );
};

export default AddInstructor;
