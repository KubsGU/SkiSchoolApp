import { useEffect, useState } from "react";
import { Equipment, Equipments } from "types/types";
import s from "./../../App.module.scss";
import { EquipmentForm } from "./AddEquipment";

export const EquipmentList: Equipment[] = [
  { id: 1, type: "Buty", name: "Szybkie", price: 2, active: true },
  { id: 2, type: "Narty", name: "Duze", price: 7, active: true },
  { id: 3, type: "Narty", name: "Małe", price: 2, active: true },
  { id: 4, type: "Kijki", name: "Białe", price: 5, active: true },
  { id: 5, type: "Buty", name: "Wolne", price: 3, active: false },
];

const DisplayEquipment = () => {
  const [equipments, setEquipments] = useState<Equipments>();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/Equipments`);
        const res = await data.json();
        setEquipments(res);
      } catch (e) {
        console.log(e);
      }
    };
    fetchData();
  }, []);

  return (
    <div>
      <p className={s.title}>Cały sprzęt</p>
      <div className={s.table}>
        <table className="table-auto">
          <thead>
            <tr>
              <th>ID</th>
              {EquipmentForm.map((el, i) => {
                return <th key={i}>{el.name}</th>;
              })}
            </tr>
          </thead>
          <tbody>
            {equipments &&
              equipments.items.map((el, i) => {
                return (
                  <tr key={i}>
                    {Object.values(el).map((val, i) => (
                      <td key={i}>{String(val)}</td>
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

export default DisplayEquipment;
