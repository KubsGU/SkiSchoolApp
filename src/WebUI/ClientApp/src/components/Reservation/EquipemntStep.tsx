import { FC, Fragment, useEffect, useState } from "react";
import { Client, FormElement, Trainers } from "types/types";
import s from "./../../App.module.scss";
import Multiselect from "multiselect-react-dropdown";

const Form: FormElement[] = [
  { name: "Data startu", type: "datetime-local", id: "startDate" },
  { name: "Data końca", type: "datetime-local", id: "endtDate" },
];

const EquipentStep: FC<{
  clientId: number | undefined;
  setEquipmentResId: (res: number | undefined) => void;
  setStep: (id: number) => void;
  setEquipmentPrice: (price: number) => void;
}> = ({ clientId, setEquipmentResId, setStep, setEquipmentPrice }) => {
  const [loading, setLoading] = useState<boolean>();
  const [equipmentIds, setEquipmentIds] = useState<number[]>();
  const [equipmentsTypes, setEquipmentsTypes] = useState<string[]>();
  const [equipmentsType, setEquipmentsType] = useState<string>();
  const [reservationForm, setReservationForm] = useState<FormElement[]>(Form);
  const [usedTypes, setUsedTypes] = useState<any[]>([]);
  const [selectedEquipments, setSelectedEquipments] = useState<any[]>([]);
  const [price, setPrice] = useState<number>(0);

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

  const show = () => {
    console.log(selectedEquipments);
  };

  const handleAddEqu = async () => {
    try {
      const data = await fetch(
        `${process.env.REACT_APP_IP}/Equipments/byTypes?Type=${equipmentsType}`
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
  };

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    if (selectedEquipments) {
      setLoading(true);
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
            setLoading(false);
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
    <Fragment>
      <p className={s.title}>Wprowadz sprzęt</p>
      <form className={s.form} id="instructorForm" onSubmit={handleSubmit}>
        {reservationForm &&
          reservationForm.map((el, i) => {
            return (
              <Fragment key={el.id}>
                <label htmlFor={el.name}>{el.name}</label>
                {el.selectOptions?.length ? (
                  <select id={el.id} name={el.name} multiple={el.multiselect}>
                    {el.selectOptions.map((op, i) => {
                      return (
                        <option key={op.id} value={op.id}>
                          {op.label}
                        </option>
                      );
                    })}
                  </select>
                ) : (
                  <input type={el.type} id={el.id} name={el.name}></input>
                )}
              </Fragment>
            );
          })}
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
    </Fragment>
  );
};

export default EquipentStep;
