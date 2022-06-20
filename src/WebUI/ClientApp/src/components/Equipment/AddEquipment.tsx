import { Fragment } from "react";
import { FormElement } from "types/types";
import s from "./../../App.module.scss";

export const EquipmentForm: FormElement[] = [
  { name: "Typ sprzetu", type: "text", id: "type" },
  { name: "Nazwa", type: "text", id: "name" },
  { name: "Cena", type: "number", id: "price" },
  { name: "Aktywny", type: "checkbox", id: "active" },
];

const AddEquipment = () => {
  const handleData = (e: any) => {
    e.preventDefault();
    const body = {
      type: e.target.type.value,
      name: e.target.name.value,
      price: e.target.price.value,
      active: e.target.active.value,
    };
    console.log(body);
  };

  return (
    <div>
      <p className={s.title}>Dodaj sprzęt</p>

      <form className={s.form} id="form" onSubmit={handleData}>
        {EquipmentForm.map((el, i) => {
          return (
            <Fragment key={i}>
              <label htmlFor={el.name}>{el.name}</label>
              <input type={el.type} id={el.id} name={el.name}></input>
            </Fragment>
          );
        })}
      </form>
      <div className={s.add}>
        <button type="submit" form="form">
          Dodaj
        </button>
      </div>
    </div>
  );
};

export default AddEquipment;
