import { FC, Fragment, useEffect, useState } from "react";
import { Client, FormElement, Trainers } from "types/types";
import s from "./../../App.module.scss";

const Form: FormElement[] = [
  { name: "Data startu", type: "datetime-local", id: "startDate" },
  { name: "Data końca", type: "datetime-local", id: "endtDate" },
];

const EquipentStep: FC<{
  clientId: number | undefined;
  setEquipmentResId: (res: number | undefined) => void;
  setStep: (id: number) => void;
}> = ({ clientId, setEquipmentResId, setStep }) => {
  const [loading, setLoading] = useState<boolean>();
  const [equipmentIds, setEquipmentIds] = useState<number[]>();
  const [equipmentsTypes, setEquipmentsTypes] = useState<string[]>();
  const [equipmentsType, setEquipmentsType] = useState<string>();
  const [reservationForm, setReservationForm] = useState<FormElement[]>(
    Form
  );

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

  const handleAddEqu = async () => {
    // const body = {
    //     startDate: e.target.startDate.value,
    //     endDate: e.target.endtDate.value,
    //     equipmentId: equipmentIds,
    //     clientId: clientId,
    //     isCancelled: false,
    //   };
    // try {
    //     const data = await fetch(`${process.env.REACT_APP_IP}/Equipments/byTypes`, {
    //       method: "POST",
    //       mode: "cors",
    //       headers: { "Content-Type": "application/json" },
    //       body: JSON.stringify(body),
    //     });
    //     const res = data.json().then((e) => {
    //       if (e) {
    //         setLoading(false);
    //         setStep(2);    
    //         reservationForm.push(  {
    //             name: "Sprzet typu " + equipmentsType,
    //             type: "number",
    //             id: "equId" + reservationForm.length,
    //             selectOptions: e.map(), //map to option
    //         },)
    //         setReservationForm(reservationForm)
    //         setEquipmentsType(undefined);
    //       }
    //     });
    //   } catch (e) {
    //     console.log(e);
    //   }


  }

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    if (equipmentIds) {
      setLoading(true);
      const body = {
        startDate: e.target.startDate.value,
        endDate: e.target.endtDate.value,
        equipmentId: equipmentIds,
        clientId: clientId,
        isCancelled: false,
      };

      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/Timetables`, {
          method: "POST",
          mode: "cors",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(body),
        });
        const res = data.json().then((e) => {
          if (e) {
            setEquipmentResId(e);
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
      <p className={s.title}>Wprowadz instruktora</p>
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

        <div className={s.add}>
          <button onClick={() => setStep(0)} form="instructorForm">
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
