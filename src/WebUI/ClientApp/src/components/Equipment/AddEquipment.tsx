import { Fragment, MutableRefObject, useRef } from "react";
import { FormElement } from "types/types";
import s from "./../../App.module.scss";

export const EquipmentForm: FormElement[] = [
  { name: "Nazwa", type: "text", id: "name" },
  { name: "Cena", type: "number", id: "price" },
  { name: "Typ sprzetu", type: "text", id: "type" },
];

const AddEquipment = () => {
  const formRef = useRef() as MutableRefObject<HTMLFormElement>;
  const handleData = async (e: any) => {
    e.preventDefault();
    const body = {
      type: e.target.type.value,
      name: e.target.name.value,
      price: +e.target.price.value,
      isActive: true
    };

    console.log(body);

    try {
      await fetch(`${process.env.REACT_APP_IP}/Equipments`, {
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
      <p className={s.title}>Dodaj sprzęt</p>

      <form className={s.form} id="form" onSubmit={handleData} ref={formRef}>
        {EquipmentForm.map((el, i) => {
          return (
            <Fragment key={i}>
              <label htmlFor={el.name}>{el.name}</label>
              <input type={el.type} id={el.id} name={el.name} required></input>
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
