import { instructorsOptions } from "components/Reservation/Reservation";
import { InstructorsList } from "./DisplayInstructor";
import { useState } from "react";
import { Instuctor } from "types/types";
import s from "./../../App.module.scss";

const EditInstructor = () => {
  const [selectedOption, setSelectedOption] = useState<Instuctor>();
  const [name, setName] = useState<string>("");
  const [surname, setSurname] = useState<string>("");
  const [price, setPrice] = useState<number>(0);
  const [service, setService] = useState<string>("");
  const [workHours, setWorkHours] = useState<string>("");

  const handleSelect = (e: any) => {
    e.preventDefault();
    setSelectedOption(
      InstructorsList.find((el) => el.id === parseInt(e.target.value))
    );
  };
  const handleSave = (e: any) => {
    e.preventDefault();
    const body = {
      name,
      surname,
      price,
      service,
      workHours,
    };

    setName("");
    setPrice(0);
    setSurname("");
    setService("");
    setWorkHours("");
  };

  const setInputValue = () => {
    const { name, surname, price, service, workHours } =
      selectedOption as Instuctor;
    setName(name);
    setPrice(price);
    setSurname(surname);
    setService(service);
    setWorkHours(workHours);
  };

  return (
    <div>
      <p className={s.title}>Edytuj instruktora</p>
      <div className={s.selectContainer}>
        <select onChange={handleSelect}>
          {instructorsOptions.map((op) => {
            return (
              <option key={op.id} value={op.id}>
                {op.label}
              </option>
            );
          })}
        </select>

        <button className="material-icons" onClick={setInputValue}>
          edit
        </button>
      </div>

      <form className={s.form} id="form" onSubmit={handleSave}>
        <label htmlFor="Imie">Imie</label>
        <input
          type="text"
          id="name"
          name="Imie"
          value={name}
          onChange={(e) => setName(e.target.value)}
        ></input>
        <label htmlFor="Nazwisko">Nazwisko</label>
        <input
          type="text"
          id="surname"
          name="Nazwisko"
          value={surname}
          onChange={(e) => setSurname(e.target.value)}
        ></input>
        <label htmlFor="Cena">Cena</label>
        <input
          type="number"
          id="price"
          name="Cena"
          min={0}
          value={price}
          onChange={(e) => setPrice(parseInt(e.target.value))}
        ></input>
        <label htmlFor="Typ usługi">Typ usługi</label>
        <input
          type="text"
          id="service"
          name="Typ usługi"
          value={service}
          onChange={(e) => setService(e.target.value)}
        ></input>
        <label htmlFor="Godziny pracy">Godziny pracy</label>
        <input
          type="text"
          id="workHours"
          name="Godziny pracy"
          value={workHours}
          onChange={(e) => setWorkHours(e.target.value)}
        ></input>
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

export default EditInstructor;
