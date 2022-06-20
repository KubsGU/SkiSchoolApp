import { SelectOptions } from "types/types";
import s from "./../../App.module.scss";


const RaportOptions: SelectOptions[] = [
    { id: 1, label: "Raport 1" },
    { id: 2, label: "Raport 2" },
    { id: 3, label: "Raport 3" },
  ];
  

const Raport = () => {
  const handleDelete = (e: any) => {
    e.preventDefault();
  };

  return (
    <div>
      <p className={s.title}>Generuj raport</p>

      <div className={s.selectContainer}>
        <select>
          {RaportOptions.map((op) => {
            return (
              <option key={op.id} value={op.id}>
                {op.label}
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
          download
        </button>
      </div>
    </div>
  );
};

export default Raport;
