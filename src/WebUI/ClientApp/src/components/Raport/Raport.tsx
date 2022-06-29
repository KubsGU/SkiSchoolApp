import { useState } from "react";
import { SelectOptions } from "types/types";
import s from "./../../App.module.scss";

type ReportSelectOptions = SelectOptions & { type: string };

const RaportOptions: ReportSelectOptions[] = [
  { id: 1, type: "rental", label: "Raport dobowy (wypozyczenia)" },
  { id: 2, type: "timetable", label: "Raport dobowy (instruktorzy)" },
];

const Raport = () => {
  const [report, setReport] = useState<string>();
  const [reportId, setReportId] = useState<string>();
  const [reportType, setReportType] = useState<string>(RaportOptions[0].type);

  const generateReport = async (e: any) => {
    try {
      const data = await fetch(
        `${process.env.REACT_APP_IP}/reports/${reportType}`,
        {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({ name: "raport" }),
        }
      );
      const res = await data.text();
      console.log(res);
      setReportId(res);
    } catch (e) {
      console.log(e);
    }
  };

  const handleDelete = async (e: any) => {
    e.preventDefault();
    try {
      const data = await fetch(
        `${process.env.REACT_APP_IP}/reports/downloadBlob/1`
      );
      const res = await data.text();
      console.log(res);
      const objectURL = window.URL.createObjectURL(
        new Blob([res], { type: "text/csv" })
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
              <option
                key={op.id}
                value={op.type}
                onChange={() => setReportType(op.type)}
              >
                {op.label}
              </option>
            );
          })}
        </select>
        <a href={report} download="test.csv">
          Pobierz
        </a>

        <button
          type="submit"
          form="form"
          className="material-icons"
          onClick={generateReport}
        >
          download
        </button>
      </div>
    </div>
  );
};

export default Raport;
