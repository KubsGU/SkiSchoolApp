import { FC, Fragment, useEffect, useState } from "react";
import s from "./../../App.module.scss";
import Multiselect from "multiselect-react-dropdown";

const EquipentStep: FC<{
  clientId: number | undefined;
  setEquipmentResId: (res: number | undefined) => void;
  setStep: (id: number) => void;
  setEquipmentPrice: (price: number) => void;
}> = ({ clientId, setEquipmentResId, setStep, setEquipmentPrice }) => {
  const [equipmentsTypes, setEquipmentsTypes] = useState<string[]>();
  const [equipmentsType, setEquipmentsType] = useState<string>();
  const [usedTypes, setUsedTypes] = useState<any[]>([]);
  const [selectedEquipments, setSelectedEquipments] = useState<any[]>([]);
  const [price, setPrice] = useState<number>(0);
  const [startDate, setStartDate] = useState<string>();
  const [endDate, setEndDate] = useState<string>();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetch(
          `${process.env.REACT_APP_IP}/Equipments/types`
        );
        const res = await data.json();
        setEquipmentsTypes(res.items);
        setEquipmentsType(res.items[0]);
      } catch (e) {
        console.log(e);
      }
    };
    fetchData();
  }, []);

  const selectEquimpent = (selectedList: any, selectedItem: any) => {
    setSelectedEquipments((oldArray) => [...oldArray, selectedItem]);
    setPrice(price + selectedItem.price);
  };

  const deleteEquimpent = (selectedList: any, removedItem: any) => {
    setSelectedEquipments(
      selectedEquipments.filter((item: any) => item.id !== removedItem.id)
    );
    setPrice(price - removedItem.price);
  };

  const handleAddEqu = async () => {
    if (startDate && endDate) {
      try {
        const data = await fetch(
          `${process.env.REACT_APP_IP}/Equipments/byTypes?Type=${equipmentsType}&StartDate=${startDate}&endDate=${endDate}`
        );
        const res = await data.json();
        if (!usedTypes.some((el) => el.equipmentsType === equipmentsType))
          setUsedTypes((oldArray) => [
            ...oldArray,
            { equipmentsType, children: res },
          ]);
      } catch (e) {
        console.log(e);
      }
    }
  };

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    if (selectedEquipments) {
      const body = {
        startDate: e.target.startDate.value,
        endDate: e.target.endtDate.value,
        equipmentId: selectedEquipments.map((el, i) => el.id),
        clientId: clientId,
        isCancelled: false,
      };

      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/rentals`, {
          method: "POST",
          mode: "cors",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(body),
        });
        const res = data.json().then((e) => {
          if (e) {
            console.log(price);
            setEquipmentResId(e);
            setEquipmentPrice(price);
            setStep(3);
          }
        });
      } catch (e) {
        console.log(e);
      }
    } else {
      setStep(3);
    }
  };
  return (
    <>
      <p className={s.title}>Wprowadz sprzęt</p>
      <form className={s.form} id="instructorForm" onSubmit={handleSubmit}>
        <label htmlFor="Data startu">Data startu</label>
        <input
          type="datetime-local"
          id="startDate"
          name="Data startu"
          onChange={(e) => setStartDate(e.target.value)}
        ></input>
        <label htmlFor="Data końca">Data końca</label>
        <input
          type="datetime-local"
          id="endtDate"
          name="Data końca"
          onChange={(e) => setEndDate(e.target.value)}
        ></input>
        <label>Dodaj sprzęt danego typu</label>
        <div className={s.addContainer}>
          <select onChange={(e) => setEquipmentsType(e.target.value)}>
            {equipmentsTypes &&
              equipmentsTypes.map((e, i) => {
                return (
                  <option key={i} value={e}>
                    {e}
                  </option>
                );
              })}
          </select>
          <i
            className={
              (equipmentsType ? s.plus : s.plusDisable) + " material-icons"
            }
            onClick={handleAddEqu}
          >
            add
          </i>
        </div>
        <div></div>
        <div>
          {usedTypes.map((el, i) => {
            return (
              <div key={i} className="equSelect">
                <Multiselect
                  options={el.children}
                  displayValue="name"
                  onSelect={selectEquimpent}
                  onRemove={deleteEquimpent}
                ></Multiselect>
              </div>
            );
          })}
        </div>
        <div className={s.add}>
          <button onClick={() => setStep(1)} form="instructorForm">
            Powrót
          </button>
        </div>
        <div className={s.add}>
          <button type="submit" form="instructorForm">
            Dalej
          </button>
        </div>
      </form>
    </>
  );
};

export default EquipentStep;
