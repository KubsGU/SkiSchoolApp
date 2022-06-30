import { useEffect, useState } from "react";
import { Equipments } from "types/types";
import s from "./../../App.module.scss";

const DeleteEquipment = () => {
  const [equipment, setEquipment] = useState<Equipments>();
  const [equipmentId, setEquipmentId] = useState<number | undefined>();
  const [reload, setReload] = useState(false);

  const handleDelete = async (e: any) => {
    e.preventDefault();

    try {
      await fetch(`${process.env.REACT_APP_IP}/Equipments/${equipmentId}`, {
        method: "DELETE",
      });
      setReload(true);
    } catch (e) {
      console.log(e);
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/Equipments`);
        const res = await data.json();
        setEquipment(res);
        setEquipmentId(res.items[0].id);
      } catch (e) {
        console.log(e);
      }
    };
    fetchData();
  }, [reload]);

  return (
    <div>
      <p className={s.title}>Usuń sprzet</p>

      <div className={s.selectContainer}>
        <select onChange={(e) => setEquipmentId(+e.target.value)}>
          {equipment &&
            equipment.items.map((op) => {
              return (
                <option key={op.id} value={op.id}>
                  {`${op.name}, ${op.price}zł`}
                </option>
              );
            })}
        </select>

        <button
          type="submit"
          form="form"
          className="material-icons"
          onClick={handleDelete}
        >
          remove
        </button>
      </div>
    </div>
  );
};

export default DeleteEquipment;
