import { useEffect, useState } from "react";
import { Instuctor, Trainers } from "types/types";
import s from "./../../App.module.scss";

const EditInstructor = () => {
  const [selectedOption, setSelectedOption] = useState<Instuctor>();
  const [name, setName] = useState<string>("");
  const [surname, setSurname] = useState<string>("");
  const [price, setPrice] = useState<number>(0);
  const [service, setService] = useState<string>("");
  const [instructors, setInstructors] = useState<Trainers>();
  const [instructorId, setinstructorId] = useState<number | undefined>();

  const handleSelect = (e: any) => {
    e.preventDefault();
    setSelectedOption(
      instructors &&
        instructors.items.find((el) => el.id === parseInt(e.target.value))
    );
    setinstructorId(+e.target.value);
  };
  const handleSave = async (e: any) => {
    e.preventDefault();
    const body = {
      name,
      surname,
      price,
      typeOfService: service,
    };

    try {
      const data = await fetch(`http://localhost:5002/api/Trainers`, {
        method: "PUT",
        body: JSON.stringify(body),
      });
      const res = await data.json();
      console.log(res);
    } catch (e) {
      console.log(e);
    }

    setName("");
    setPrice(0);
    setSurname("");
    setService("");
  };

  const setInputValue = () => {
    const { name, surname, price, typeOfService } = selectedOption as Instuctor;
    console.log(selectedOption);
    setName(name);
    setPrice(price);
    setSurname(surname);
    setService(typeOfService);
  };

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

  return (
    <div>
      <p className={s.title}>Edytuj instruktora</p>
      <div className={s.selectContainer}>
        <select onChange={handleSelect}>
          {instructors?.items.map((op) => {
            return (
              <option key={op.id} value={op.id}>
                {`${op.name} ${op.surname}, ${op.price}zł`}
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
