import { useEffect, useState } from "react";
import { Instuctor } from "types/types";
import s from "./../../App.module.scss";
import { InstructorForm } from "./AddInstructor";
import { Trainers } from "types/types";

export const InstructorsList: Instuctor[] = [
  {
    id: 1,
    name: "Jakub",
    surname: "Jelonek",
    price: 100,
    typeOfService: "-",
    workHours: "8:00-16:00",
  },
  {
    id: 2,
    name: "Jan",
    surname: "Pływak",
    price: 150,
    typeOfService: "-",
    workHours: "8:00-16:00",
  },
  {
    id: 3,
    name: "Gołkowski",
    surname: "Tomasz",
    price: 2,
    typeOfService: "Dzieci",
    workHours: "8:00-16:00",
  },
];

const DisplayInstructor = () => {
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
  return (
    <div>
      <p className={s.title}>Wszyscy instrusktorzy</p>
      <div className={s.table}>
        <table className="table-auto">
          <thead>
            <tr>
              <th>ID</th>
              {InstructorForm.map((el, i) => {
                return <th key={i}>{el.name}</th>;
              })}
            </tr>
          </thead>
          <tbody>
            {instructors &&
              instructors.items.map((el, i) => {
                return (
                  <tr key={i}>
                    {Object.values(el).map((val, i) => (
                      <td key={i}>{val}</td>
                    ))}
                  </tr>
                );
              })}
          </tbody>
        </table>
      </div>{" "}
    </div>
  );
};

export default DisplayInstructor;
