import { useState } from "react";
import { SelectOptions } from "types/types";
import s from "./../../App.module.scss";

const RaportOptions: SelectOptions[] = [
  { id: 1, label: "Raport 1" },
  { id: 2, label: "Raport 2" },
  { id: 3, label: "Raport 3" },
];

const Raport = () => {
  const [report, setReport] = useState<string>();
  const [reportName, setReportName] = useState<string>();

  const handleDelete = async (e: any) => {
    e.preventDefault();
    try {
      const data = await fetch(`${process.env.REACT_APP_IP}/reports/1`, {
        headers: {
          "content-type": "text/csv;charset=UTF-8",
        },
      });
      const res = await data.json();
      setReportName(res.name);
      const objectURL = window.URL.createObjectURL(
        new Blob([res.data], { type: "text/csv" })
      );
      setReport(objectURL);
    } catch (e) {
      console.log(e);
    }
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
        <a href={report} download={reportName}>
          Pobierz
        </a>

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
