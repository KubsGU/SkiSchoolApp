import { FC, Fragment, useEffect, useState } from "react";
import { Client, FormElement } from "types/types";
import s from "./../../App.module.scss";

export const ClientnForm: FormElement[] = [
  { name: "Imie", type: "text", id: "name" },
  { name: "Nazwisko", type: "text", id: "surname" },
  { name: "Nr dowodu", type: "text", id: "idNo" },
  { name: "Pesel", type: "number", id: "pesel" },
  { name: "E-Mail", type: "email", id: "email" },
  { name: "Telefon", type: "tel", id: "phoneNumber" },
];

const ClientStep: FC<{
  setClientId: (clientId: number | undefined) => void;
  setStep: (step: number) => void;
  currentClient: number | undefined;
}> = ({ setClientId, setStep, currentClient }) => {
  const [newClient, setNewClient] = useState<boolean>();
  const [clientsList, setClientsList] = useState<Client[]>();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/Clients`);
        const res = await data.json();
        setClientsList(res.items);
        setClientId(currentClient ?? res.items[0]?.id);
      } catch (e) {
        console.log(e);
      }
    };
    fetchData();
  }, []);

  const handleCheckbox = (e: any) => {
    setNewClient(e.target.checked);
    if (e) {
      setClientId(undefined);
    } else {
      setClientId(clientsList && clientsList[0]?.id);
    }
  };

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    if (newClient) {
      const body = {
        name: e.target.name.value,
        surname: e.target.surname.value,
        email: e.target.email.value,
        idNo: e.target.idNo.value,
        pesel: e.target.pesel.value,
        phoneNumber: e.target.phoneNumber.value,
      };

      try {
        const data = await fetch(`${process.env.REACT_APP_IP}/Clients`, {
          method: "POST",
          mode: "cors",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(body),
        });
        const res = data.json().then((e) => {
          if (e) {
            setClientId(e);
            setStep(1);
          }
        });
      } catch (e) {
        console.log(e);
      }
    } else {
      setStep(1);
    }
  };
  return (
    <>
      <p className={s.title}>Wprowadz klienta</p>
      <form className={s.form} id="clientForm" onSubmit={handleSubmit}>
        <label>Nowy klient</label>
        <input type="checkbox" name="newClient" onChange={handleCheckbox} />
        {newClient &&
          ClientnForm.map((el, i) => {
            return (
              <Fragment key={el.id}>
                <label htmlFor={el.name}>{el.name}</label>
                {el.selectOptions?.length ? (
                  <select
                    id={el.id}
                    name={el.name}
                    multiple={el.multiselect}
                    required
                  >
                    {el.selectOptions.map((op, i) => {
                      return (
                        <option key={op.id} value={op.id}>
                          {op.label}
                        </option>
                      );
                    })}
                  </select>
                ) : (
                  <input
                    type={el.type}
                    id={el.id}
                    name={el.name}
                    required
                  ></input>
                )}
              </Fragment>
            );
          })}
        {!newClient && (
          <>
            <label>Wybierz klienta</label>
            <select
              onChange={(e) => setClientId(+e.target.value)}
              value={currentClient}
            >
              {clientsList &&
                clientsList.map((e, i) => {
                  return (
                    <option key={i} value={e.id}>
                      {`${e.name} ${e.surname}, pesel: ${e.pesel}`}
                    </option>
                  );
                })}
            </select>
          </>
        )}
        <div></div>
        <div className={s.next}>
          <button type="submit" form="clientForm">
            Dalej
          </button>
        </div>
      </form>
    </>
  );
};

export default ClientStep;
