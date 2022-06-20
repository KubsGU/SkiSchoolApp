import { equipmentOptions } from "components/Reservation/Reservation";
import { Fragment } from "react";
import s from "./../../App.module.scss";
import { EquipmentForm } from "./AddEquipment";

// 
// TO DO to samo co dla instruktora
// 

const EditEquipment = () => {
  const handleSelect = (e: any) => {
    e.preventDefault();
  }
  const handleSave = (e: any) => {
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
      <p className={s.title}>Edytuj instruktora</p>
      <div className={s.selectContainer}>
        <select>
          {equipmentOptions.map((op) => {
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
          onClick={handleSelect}
        >
          edit
        </button>
      </div>

      <form className={s.form} id="form" onSubmit={handleSave}>
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

        <button
          type="submit"
          form="form"
          className="material-icons"
          onClick={handleSave}
        >
          save
        </button>
      </div>
    </div>
  );
};

export default EditEquipment;
