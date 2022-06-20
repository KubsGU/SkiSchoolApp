import { Instuctor } from "types/types";
import s from "./../../App.module.scss";
import { InstructorForm } from "./AddInstructor";

export const InstructorsList: Instuctor[] = [
  { id: 1, name: "Jakub", surname: "Jelonek", price: 100, service: "-", workHours: '8:00-16:00' },
  { id: 2, name: "Jan", surname: "Pływak", price: 150, service: "-", workHours: '8:00-16:00'  },
  { id: 3, name: "Gołkowski", surname: "Tomasz", price: 2, service: "Dzieci", workHours: '8:00-16:00'  },
];

const DisplayInstructor = () => {
  return (
    <div>
      <p className={s.title}>Wszyscy instruktorzy</p>
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
            {InstructorsList.map((el, i) => {
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
