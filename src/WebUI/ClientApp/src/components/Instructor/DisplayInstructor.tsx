import { useEffect, useState } from "react";
import s from "./../../App.module.scss";
import { InstructorForm } from "./AddInstructor";
import { Trainers } from "types/types";

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
      </div>
    </div>
  );
};

export default DisplayInstructor;
